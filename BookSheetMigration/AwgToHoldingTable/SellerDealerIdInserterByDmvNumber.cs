
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

        protected override bool entityArgumentsExist()
        {
            return transaction.sellerDmvNumber != null;
        }

        protected override object[] getEntityArguments()
        {
            return new object[]
            {
                transaction.sellerDmvNumber
            };
        }

        protected override async Task<List<DealerDTO>> findEntities(params object[] entityArguments)
        {
            var entitiesFinder = new DealersFinderByDmvNumber((string)entityArguments[0]);
            return await entitiesFinder.find();
        }

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.sellerDealerId = entity.dealerId;
        }
    }
}