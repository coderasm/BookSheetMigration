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
            AWGEventDirectory eventDirectory = client.findEventsByStatus(EventStatus.InProgress);
            Assert.AreEqual(2, eventDirectory.awgEvents.Count);
        }
    }
}
