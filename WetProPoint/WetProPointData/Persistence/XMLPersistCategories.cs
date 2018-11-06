using System.IO;
using System.Xml.Serialization;

namespace WetProPointData
{
    public class XMLPersistCategories
    {
        public void Save(ListeCategories categories, string fileName)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ListeCategories));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, categories);
            myWriter.Close();
        }

        public ListeCategories Load(ListeCategories categories, string fileName)
        {
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(ListeCategories));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileName, FileMode.Open);
            // Calls the Deserialize method and casts to the object type.
            categories = (ListeCategories)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            return categories;
        }
    }
}