using System;
using System.Collections.Generic;

namespace WetProPointData
{
    [Serializable]
    public class IngredientBase : Notify
    {
        private int id = 1;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Categorie categorie;

        public Categorie Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private String nom;

        public System.String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private List<QuantitePoint> quantitesPoints = new List<QuantitePoint>();
        public List<QuantitePoint> QuantitesPoints
        {
            get { return quantitesPoints; }
            set { quantitesPoints = value; }
        }

        private int optionPlus;

        public int OptionPlus
        {
            get { return optionPlus; }
            set { optionPlus = value; }
        }

        public bool OptionPlusPossible
        {
            get
            {
                return optionPlusPossible;
            }

            set
            {
                optionPlusPossible = value;
                OnPropertyChanged("OptionPlusPossible");
            }
        }

        private bool optionPlusPossible = false;
    }
}