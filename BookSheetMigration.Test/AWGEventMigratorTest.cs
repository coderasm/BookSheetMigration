using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class AWGEventMigratorTest
    {
        [TestMethod]
        public void testMigrationOfEvents()
        {
            DataMigrator<AWGEventDTO> eventMigrator = new BookSheetEventMigrator(EventStatus.Upcoming);
            eventMigrator.migrate();
        }
    }
}
