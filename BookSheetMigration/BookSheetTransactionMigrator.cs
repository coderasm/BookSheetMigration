using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public class BookSheetTransactionMigrator : DataMigrator<AWGTransactionDTO>
    {

        protected override List<AWGTransactionDTO> findPossiblyNewRecords()
        {
            //Grab events whos (endTime + 1) is >= Now
            List<AWGEventDTO> mostRecentEvents = entityDao.
        }

        protected override bool recordExists(AWGTransactionDTO possiblyNewRecord)
        {
            throw new NotImplementedException();
        }

        public override Task migrateRecord(AWGTransactionDTO possiblyNewRecord)
        {
            throw new NotImplementedException();
        }
    }
}
