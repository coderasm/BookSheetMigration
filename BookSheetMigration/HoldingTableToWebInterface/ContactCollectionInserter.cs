using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    abstract class ContactCollectionInserter
    {
        protected DealerDTO dealer;

        public void insertCollectionIfFound()
        {
            var entityNumber = getEntityNumber();
            insertCollectionIfAtLeastOneEntryFound(entityNumber);
        }

        protected abstract string getEntityNumber();

        private void insertCollectionIfAtLeastOneEntryFound(string entityNumber)
        {
            var possibleCollectionOfEntities = findEntities(entityNumber).Result;
            if (foundAtLeastOneEntityIn(possibleCollectionOfEntities))
                setPossibleCollection(possibleCollectionOfEntities);

        }

        protected abstract Task<List<DealerContactDTO>> findEntities(string entityNumber);

        private bool foundAtLeastOneEntityIn(List<DealerContactDTO> items)
        {
            return items.Count > 0;
        }

        protected abstract void setPossibleCollection(List<DealerContactDTO> entity);
    }
}
