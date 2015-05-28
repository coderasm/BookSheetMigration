using AsyncPoco;

namespace BookSheetMigration
{
    public class DatabaseFactory
    {

        internal static Database makeDatabase()
        {
            return new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
        }
    }
}
