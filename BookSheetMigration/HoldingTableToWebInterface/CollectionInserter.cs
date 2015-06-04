using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class CollectionInserter<T>
    {
        protected AWGTransactionDTO transaction;

        public void insertCollectionIfFound()
        {
            if (entityArguemntsExist())
            {
                var entityArguments = getEntityArguments();
                insertCollectionIfAtLeastOneEntryFound(entityArguments);
            }
        }

        protected abstract bool entityArguemntsExist();

        protected abstract object[] getEntityArguments();

        private void insertCollectionIfAtLeastOneEntryFound(params object[] entityArguments)
        {
            var possibleCollectionOfEntities = findEntities(entityArguments).Result;
            if (foundAtLeastOneEntityIn(possibleCollectionOfEntities))
                setPossibleCollection(possibleCollectionOfEntities);

        }

        protected abstract Task<List<T>> findEntities(params object[] entityArguments);

        private bool foundAtLeastOneEntityIn(List<T> items)
        {
            return items.Count > 0;
        }

        protected abstract void setPossibleCollection(List<T> entity);
    }
}
