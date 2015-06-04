
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSheetMigration.AwgToHoldingTable;

namespace BookSheetMigration
{
    public class SellerDealerIdInserterByDmvNumber : IdInserter<DealerDTO>
    {
        public SellerDealerIdInserterByDmvNumber(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityNumberExists()
        {
            return transaction.sellerDmvNumber != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.sellerDmvNumber;
        }

        protected override async Task<List<DealerDTO>> findEntities(string entityNumber)
        {
            var entitiesFinder = new DealersFinderByDmvNumber(entityNumber);
            return await entitiesFinder.find();
        }

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.sellerDealerId = entity.dealerId;
        }
    }
}