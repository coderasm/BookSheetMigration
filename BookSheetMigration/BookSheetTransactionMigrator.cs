using System;
using System.Collections.Generic;
using AsyncPoco;

namespace BookSheetMigration
{
    public class BookSheetTransactionMigrator : DataMigrator<AWGTransactionDTO>
    {
        private const string dateFormat = "yyyy-MM-dd HH:mm:ss";
        private DateTime yesterday = DateTime.Now.AddDays(-1);

        protected override List<AWGTransactionDTO> findPossiblyNewRecords()
        {
            var liveEvents = findEventsNotExpiredBy(yesterday);
            return findSalesInEvents(liveEvents);
        }

        private List<AWGEventDTO> findEventsNotExpiredBy(DateTime day)
        {
            var eventDao = createEventDao();
            var queryObject = Sql.Builder
                        .Select("*")
                        .From(Settings.ABSBookSheetEventTable)
                        .Where("EndTime > '" + day.ToString(dateFormat) + "'");
            return eventDao.@select(queryObject).Result;
        }

        private List<AWGTransactionDTO> findSalesInEvents(List<AWGEventDTO> liveEvents)
        {
            var serviceClient = new AWGServiceClient();
            var allTransactions = new List<AWGTransactionDTO>();
            foreach (var awgEvent in liveEvents)
            {
                var transactions = serviceClient.findTransactionsByStatusAndId(TransactionStatus.New, awgEvent.eventId);
                insertIdsIntoTransactions(transactions, awgEvent.eventId);
                allTransactions.AddRange(transactions);
            }
            return allTransactions;
        }

        private List<AWGTransactionDTO> insertIdsIntoTransactions(List<AWGTransactionDTO> transactions, int id)
        {
            transactions.ForEach(t =>
            {
                t.eventId = id;
                TransactionDealerIdsMatcher transactionDealerIdsMatcher = new TransactionDealerIdsMatcher(t);
                transactionDealerIdsMatcher.update();
            });
            return transactions;
        } 

        private EntityDAO<AWGEventDTO> createEventDao()
        {
            return new EntityDAO<AWGEventDTO>(new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName));
        }
    }
}
