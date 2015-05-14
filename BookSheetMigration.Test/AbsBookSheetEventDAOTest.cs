using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class AbsBookSheetEventDAOTest
    {
        [TestMethod]
        [Ignore]
        public void testFindingAlreadyMigratedEvents()
        {
            var myEvent = new AWGEventDTO();
            myEvent.eventId = 21229;
            myEvent.endTime = DateTime.Now;

            AbsBookSheetEventDAO absBookSheetEventDao = new AbsBookSheetEventDAO();
            var result = absBookSheetEventDao.saveEvent(myEvent).IsCompleted;
            Assert.IsTrue(result);
        }
    }
}
