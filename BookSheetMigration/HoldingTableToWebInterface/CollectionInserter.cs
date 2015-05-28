using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class CollectionInserter<T>
    {
        protected AWGTransactionDTO transaction;

        public void insertCollectionIfFound()
        {
            if (entityNumberExists())
            {
                var entityNumber = getEntityNumber();
                insertCollectionIfAtLeastOneEntryFound(entityNumber);
            }
        }

        protected abstract bool entityNumberExists();

        protected abstract string getEntityNumber();

        private void insertCollectionIfAtLeastOneEntryFound(string entityNumber)
        {
            var possibleCollectionOfEntities = findEntities(entityNumber).Result;
            if (foundAtLeastOneEntityIn(possibleCollectionOfEntities))
                setPossibleCollection(possibleCollectionOfEntities);

        }

        protected abstract Task<List<T>> findEntities(string entityNumber);

        private bool foundAtLeastOneEntityIn(List<T> items)
        {
            return items.Count > 0;
        }

        protected abstract void setPossibleCollection(List<T> entity);
    }
}
