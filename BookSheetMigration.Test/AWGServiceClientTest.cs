using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var awgEvents = rootElement.Descendants("Event");
            Assert.AreEqual("", foundEvents.ToString());
        }
    }
}
