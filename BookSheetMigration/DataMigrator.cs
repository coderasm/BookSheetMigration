using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class DataMigrator<T>
    {
        protected List<T> possiblyNewRecords;
        private Task[] runningTasks; 

        protected abstract List<T> findPossiblyNewRecords();

        private bool possibleRecordsToMigrateExist(List<T> possiblyNewRecords)
        {
 	        return possiblyNewRecords.Count > 0;
        }

        protected void migrateRecords()
        {
            possiblyNewRecords = findPossiblyNewRecords();
            if (possibleRecordsToMigrateExist(possiblyNewRecords))
            {
                initializeRunningTasks(possiblyNewRecords.Count);
                for(int i = 0; i < possiblyNewRecords.Count; i++)
                {
                    var runningTask = migrateRecord(possiblyNewRecords[i]);
                    runningTasks[i] = runningTask;
                }
                Task.WaitAll(runningTasks);
            }
        }

        private void initializeRunningTasks(int recordCount)
        {
            runningTasks = new Task[recordCount];
        }

        protected abstract Task<T> migrateRecord(T possiblyNewRecord);
    }
}
