using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
        public void WhenAskingForEventsByStatus_MatchingEventsAreReturned()
        {
            AWGServiceClient client = new AWGServiceClient();
            AWGEventDirectory eventDirectory = client.findEventsByStatus(EventStatus.InProgress);
            Assert.AreEqual(2, eventDirectory.awgEvents.Count);
        }

        [TestMethod]
        public void WhenAskingForInventoryByEventIdAndStatus_MatchingInventoryAreReturned()
        {
            AWGServiceClient client = new AWGServiceClient();
            AWGInventoryDirectory inventoryDirectory = client.searchInventory(InventoryStatus.Sold, 123191);
            Assert.AreEqual(26, inventoryDirectory.inventory.Count);
        }
    }
}
