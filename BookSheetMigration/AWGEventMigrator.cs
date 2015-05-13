using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSheetMigration
{
    public class AWGEventMigrator
    {
        private List<AWGEventDTO> upcomingEvents = new List<AWGEventDTO>();
        private List<AWGEventDTO> inProgressEvents = new List<AWGEventDTO>();
        private List<AWGEventDTO> alreadyMigratedUpcomingEvents = new List<AWGEventDTO>();
        private List<AWGEventDTO> alreadyMigratedInProgressEvents = new List<AWGEventDTO>();

        public AWGEventMigrator()
        {
            findUpcomingAndInProgressEvents();
            findAlreadyMigratedEvents();
        }

        public void migrateEvents()
        {
            migrateUpcomingEvents();
            migrateInprogressEvents();
        }

        private void migrateUpcomingEvents()
        {
            foreach (var upcomingEvent in upcomingEvents)
            {
                if(shouldMigrateUpcomingEvent(upcomingEvent))
                    migrateEvent(upcomingEvent);
            }
        }

        private void migrateInprogressEvents()
        {
            foreach (var inProgressEvent in inProgressEvents)
            {
                if (shouldMigrateInProgressEvent(inProgressEvent))
                    migrateEvent(inProgressEvent);
            }
        }

        private void migrateEvent(AWGEventDTO eventToMigrate)
        {
            AbsBookSheetEventDAO bookSheetEventDao = new AbsBookSheetEventDAO();
            bookSheetEventDao.insertEvent(eventToMigrate);
        }

        private void findUpcomingAndInProgressEvents()
        {
            findUpcomingEvents();
            findInProgressEvents();
        }

        private void findAlreadyMigratedEvents()
        {
            findAlreadyMigratedUpcomingEvents();
            findAlreadyMigratedInProgressEvents();
        }

        private void findAlreadyMigratedUpcomingEvents()
        {
            if(upcomingEvents.Count > 0)
                alreadyMigratedUpcomingEvents = findMigratedEvents(upcomingEvents);
        }

        private void findAlreadyMigratedInProgressEvents()
        {
            if (inProgressEvents.Count > 0)
                alreadyMigratedInProgressEvents = findMigratedEvents(inProgressEvents);
        }

        private void findUpcomingEvents()
        {
            var awgServiceClient = new AWGServiceClient();
            var eventDirectory = awgServiceClient.findEventsByStatus(EventStatus.Upcoming);
            upcomingEvents = eventDirectory.awgEvents;
        }

        private void findInProgressEvents()
        {
            var awgServiceClient = new AWGServiceClient();
            var eventDirectory = awgServiceClient.findEventsByStatus(EventStatus.InProgress);
            inProgressEvents = eventDirectory.awgEvents;
        }

        private List<int> createEventList(List<AWGEventDTO> eventObjectList)
        {
            List<int> events = new List<int>();
            foreach (var upcomingEvent in eventObjectList)
            {
                events.Add(upcomingEvent.eventId);
            }
            return events;
        }

        private List<AWGEventDTO> findMigratedEvents(List<AWGEventDTO> foundEvents)
        {
            var eventList = createEventList(foundEvents);
            var bookSheetEventDao = new AbsBookSheetEventDAO();
            return bookSheetEventDao.FindEventsIn(eventList).Result;
        }

        private bool shouldMigrateUpcomingEvent(AWGEventDTO upcomingEvent)
        {
            return !alreadyMigratedUpcomingEvents.Contains(upcomingEvent);
        }

        private bool shouldMigrateInProgressEvent(AWGEventDTO inProgressEvent)
        {
            return !alreadyMigratedInProgressEvents.Contains(inProgressEvent);
        }
    }
}
