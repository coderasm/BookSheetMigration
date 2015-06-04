
namespace BookSheetMigration
{
    public class DealerContactsFinder : EntitiesFinder<DealerContactDTO>
    {
        private const string contactQuery = @"SELECT DISTINCT c.RECID, CONTACT, TITLE
                                              FROM ABSContact..CONTACT2 c1
	                                          LEFT JOIN ABSContact..CONTSUPP c ON c.ACCOUNTNO = c1.ACCOUNTNO AND c.RECTYPE = 'C'
                                              WHERE dbo.whoami(c1.ACCOUNTNO) NOT LIKE '%- old%' AND dbo.whoami(c1.ACCOUNTNO) NOT LIKE '%- dup%' AND c.ACCOUNTNO = '{0}'";

        public DealerContactsFinder(string key) : base(key)
        {
            this.query = contactQuery;
        }
    }
}
