using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            AWGInventoryDirectory inventoryDirectory = client.findVehiclesByStatusAndId(InventoryStatus.Sold, 123191);
            Assert.AreEqual(26, inventoryDirectory.inventory.Count);
        }

        [TestMethod]
        public void WhenAskingForTransactionsByEventIdAndStatus_MatchingTransactionsAreReturned()
        {
            AWGServiceClient client = new AWGServiceClient();
            AWGTransactionDirectory transactionDirectory = client.findTransactionsByStatusAndId(TransactionStatus.New, 122972);
            Assert.AreEqual(46, transactionDirectory.transactions.Count);
        }
    }
}
