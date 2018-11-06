using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WetProPointData
{
    [Serializable]
    public class ListeIngredients
    {
        private List<IngredientBase> ingredients = new List<IngredientBase>();

        [XmlArray("Ingredients")]
        public List<IngredientBase> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
    }
}