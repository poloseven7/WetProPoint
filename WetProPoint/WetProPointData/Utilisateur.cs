using System;
using System.Collections.Generic;

namespace WetProPointData
{
    [Serializable]
    public class Utilisateur : Notify
    {
        private Journee journee = new Journee();

        public Journee Journee
        {
            get { return journee; }
            set { journee = value;
                OnPropertyChanged("Journee");
            }
        }

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value;
                OnPropertyChanged("Nom");
            }
        }

        private float poids;

        public float Poids
        {
            get { return poids; }
            set { poids = value; }
        }

        private int totalPointsJourDispo;

        public int TotalPointsJourDispo
        {
            get { return totalPointsJourDispo; }
            set { totalPointsJourDispo = value; }
        }

        private List<Ingredient> ingredientsPreferes = new List<Ingredient>();
        public System.Collections.Generic.List<WetProPointData.Ingredient> IngredientsPreferes
        {
            get { return ingredientsPreferes; }
            set { ingredientsPreferes = value; }
        }
    }
}