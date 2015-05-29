
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

        protected override bool entityNumberExists()
        {
            return transaction.buyerDealerId != null;
        }

        protected override string getEntityNumber()
        {
            return transaction.buyerDealerId;
        }

        protected override async Task<List<DealerContactDTO>> findEntities(string entityNumber)
        {
            var entitiesFinder = new DealerContactsFinder(entityNumber);
            return await entitiesFinder.find();
        }

        protected override void setPossibleEntityId(DealerContactDTO entity)
        {
            transaction.buyerContactId = entity.contactId;
        }
    }
}
