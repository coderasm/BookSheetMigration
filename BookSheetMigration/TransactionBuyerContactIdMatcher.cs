using System.Collections.Generic;

namespace BookSheetMigration
{
    public class TransactionBuyerContactIdMatcher : ContactIdMatcher
    {
        public TransactionBuyerContactIdMatcher(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
            query = contactQuery;
        }

        protected override bool entityNumberExists()
        {
            return transaction.buyerDealerId != null;
        }

        protected override string getEntityNumber()
        {
            return transaction.buyerDealerId;
        }

        protected override void setPossibleEntityId(DealerContactDTO entity)
        {
            transaction.buyerContactId = entity.contactId;
        }

        protected override void setPossibleEntityIds(List<DealerContactDTO> entities)
        {
            transaction.buyerContacts = entities;
        }
    }
}
