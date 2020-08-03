
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Coffee.DataSettings.Implementations
{
    public class XmlReader : IReader
    {
        ObservableCollection<T> IReader.ReadData<T>(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<T>));
            TextReader reader = new StreamReader(fileName);

            ObservableCollection<T> list = (ObservableCollection<T>)xmlSerializer.Deserialize(reader);

            reader.Close();

            return list;
        }
    }

}
