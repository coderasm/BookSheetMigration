using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration.AwgToHoldingTable
{
    public class BuyerDealerIdInserterByPhoneNumber : IdInserter<DealerDTO>
    {
         public BuyerDealerIdInserterByPhoneNumber(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityNumberExists()
        {
            return transaction.buyerPhone != "";
        }

        protected override string getEntityNumber()
        {
            return transaction.buyerPhone;
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
