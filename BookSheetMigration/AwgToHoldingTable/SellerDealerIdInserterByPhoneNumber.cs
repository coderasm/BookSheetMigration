using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration.AwgToHoldingTable
{
    class SellerDealerIdInserterByPhoneNumber : IdInserter<DealerDTO>
    {
         public SellerDealerIdInserterByPhoneNumber(AWGTransactionDTO transaction)
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

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.buyerDealerId = entity.dealerId;
        }
    }
}
