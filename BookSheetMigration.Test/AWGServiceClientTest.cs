using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSheetMigration;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class AWGServiceClientTest
    {
        [TestMethod]
        [Ignore]
        public void WhenAnOperationIsCalledDataIsGivenBack()
        {
            AWGServiceClient client = new AWGServiceClient();
            string status = "InProgress";
            EventDTO foundEvents = client.findEventsByStatus(status);
            Assert.IsNotNull(foundEvents);
        }
    }
}
