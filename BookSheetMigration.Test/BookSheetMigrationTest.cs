using System;
using System.Collections.Generic;
using System.Security.Permissions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSheetMigration;

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
        public void testAuthenticationOfawgServiceClient()
        {
            awgServiceClient.authenticate();
            Assert.IsTrue(awgServiceClient.isAuthenticated());
        }

        [TestMethod]
        public void testApplyingCredentialsToAServiceClient()
        {
            var securityToken = "sometoken";
            var userName = "someusername";
            var password = "somepassword";
            AWGServiceCredential awgServiceCredential = new AWGServiceCredential(securityToken, userName, password);
            awgServiceClient.applyCredentials(awgServiceCredential);
            Assert.IsTrue(awgServiceClient.areCredentialsApplied());
        }

        [TestMethod]
        public void testListingOfEventsThroughAWGClient()
        {
            awgServiceClient.authenticate();
            List<EventDTO> eventsFound = awgServiceClient.findEventsByStatus(AWGService.EventStatus.InProgress);
            Assert.AreEqual(1, eventsFound.Count);
        }
    }
}
