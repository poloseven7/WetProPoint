using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WetProPointData
{
    [Serializable]
    public class ListeCategories
    {
        private List<Categorie> categories = new List<Categorie>();

        [XmlArray("Categories")]
        public List<Categorie> Categories
        {
            get { return categories; }
            set { categories = value; }
        }
    }
}