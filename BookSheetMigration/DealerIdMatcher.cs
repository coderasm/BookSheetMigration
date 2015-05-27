using System.Collections.Generic;

namespace BookSheetMigration
{
    public abstract class DealerIdMatcher : IdMatcher<DealerDTO>
    {
        protected const string dealerQuery = @"SELECT DISTINCT c.ACCOUNTNO, COMPANY
                                             FROM ABSContact..CONTACT2 c
                                             JOIN ABSContact..CONTACT1 c1 ON c1.ACCOUNTNO = c.ACCOUNTNO
                                             WHERE dbo.whoami(c.ACCOUNTNO) NOT LIKE '%-%' AND c.UDMVNUM LIKE '%{0}%' AND c.UDEALERCA1 = 'Active'";

        public List<DealerDTO> foundDealers
        {
            get
            {
                var entityNumber = getEntityNumber();
                return findEntities(entityNumber).Result;
            }
            private set { }
        }
    }
}
