using System;
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
            foundEvents = client.findEventsByStatus(status);
        }
    }
}
