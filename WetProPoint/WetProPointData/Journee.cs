using System;

namespace WetProPointData
{
    [Serializable]
    public class Journee
    {
        private Repas petitDej = new Repas() {Nom = "Petit déjeuner" };

        public WetProPointData.Repas PetitDej
        {
            get { return petitDej; }
            set { petitDej = value; }
        }

        private Repas midi = new Repas() { Nom = "Déjeuner" };

        public WetProPointData.Repas Midi
        {
            get { return midi; }
            set { midi = value; }
        }

        private Repas soir = new Repas() { Nom = "Diner" };

        public WetProPointData.Repas Soir
        {
            get { return soir; }
            set { soir = value; }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        private DateTime date;

        public void CalculerPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}