
namespace BookSheetMigration
{
    public class DealerContactsFinder : EntitiesFinder<DealerContactDTO>
    {
        private const string contactQuery = @"SELECT DISTINCT c.RECID, CONTACT, TITLE
                                              FROM ABSContact..CONTACT2 c1
	                                          LEFT JOIN ABSContact..CONTSUPP c ON c.ACCOUNTNO = c1.ACCOUNTNO AND c.RECTYPE = 'C' AND c1.UDEALERCA1 = 'Active'
                                              WHERE dbo.whoami(c1.ACCOUNTNO) NOT LIKE '%-%' AND c.ACCOUNTNO = '{0}'";

        public DealerContactsFinder(string id) : base(id)
        {
            this.query = contactQuery;
        }
    }
}
