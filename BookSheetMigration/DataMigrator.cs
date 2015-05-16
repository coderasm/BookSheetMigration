﻿using AsyncPoco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class DataMigrator<T>
    {
        protected List<T> possiblyNewRecords;
        protected EntityDAO<T> entityDao;
        private Task[] runningTasks;

        protected abstract List<T> findPossiblyNewRecords();

        public DataMigrator()
        {
            entityDao = new EntityDAO<T>(new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName));
        } 

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
                createAndSaveMigrationTasks();
                Task.WaitAll(runningTasks);
            }
        }

        private void createAndSaveMigrationTasks()
        {
            for (int i = 0; i < possiblyNewRecords.Count; i++)
            {
                var runningTask = migrateRecord(possiblyNewRecords[i]);
                runningTasks[i] = runningTask;
            }
        }

        private void initializeRunningTasks(int recordCount)
        {
            runningTasks = new Task[recordCount];
        }

        protected abstract bool recordExists(T possiblyNewRecord);

        public abstract Task migrateRecord(T possiblyNewRecord);

        public void migrate()
        {
            migrateRecords();
        }
    }
}
