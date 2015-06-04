using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration.AwgToHoldingTable
{
    class SellerDealerIdInserterByAddressAndCity : IdInserter<DealerDTO>
    {
        public SellerDealerIdInserterByAddressAndCity(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityArgumentsExist()
        {
            return transaction.sellerAddress != null && transaction.sellerCity != null;
        }

        protected override object[] getEntityArguments()
        {
            return new object[]
            {
                transaction.sellerAddress,
                transaction.sellerCity
            };
        }

        protected override async Task<List<DealerDTO>> findEntities(params object[] entityArguments)
        {
            var entitiesFinder = new DealersFinderByAddressAndCity((string)entityArguments[0], (string)entityArguments[1]);
            return await entitiesFinder.find();
        }

        protected override void setPossibleEntityId(DealerDTO entity)
        {
            transaction.buyerDealerId = entity.dealerId;
        }
    }
}
