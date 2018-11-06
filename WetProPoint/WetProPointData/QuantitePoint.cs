using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetProPointData
{
    [Serializable]
    public class QuantitePoint
    {
        private string quantite;
        public string Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        private int pointParUnite;
        public int PointParUnite
        {
            get { return pointParUnite; }
            set { pointParUnite = value; }
        }

        public override string  ToString()
        {
            return Quantite + " = " + PointParUnite + " pts";
        }
    }
}
