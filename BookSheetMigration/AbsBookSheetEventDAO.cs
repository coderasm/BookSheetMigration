using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncPoco;

namespace BookSheetMigration
{
    public class AbsBookSheetEventDAO
    {
        public async Task<AWGEventDTO> saveEvent(AWGEventDTO awgEventDto)
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
