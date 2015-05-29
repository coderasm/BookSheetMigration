
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public class BuyerContactsInserter : ContactCollectionInserter
    {
        public BuyerContactsInserter(DealerDTO buyer)
        {
            this.dealer = buyer;
        }

        protected override string getEntityNumber()
        {
            return dealer.dealerId;
        }

        protected override async Task<List<DealerContactDTO>> findEntities(string entityNumber)
        {
            var entitiesFinder = new DealerContactsFinder(entityNumber);
            return await entitiesFinder.find();
        }

        protected override void setPossibleCollection(List<DealerContactDTO> entity)
        {
            dealer.contacts = entity;
        }
    }
}
