using System;

namespace WetProPointData
{
    [Serializable]
    public class Categorie
    {
        private int id = 1;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nom = "";

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}