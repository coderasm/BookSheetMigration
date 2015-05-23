using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncPoco;

namespace BookSheetMigration
{
    public class TransactionDealerIdsMatcher
    {
        private const string dealerIdQuery = @"SELECT DISTINCT ACCOUNTNO
                                               FROM ABSContact..CONTACT2 c
                                               WHERE dbo.whoami(c.ACCOUNTNO) NOT LIKE '%-%' AND c.UDMVNUM LIKE '%{0}%' AND c.UDEALERCA1 = 'Active'";

        private const string dealerContactIdQuery = @"SELECT DISTINCT c.RECID
                                                FROM ABSContact..CONTACT2 c1
	                                                LEFT JOIN ABSContact..CONTSUPP c ON c.ACCOUNTNO = c1.ACCOUNTNO AND c.RECTYPE = 'C' AND c.TITLE = 'Used Car Manager' AND c1.UDEALERCA1 = 'Active'
                                                WHERE dbo.whoami(c1.ACCOUNTNO) NOT LIKE '%-%' AND c.ACCOUNTNO = '{0}'";

        private readonly AWGTransactionDTO transaction;

        public TransactionDealerIdsMatcher(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        public void update()
        {
            if(sellerDmvNumberExists())
                setSellingDealerIdIfOnlyOneFound();
            if(buyerDmvNumberExists())
                setBuyingDealerIdIfOnlyOneFound();
            if(buyerDealerIdWasFound())
                setBuyingContactIdIfOnlyOneFount();
        }

        private bool sellerDmvNumberExists()
        {
            return transaction.sellerNumber != "";
        }

        private bool buyerDmvNumberExists()
        {
            return transaction.buyerNumber != "";
        }

        private bool buyerDealerIdWasFound()
        {
            return transaction.buyerDealerId != null;
        }

        private void setSellingDealerIdIfOnlyOneFound()
        {
            var possibleDealerIds = findDealerIds(transaction.sellerNumber);
            if (foundOnlyOneIdIn(possibleDealerIds))
                transaction.sellerDealerId = possibleDealerIds.Result[0];
        }

        private static bool foundOnlyOneIdIn(Task<List<string>> possibleDealerIds)
        {
            return possibleDealerIds.Result.Count == 1;
        }

        private void setBuyingDealerIdIfOnlyOneFound()
        {
            var possibleDealerIds = findDealerIds(transaction.buyerNumber);
            if (foundOnlyOneIdIn(possibleDealerIds))
                transaction.buyerDealerId = possibleDealerIds.Result[0];
        }

        private async Task<List<string>> findDealerIds(string dealerDmvNumber)
        {
            var database = new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
            var dealerIdQueryFilled = String.Format(dealerIdQuery, dealerDmvNumber);
            return await database.FetchAsync<string>(dealerIdQueryFilled);
        }

        private void setBuyingContactIdIfOnlyOneFount()
        {
            var possibleContactIds = findContactId(transaction.buyerDealerId);
            if(foundOnlyOneIdIn(possibleContactIds))
                transaction.buyerContactId = possibleContactIds.Result[0];
        }

        private async Task<List<string>> findContactId(string dealerId)
        {
            var database = new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
            var dealerContactIdQueryFilled = String.Format(dealerContactIdQuery, dealerId);
            return await database.FetchAsync<string>(dealerContactIdQueryFilled);
        }
    }
}
