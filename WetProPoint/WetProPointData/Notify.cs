using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetProPointData
{
        [Serializable]
        public class Notify : INotifyPropertyChanged
        {
            protected static bool IsDirty;

            public static event EventHandler CustomClick = null;

            // Declare the event        
            public event PropertyChangedEventHandler PropertyChanged;

            // Create the OnPropertyChanged method to raise the event 
            public void OnPropertyChanged(string name, bool dirty = true)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                    if (dirty)
                        IsDirty = true;

                    CustomClick?.Invoke(name, null);
                }
            }
        }
}
