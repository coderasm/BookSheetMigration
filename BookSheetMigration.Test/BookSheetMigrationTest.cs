using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class BookSheetMigrationTest
    {
        private AWGServiceClient awgServiceClient;

        [TestInitialize]
        public void setUp()
        {
            AWGServiceClientFactory awgServiceClientFactory = new AWGServiceClientFactory();
            awgServiceClient = awgServiceClientFactory.createClient();

            var securityToken = "BA7D2AD1-2963-468E-955E-57B24DAD4C05C5DED32F-A815-4D90-A86B-6F957D793537";
            var userName = "Authentication";
            var password = "BF1E2D88-003B-429C-B1EE-1A02941E6F92";
            AWGServiceCredential awgServiceCredential = new AWGServiceCredential(securityToken, userName, password);
            awgServiceClient.applyCredentials(awgServiceCredential);
        }

        [TestMethod]
        public void testGetSalesFromRepository()
        {
            AWGSaleRepository awgRepository = new AWGSaleRepository();
            DateTime datetime = DateTime.Now.Date;
            string sales = awgRepository.getSalesOnDate(datetime);
            Assert.AreNotEqual("", sales);
        }

        [TestMethod]
        public void testApplyingCredentialsToAServiceClient()
        {
            Assert.IsTrue(awgServiceClient.areCredentialsApplied());
        }

        [TestMethod]
        public void testListingOfEventsThroughAWGClient()
        {
            DataSet eventsFound = awgServiceClient.findEventsByStatus(AWGService.EventStatus.InProgress);
            Assert.AreEqual(1, eventsFound.Tables.Count);
        }
    }
}
