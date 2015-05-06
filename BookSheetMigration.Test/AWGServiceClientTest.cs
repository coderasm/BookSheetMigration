using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSheetMigration;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class AWGServiceClientTest
    {
        [TestMethod]
        public void WhenAnOperationIsCalledDataIsGivenBack()
        {
            AWGServiceClient client = new AWGServiceClient();
            XElement rootElement = client.findEventsByStatus(EventStatus.InProgress);
            var serializer = new XmlSerializer(typeof(AWGEventListDTO));
            var xmlReader = rootElement.CreateReader();
            var awgEventSetAsObject = (AWGEventListDTO)serializer.Deserialize(xmlReader);
            Assert.AreEqual(2, awgEventSetAsObject.awgEvents.Count);
        }
    }
}
