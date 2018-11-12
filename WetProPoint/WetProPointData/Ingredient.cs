using System;

namespace WetProPointData
{
    [Serializable]
    public class Ingredient : IngredientBase
    {
        public Ingredient()
        {
        }

        public Ingredient(IngredientBase ingredientBase, bool paramOptionPlus)
        {
            this.Categorie = ingredientBase.Categorie;
            this.Nom = ingredientBase.Nom;
            this.OptionPlus = ingredientBase.OptionPlus;
            this.OptionPlusPossible = ingredientBase.OptionPlusPossible;
            this.QuantitesPoints = ingredientBase.QuantitesPoints;
            this.UtiliserOptionPlus = paramOptionPlus;
        }

        private bool utiliserOptionPlus = false;

        public bool UtiliserOptionPlus
        {
            get { return utiliserOptionPlus; }
            set { utiliserOptionPlus = value;
                OnPropertyChanged("UtiliserOptionPlus");
            }
        }

        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
                OnPropertyChanged("Quantite");
            }
        }

        private int quantite = 0;

        public void CalculerPoints(int quantite)
        {
            throw new System.NotImplementedException();
        }
    }
}