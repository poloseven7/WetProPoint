using System.IO;
using System.Xml.Serialization;

namespace WetProPointData
{
    public class XMLPersistJournees
    {
        public void Save(ListeJournee journees, string fileName)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ListeJournee));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, journees);
            myWriter.Close();
        }

        public ListeJournee Load(ListeJournee journees, string fileName)
        {
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(ListeJournee));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileName, FileMode.Open);
            // Calls the Deserialize method and casts to the object type.
            journees = (ListeJournee)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            return journees;
        }
    }
}