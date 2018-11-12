using System;
using System.Collections.Generic;
using System.Linq;

namespace WetProPointData
{
    [Serializable]
    public class Repas : Notify
    {
        private string nom = "";
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private List<Ingredient> ingredients = new List<Ingredient>();

        public List<WetProPointData.Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value;
                OnPropertyChanged("Ingredients");
            }
        }

        public void AddIngredient(IngredientBase ingredientBase, bool optionPlus)
        {
            List<Ingredient> result = Ingredients.Where(x => x.Nom == ingredientBase.Nom).ToList();
            if (result.Count == 0)
            {
                Ingredients.Add(new WetProPointData.Ingredient(ingredientBase, optionPlus));
            }
            else
            {
                result[0].Quantite += 1;
            }

            Ingredients = new List<Ingredient>(Ingredients);
        }

        public void CalculerPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}