using System.Collections.Generic;
using System.Threading.Tasks;
using BookSheetMigration.AwgToHoldingTable;

namespace BookSheetMigration
{
    public class BuyerDealerIdInserterByDmvNumber : IdInserter<DealerDTO>
    {

        public BuyerDealerIdInserterByDmvNumber(AWGTransactionDTO transaction)
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

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.buyerDealerId = entity.dealerId;
        }
    }
}