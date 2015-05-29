﻿using System;
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
            var query = "SELECT * FROM " + Settings.ABSBookSheetEventTable + " WHERE EndTime >= '" + day.ToString(dateFormat) + "'";
            return eventDao.@select(query).Result;
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
                setEventId(id, t);
                setDealerIds(t);
                setContactIds(t);
            });
            return transactions;
        }

        private void setEventId(int id, AWGTransactionDTO t)
        {
            t.eventId = id;
        }

        private void setDealerIds(AWGTransactionDTO t)
        {
            var sellerDealerIdInserter = new SellerDealerIdInserter(t);
            sellerDealerIdInserter.insertIdIfFound();
            var buyerDealerIdInserter = new BuyerDealerIdInserter(t);
            buyerDealerIdInserter.insertIdIfFound();
        }

        private void setContactIds(AWGTransactionDTO t)
        {
            var buyerContactIdInserter = new BuyerContactIdInserter(t);
            buyerContactIdInserter.insertIdIfFound();
        }

        private EntityDAO<AWGEventDTO> createEventDao()
        {
            return new EntityDAO<AWGEventDTO>();
        }
    }
}