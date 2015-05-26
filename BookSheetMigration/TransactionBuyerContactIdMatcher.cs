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

        protected override void setEntityId(DealerContactDTO entity)
        {
            transaction.buyerContactId = entity.contactId;
        }
    }
}
