using System;
using System.Collections.Generic;

namespace BookSheetMigration
{
    class BookSheetUpComingEventMigrator : DataMigrator<AWGEventDTO>
    {
        private EventStatus eventStatus;

        public BookSheetUpComingEventMigrator(EventStatus eventStatus)
        {
            this.eventStatus = eventStatus;
        }

        protected override List<AWGEventDTO> findPossiblyNewRecords()
        {
            var awgServiceClient = new AWGServiceClient();
            var eventDirectory = awgServiceClient.findEventsByStatus(eventStatus);
            this.possiblyNewRecords = eventDirectory.awgEvents;
        }

        protected override List<AWGEventDTO> findAlreadyMigratedRecords(List<AWGEventDTO> foundPossiblyNewRecords)
        {
            var bookSheetEventDao = new AbsBookSheetEventDAO();
            return bookSheetEventDao.FindEventsIn(foundPossiblyNewRecords).Result;
        }

        protected override void migrateRecord(AWGEventDTO possiblyNewRecord)
        {
            throw new NotImplementedException();
        }
    }
}
