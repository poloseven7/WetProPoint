using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using System.Globalization;
using System.Text;

namespace WetProPointData
{
    public class Database : Notify
    {
        private string userFilePath;
        public string UserFilePath
        {
            get { return userFilePath; }
            set { userFilePath = value; }
        }
         
        private string ingredientsFilePath;
        public string IngredientsFilePath
        {
            get { return ingredientsFilePath; }
            set { ingredientsFilePath = value; }
        }

        private List<IngredientBase> ingredientsBase = new List<IngredientBase>();
        public List<IngredientBase> IngredientsBase
        {
            get { return ingredientsBase; }
            set { ingredientsBase = value;
                OnPropertyChanged("IngredientsBase");

            }
        }

        private List<IngredientBase> ingredientsBaseFiltre = new List<IngredientBase>();
        public List<IngredientBase> IngredientsBaseFiltre
        {
            get { return ingredientsBaseFiltre; }
            set
            {
                ingredientsBaseFiltre = value;
                OnPropertyChanged("IngredientsBaseFiltre");

            }
        }

        public void ChargerBase(string inIngredientsPath)
        {
            ListeIngredients ingredients = new ListeIngredients();
            XMLPersistIngredients IngredientsXMLPersister = new XMLPersistIngredients();
            IngredientsBase = IngredientsXMLPersister.Load(ingredients, inIngredientsPath).Ingredients.OrderBy(x => x.Nom).ToList();
            IngredientsBaseFiltre = IngredientsBase;
        }

        public string RemoveAccents(string s)
        {
            Encoding destEncoding = Encoding.GetEncoding("iso-8859-8");

            return destEncoding.GetString(
                Encoding.Convert(Encoding.UTF8, destEncoding, Encoding.UTF8.GetBytes(s)));
        }

        public void Filter(string name)
        {
            if (string.IsNullOrEmpty(name))
                IngredientsBaseFiltre = IngredientsBase.OrderBy(x => x.Nom).ToList();
            else
                IngredientsBaseFiltre = IngredientsBase.Where(x => RemoveAccents(x.Nom.ToLower()).Contains(RemoveAccents(name.ToLower()))).OrderBy(x => x.Nom).ToList();
        }

        public void SauverJournees(ListeJournee journees)
        {
            XMLPersistJournees journeesXMLPersister = new XMLPersistJournees();

            journeesXMLPersister.Save(journees, UserFilePath);
        }

        public ListeJournee ChargerJournees(ListeJournee journees)
        {
            XMLPersistJournees journeesXMLPersister = new XMLPersistJournees();

            journees = journeesXMLPersister.Load(journees, UserFilePath);

            return journees;
        }

        public void ConvertBase(string inPath, string outIngredientsPath, string outCategoriesPath)
        {
            FileInfo existingFile = new FileInfo(inPath);

            ListeCategories categories = new ListeCategories();
            ListeIngredients ingredients = new ListeIngredients();

            int indexCategorie = 1, indexIngredient = 1;

            Categorie currentCat = null;

            using (StreamWriter databaseFileXML = new StreamWriter(outIngredientsPath))
            {
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    for (int worksheetIndex = 1; worksheetIndex <= 8; worksheetIndex++)
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetIndex];
                        
                        Scan(worksheet, 1, databaseFileXML, ref currentCat, ingredients, categories, ref indexCategorie, ref indexIngredient);
                        Scan(worksheet, 3, databaseFileXML, ref currentCat, ingredients, categories, ref indexCategorie, ref indexIngredient);
                    }
                }
            }

            XMLPersistIngredients IngredientsXMLPersister = new XMLPersistIngredients();
            IngredientsXMLPersister.Save(ingredients, outIngredientsPath);

            XMLPersistCategories categoriesXMLPersister = new XMLPersistCategories();
            categoriesXMLPersister.Save(categories, outCategoriesPath);

        }

        private void Scan(ExcelWorksheet worksheet, int col, StreamWriter databaseFileXML, ref Categorie currentCat, ListeIngredients ingredients, ListeCategories categories, ref int indexCategorie, ref int indexIngredient)
        {
            object line = null;
            int index = 1;

            IngredientBase ingredient = null;

            while ((line = worksheet.Cells[index, col].Value) != null)
            {
                string col1 = worksheet.Cells[index, col].Value.ToString();

                object col2Obj = null;

                if ((col2Obj = worksheet.Cells[index++, col + 1].Value) != null)
                {
                    string col2 = col2Obj.ToString();

                    if (col2.Trim().CompareTo("CAT") != -1)
                    {
                        currentCat = new Categorie() { Id = indexCategorie++, Nom = col1.Trim() };
                        categories.Categories.Add(currentCat);
                        //databaseFileXML.WriteLine(currentCat.Nom);
                    }
                    else
                    {
                        string nom = col1.ToString();
                        if (nom.Contains("Option Plus"))
                        {
                            // Option plus
                            // Récupérer l'ingrédient précédent !
                            // Lui ajouter l'option plus
                            if (ingredient != null)
                            {
                                ingredient.OptionPlus = int.Parse(col2.ToString().Trim());
                                ingredient.OptionPlusPossible = true;
                            }
                        }
                        else
                        {
                            var nomSplit = col1.ToString().Split(new[] { ',' }, 2);

                            ingredient = ingredients.Ingredients.FirstOrDefault(s => s.Nom == nomSplit[0].Trim());

                            if (ingredient == null)
                            {
                                ingredient = new IngredientBase() { Id = indexIngredient++, Nom = nomSplit[0].Trim(), Categorie = currentCat };
                                ingredients.Ingredients.Add(ingredient);
                            }

                            ingredient.QuantitesPoints.Add(new QuantitePoint() { Quantite = (nomSplit.GetLength(0) > 1 ? nomSplit[1].Trim() : ""), PointParUnite = int.Parse(col2.ToString().Trim()) });
                            //databaseFileXML.WriteLine("\t" + ingredient.Nom + " ," + ingredient.PointParUnite + (ingredient.OptionPlusPossible?" (Option plus:" + ingredient.OptionPlus + ")":""));
                        }
                    }
                }                
            }
        }
    }
}