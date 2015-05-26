namespace BookSheetMigration
{
    class TransactionBuyerDealerIdMatcher : DealerIdMatcher
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

        protected override void setEntityId(DealerDTO entity)
        {
            transaction.buyerDealerId = entity.dealerId;
        }
    }
}