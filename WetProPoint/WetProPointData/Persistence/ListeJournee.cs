using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WetProPointData
{
    [Serializable]
    public class ListeJournee
    {
        private List<Journee> journees;

        [XmlArray("Journees")]
        public List<Journee> Journees
        {
            get { return journees; }
            set { journees = value; }
        }
    }
}