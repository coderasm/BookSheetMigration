using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class IdInserter<T>
    {
        protected AWGTransactionDTO transaction;

        public void insertIdIfFound()
        {
            if (entityNumberExists())
            {
                var entityNumber = getEntityNumber();
                insertIdIfAtLeastOneFound(entityNumber);
            }
        }

        protected abstract bool entityNumberExists();

        protected abstract string getEntityNumber();

        private void insertIdIfAtLeastOneFound(string entityNumber)
        {
            var possibleEntities = findEntities(entityNumber).Result;
            if (foundAtLeastOneEntityIn(possibleEntities))
                setPossibleEntityId(possibleEntities[0]);

        }

        protected abstract Task<List<T>> findEntities(string entityNumber);

        private bool foundAtLeastOneEntityIn(List<T> items)
        {
            return items.Count > 0;
        }

        protected abstract void setPossibleEntityId(T entity);
    }
}
