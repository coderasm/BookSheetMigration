using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncPoco;

namespace BookSheetMigration
{
    public class EntityDAO<T>
    {
        private Database databaseConnection;

        public EntityDAO(Database databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public async Task<List<T>> select()
        {
            await databaseConnection.FetchAsync<T>(entity);
        }

        public async Task update(T entity)
        {
            await databaseConnection.UpdateAsync(entity);
        }

        public async Task insert(T entity)
        {
            await databaseConnection.InsertAsync(entity);
        }

        public async Task<bool> exists(T entity)
        {
            return await databaseConnection.ExistsAsync(entity);
        }

        public async Task save(T entity)
        {
            if (exists(entity).Result)
                await update(entity);
            await insert(entity);
        }
    }
}
