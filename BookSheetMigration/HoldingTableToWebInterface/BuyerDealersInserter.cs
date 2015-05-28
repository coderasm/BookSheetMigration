
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public class BuyerDealersInserter : CollectionInserter<DealerDTO>
    {
        public BuyerDealersInserter(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityNumberExists()
        {
            return transaction.sellerNumber != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.sellerNumber;
        }

        protected override async Task<List<DealerDTO>> findEntities(string entityNumber)
        {
            var entitiesFinder = new DealersFinder(entityNumber);
            return await entitiesFinder.find();
        }

        protected override void setPossibleCollection(List<DealerDTO> entity)
        {
            transaction.buyers = entity;
        }
    }
}
