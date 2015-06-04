using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public class BuyerContactIdInserter : IdInserter<DealerContactDTO>
    {
        public BuyerContactIdInserter(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityArgumentsExist()
        {
            return transaction.buyerDealerId != null;
        }

        protected override object[] getEntityArguments()
        {
            return new object[]
            {
                transaction.buyerDealerId
            };
        }

        protected override async Task<List<DealerContactDTO>> findEntities(params object[] entityArguments)
        {
            var entitiesFinder = new DealerContactsFinder((string)entityArguments[0]);
            return await entitiesFinder.find();
        }

        protected override void setPossibleEntityId(DealerContactDTO entity)
        {
            transaction.buyerContactId = entity.contactId;
        }
    }
}
