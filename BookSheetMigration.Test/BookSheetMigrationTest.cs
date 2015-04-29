using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSheetMigration;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class BookSheetMigrationTest
    {

        [TestInitialize]
        public void setUp()
        {
        }


        [TestMethod]
        public void testRetrieveEventFromAWGService()
        {
            AWGEventRepository awgEventRepository = new AWGEventRepository();
            List<EventDTO> events = AWGEventRepository.findEventsByStatus("InProgress");
            Assert.AreEqual(1, events.Count);
        }
    }
}
