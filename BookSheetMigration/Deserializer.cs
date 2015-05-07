using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BookSheetMigration
{
    public class Deserializer<T> {

        private XElement response;

        public Deserializer(XElement response)
        {
            this.response = response;
        }

        public T deserializeResponse()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var reader = response.CreateReader();
            return (T) serializer.Deserialize(reader);
        }
    }
}
