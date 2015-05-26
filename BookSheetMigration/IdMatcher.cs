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

        protected void doMatch()
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
            if (foundOnlyOneEntityIn(possibleEntities))
                setEntityId(possibleEntities[0]);
        }

        public async Task<List<T>> findEntities(string entityNumber)
        {
            var database = new Database(Settings.ABSProductionDbConnectionString, Settings.ABSDatabaseProviderName);
            var queryFilled = String.Format(query, entityNumber);
            return await database.FetchAsync<T>(queryFilled);
        }

        private bool foundOnlyOneEntityIn(List<T> items)
        {
            return items.Count == 1;
        }

        protected abstract void setEntityId(T entity);
    }
}