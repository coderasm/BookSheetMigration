using System.Collections.Generic;
using System.Threading.Tasks;
using BookSheetMigration.AwgToHoldingTable;

namespace BookSheetMigration.HoldingTableToWebInterface
{
    class SellerDealersInserterByPhoneNumber : CollectionInserter<DealerDTO>
    {
        public SellerDealersInserterByPhoneNumber(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityNumberExists()
        {
            return transaction.sellerPhone != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.sellerPhone;
        }

        protected override async Task<List<DealerDTO>> findEntities(string entityNumber)
        {
            var entitiesFinder = new DealersFinderByPhoneNumber(entityNumber);
            return await entitiesFinder.find();
        }

        protected override void setPossibleCollection(List<DealerDTO> entity)
        {
            transaction.buyers = entity;
        }
    }
}
