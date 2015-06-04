using System.Collections.Generic;
using System.Threading.Tasks;
using BookSheetMigration.AwgToHoldingTable;

namespace BookSheetMigration
{
    public class BuyerDealersInserterByDmvNumber : CollectionInserter<DealerDTO>
    {
        public BuyerDealersInserterByDmvNumber(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityNumberExists()
        {
            return transaction.buyerDmvNumber != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.buyerDmvNumber;
        }

        protected override async Task<List<DealerDTO>> findEntities(string entityNumber)
        {
            var entitiesFinder = new DealersFinderByDmvNumber(entityNumber);
            return await entitiesFinder.find();
        }

        protected override void setPossibleCollection(List<DealerDTO> entity)
        {
            transaction.buyers = entity;
        }
    }
}
