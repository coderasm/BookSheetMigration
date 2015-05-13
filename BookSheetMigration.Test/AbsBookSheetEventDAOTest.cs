using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class AbsBookSheetEventDAOTest
    {
        [TestMethod]
        public void testFindingAlreadyMigratedEvents()
        {
            var eventList = new List<int>()
            {
                21229
            };
            AbsBookSheetEventDAO absBookSheetEventDao = new AbsBookSheetEventDAO();
            List<AWGEventDTO> eventDtos = absBookSheetEventDao.FindEventsIn(eventList).Result;
            Assert.AreEqual(21229, eventDtos[0].eventId);
        }
    }
}
