namespace BookSheetMigration
{
    public class DealersFinder : EntitiesFinder<DealerDTO>
    {
        protected const string dealerQuery = @"SELECT DISTINCT c.ACCOUNTNO, COMPANY
                                             FROM ABSContact..CONTACT2 c
                                             JOIN ABSContact..CONTACT1 c1 ON c1.ACCOUNTNO = c.ACCOUNTNO
                                             WHERE c1.COMPANY NOT LIKE '%- old%' AND c1.COMPANY NOT LIKE '%- dup%'";

        public DealersFinder(string key, string queryPartForKey) : base(key)
        {
            this.query = dealerQuery + queryPartForKey;
        }
    }
}
