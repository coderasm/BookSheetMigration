
namespace BookSheetMigration
{
    public class DealersFinder : EntitiesFinder<DealerDTO>
    {
        private const string dealerQuery = @"SELECT DISTINCT c.ACCOUNTNO, COMPANY
                                             FROM ABSContact..CONTACT2 c
                                             JOIN ABSContact..CONTACT1 c1 ON c1.ACCOUNTNO = c.ACCOUNTNO
                                             WHERE dbo.whoami(c.ACCOUNTNO) NOT LIKE '%-%' AND c.UDMVNUM LIKE '%{0}%' AND c.UDEALERCA1 = 'Active'";

        public DealersFinder(string id) : base(id)
        {
            this.query = dealerQuery;
        }
    }
}
