using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class BookSheetEventMigrator : DataMigrator<AWGEventDTO>
    {
        protected EventStatus eventStatus;

        protected override List<AWGEventDTO> findPossiblyNewRecords()
        {
            var awgServiceClient = new AWGServiceClient();
            var eventDirectory = awgServiceClient.findEventsByStatus(eventStatus);
            return eventDirectory.awgEvents;
        }

        protected async override Task<AWGEventDTO> migrateRecord(AWGEventDTO possiblyNewRecord)
        {
            AbsBookSheetEventDAO bookSheetEventDao = new AbsBookSheetEventDAO();
            await bookSheetEventDao.saveEvent(possiblyNewRecord);
        }

        protected void migrateEvents()
        {
            migrateRecords();
        }

        public abstract void migrate();
    }
}
