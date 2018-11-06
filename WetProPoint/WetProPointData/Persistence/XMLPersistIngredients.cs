using System.IO;
using System.Xml.Serialization;

namespace WetProPointData
{
    public class XMLPersistIngredients
    {
        public void Save(ListeIngredients ingredients, string fileName)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ListeIngredients));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, ingredients);
            myWriter.Close();
        }

        public ListeIngredients Load(ListeIngredients ingredients, string fileName)
        {
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(ListeIngredients));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileName, FileMode.Open);
            // Calls the Deserialize method and casts to the object type.
            ingredients = (ListeIngredients)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            return ingredients;
        }
    }
}