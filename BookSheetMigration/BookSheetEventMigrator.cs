using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public class BookSheetEventMigrator : DataMigrator<AWGEventDTO>
    {
        protected EventStatus eventStatus;

        public BookSheetEventMigrator(EventStatus eventStatus)
        {
            this.eventStatus = eventStatus;
        }

        protected override List<AWGEventDTO> findPossiblyNewRecords()
        {
            var awgServiceClient = new AWGServiceClient();
            var eventDirectory = awgServiceClient.findEventsByStatus(eventStatus);
            return eventDirectory.awgEvents;
        }

        public override Task migrateRecord(AWGEventDTO possiblyNewRecord)
        {
            if(recordExists(possiblyNewRecord))
                return entityDao.updateEvent(possiblyNewRecord);
            return entityDao.insertEvent(possiblyNewRecord);
        }

        protected override bool recordExists(AWGEventDTO possiblyNewRecord)
        {
            return entityDao.eventExists(possiblyNewRecord).Result;
        }
    }
}
