using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Bannerlord.Actus.Purus.Loaders
{
    public class XmlLoader<T>
    {
        protected T Load(string path)
        {
            StreamReader streamReader;
            T data;
            using (streamReader = new StreamReader(path))
            {
                var xmlReader = XmlReader.Create(streamReader);
                var serializer = new XmlSerializer(typeof(T));
                data = (T)serializer.Deserialize(xmlReader);
            }
            return data;
        }
    }
}
