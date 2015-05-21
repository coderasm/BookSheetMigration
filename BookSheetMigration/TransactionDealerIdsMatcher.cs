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

        private AWGTransactionDTO transaction;

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
            var sellerDealerId = findDealerId(transaction.sellerNumber);
            if (sellerDealerId.Result.Count == 1)
                transaction.sellerDealerId = sellerDealerId.Result[0];
        }

        private void setBuyingDealerIdIfOnlyOneFound()
        {
            var buyerDealerId = findDealerId(transaction.buyerNumber);
            if (buyerDealerId.Result.Count == 1)
                transaction.buyerDealerId = buyerDealerId.Result[0];
        }

        private async Task<List<string>> findDealerId(string dealerDmvNumber)
        {
            var database = new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
            var dealerIdQueryFilled = String.Format(dealerIdQuery, dealerDmvNumber);
            return await database.FetchAsync<string>(dealerIdQueryFilled);
        }

        private void setBuyingContactIdIfOnlyOneFount()
        {
            var buyerContactId = findContactId(transaction.buyerDealerId);
            if(buyerContactId.Result.Count == 1)
                transaction.buyerContactId = buyerContactId.Result[0];
        }

        private async Task<List<string>> findContactId(string dealerId)
        {
            var database = new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
            var dealerContactIdQueryFilled = String.Format(dealerContactIdQuery, dealerId);
            return await database.FetchAsync<string>(dealerContactIdQueryFilled);
        }
    }
}
