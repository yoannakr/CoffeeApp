using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Coffee.Models;

namespace Coffee.DataSettings.Implementations
{
    public class XmlWriter : IWriter
    {
        public void SaveData<T>(List<T> all, string fileName) where T : Product
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            TextWriter writer = new StreamWriter(fileName);

            xmlSerializer.Serialize(writer, all);

            writer.Close();
        }
    }
}
