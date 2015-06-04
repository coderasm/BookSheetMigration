using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    public abstract class IdInserter<T>
    {
        protected AWGTransactionDTO transaction;

        public bool insertIdIfFound()
        {
            if (entityArgumentsExist())
            {
                var entityArguments = getEntityArguments();
                return insertIdIfAtLeastOneFound(entityArguments);
            }
            return false;
        }

        protected abstract bool entityArgumentsExist();

        protected abstract object[] getEntityArguments();

        private bool insertIdIfAtLeastOneFound(params object[] entityArguments)
        {
            var possibleEntities = findEntities(entityArguments).Result;
            if (foundAtLeastOneEntityIn(possibleEntities))
            {
                setPossibleEntityId(possibleEntities[0]);
                return true;
            }
            return false;
        }

        protected abstract Task<List<T>> findEntities(params object[] entityArguments);

        private bool foundAtLeastOneEntityIn(List<T> items)
        {
            return items.Count > 0;
        }

        protected abstract void setPossibleEntityId(T entity);
    }
}
