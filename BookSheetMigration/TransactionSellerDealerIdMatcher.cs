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

        protected override void setEntityId(DealerDTO entity)
        {
            transaction.sellerDealerId = entity.dealerId;
        }
    }
}