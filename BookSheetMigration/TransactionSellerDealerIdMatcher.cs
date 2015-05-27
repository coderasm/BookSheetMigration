using System.Collections.Generic;

namespace BookSheetMigration
{
    public class TransactionSellerDealerIdMatcher : DealerIdMatcher
    {
        public TransactionSellerDealerIdMatcher(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
            query = dealerQuery;
        }

        protected override bool entityNumberExists()
        {
            return transaction.sellerNumber != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.sellerNumber;
        }

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.sellerDealerId = entity.dealerId;
        }

        protected override void setPossibleEntityIds(List<DealerDTO> entities)
        {
            transaction.sellers = entities;
        }
    }
}