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
            AWGEventMigrator eventMigrator = new AWGEventMigrator();
            eventMigrator.migrateEvents();
        }
    }
}
