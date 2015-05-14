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
            BookSheetEventMigrator eventMigrator = new BookSheetUpcomingEventMigrator();
            eventMigrator.migrate();
        }
    }
}
