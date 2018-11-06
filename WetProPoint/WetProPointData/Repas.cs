using System;
using System.Collections.Generic;

namespace WetProPointData
{
    [Serializable]
    public class Repas
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
            set { ingredients = value; }
        }

        public void CalculerPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}