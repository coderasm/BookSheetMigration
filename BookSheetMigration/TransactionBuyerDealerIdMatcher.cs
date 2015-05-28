using System.Collections.Generic;

namespace BookSheetMigration
{
    public class TransactionBuyerDealerIdMatcher : DealerIdMatcher
    {

        public TransactionBuyerDealerIdMatcher(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
            query = dealerQuery;
        }

        protected override bool entityNumberExists()
        {
            return transaction.buyerNumber != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.buyerNumber;
        }

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.buyerDealerId = entity.dealerId;
        }

        protected override void setPossibleEntityIds(List<DealerDTO> entities)
        {
            transaction.buyers = entities;
        }
    }
}