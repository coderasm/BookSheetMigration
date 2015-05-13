using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class DataMigrator<T>
    {
        protected List<T> existingRecords;
        protected List<T> possiblyNewRecords;

        protected DataMigrator()
        {
            possiblyNewRecords = findPossiblyNewRecords();
            existingRecords = findExistingRecords(possiblyNewRecords);
        }

        protected abstract List<T> findPossiblyNewRecords();

        private List<T> findExistingRecords(List<T> foundPossiblyNewRecords)
        {
            if(possibleRecordsToMigrateExist(foundPossiblyNewRecords))
                return findAlreadyMigratedRecords(foundPossiblyNewRecords);
            else
                return new List<T>();
        }

        private bool possibleRecordsToMigrateExist(List<T> foundPossiblyNewRecords)
        {
 	        return foundPossiblyNewRecords.Count > 0;
        }

        protected abstract List<T> findAlreadyMigratedRecords(List<T> foundPossiblyNewRecords);

        public void migrateRecords()
        {
            foreach (var possiblyNewRecord in possiblyNewRecords)
            {
                if (shouldMigrateRecord(possiblyNewRecord))
                    migrateRecord(possiblyNewRecord);
            }
        }

        protected abstract void migrateRecord(T possiblyNewRecord);

        private bool shouldMigrateRecord(T possiblyNewRecord)
        {
            return !existingRecords.Contains(possiblyNewRecord);
        }
    }
}
