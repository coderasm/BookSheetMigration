using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public class BookSheetUpcomingEventMigrator : BookSheetEventMigrator
    {
        public BookSheetUpcomingEventMigrator()
        {
            eventStatus = EventStatus.InProgress;
        }

        public override void migrate()
        {
            base.migrateEvents();
        }
    }
}
