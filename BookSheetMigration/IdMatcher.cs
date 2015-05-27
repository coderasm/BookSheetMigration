using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncPoco;

namespace BookSheetMigration
{
    public abstract class IdMatcher<T>
    {
        protected string query = "";

        protected AWGTransactionDTO transaction;

        public void matchAndInsertIds()
        {
            doMatch();
        }

        private void doMatch()
        {
            if (entityNumberExists())
            {
                var entityNumber = getEntityNumber();
                setIdIfOnlyOneFound(entityNumber);
            }
        }

        protected abstract bool entityNumberExists();

        protected abstract string getEntityNumber();

        private void setIdIfOnlyOneFound(string entityNumber)
        {
            var possibleEntities = findEntities(entityNumber).Result;
            if (foundAtLeastOneEntityIn(possibleEntities))
                setPossibleEntityId(possibleEntities[0]);
            setPossibleEntityIds(possibleEntities);

        }

        protected async Task<List<T>> findEntities(string entityNumber)
        {
            var entityDao = new EntityDAO<T>();
            var queryFilled = String.Format(query, entityNumber);
            return await entityDao.@select(queryFilled);
        }

        private bool foundAtLeastOneEntityIn(List<T> items)
        {
            return items.Count > 0;
        }

        protected abstract void setPossibleEntityId(T entity);

        protected abstract void setPossibleEntityIds(List<T> entities);
    }
}