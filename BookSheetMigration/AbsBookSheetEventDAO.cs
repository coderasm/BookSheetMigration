using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncPoco;

namespace BookSheetMigration
{
    public class AbsBookSheetEventDAO
    {
        public async Task<AWGEventDTO> findEvent(int eventId)
        {
            var dbConnection = getDatabaseConnection();
            return await dbConnection.SingleOrDefaultAsync<AWGEventDTO>("SELECT * FROM " + Settings.ABSBookSheetEventTable + " WHERE EventId=@0" + eventId);
        }

        public async Task<List<AWGEventDTO>> FindEventsIn(List<AWGEventDTO> eventDtos)
        {
            var dbConnection = getDatabaseConnection();
            var eventIdString = formatEventIdsToString(eventDtos);
            var query = "SELECT * FROM " + Settings.ABSBookSheetEventTable + " WHERE EventId IN (" + eventIdString + ")";
            return await dbConnection.FetchAsync<AWGEventDTO>(query);
        }

        private string formatEventIdsToString(List<AWGEventDTO> eventDtos)
        {
            var eventString = "";
            eventDtos.ForEach(a => eventString += a.eventId + ",");
            return eventString.TrimEnd(',');
        }

        public async void insertEvent(AWGEventDTO awgEventDto)
        {
            var dbConnection = getDatabaseConnection();
            await dbConnection.InsertAsync(awgEventDto);
        }

        private Database getDatabaseConnection()
        {
            return new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
        }
    }
}
