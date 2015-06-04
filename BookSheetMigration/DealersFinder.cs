namespace BookSheetMigration
{
    public class DealersFinder : EntitiesFinder<DealerDTO>
    {
        protected const string dealerQuery = @"SELECT DISTINCT c1.ACCOUNTNO, COMPANY
                                             FROM ABSContact..CONTACT2 c2
                                             JOIN ABSContact..CONTACT1 c1 ON c1.ACCOUNTNO = c2.ACCOUNTNO
                                             WHERE c1.COMPANY NOT LIKE '%- old%' AND c1.COMPANY NOT LIKE '%- dup%'";

        public DealersFinder(string queryPart)
        {
            query = dealerQuery + queryPart;
        }
    }
}
