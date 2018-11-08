using System;

namespace WetProPointData
{
    [Serializable]
    public class Ingredient : IngredientBase
    {
        private bool utiliserOptionPlus = false;

        public bool UtiliserOptionPlus
        {
            get { return utiliserOptionPlus; }
            set { utiliserOptionPlus = value;
                OnPropertyChanged("UtiliserOptionPlus");
            }
        }

        public void CalculerPoints(int quantite)
        {
            throw new System.NotImplementedException();
        }
    }
}