using System.Threading.Tasks;
using SQLite;
using XamApp.Constants;
using XamApp.Models.Entities;
using XamApp.Services.Interfaces;

namespace XamApp.Services
{
    public class DataStoreService<TEntity> : IDataStoreService<TEntity> where TEntity : IEntityRecord, new()
    {
        protected readonly SQLiteAsyncConnection Connection;

        public DataStoreService()
        {
            var conn = new SQLiteConnection(AppConstants.LocalDbFile);
            conn.CreateTable<TEntity>();
            Connection = new SQLiteAsyncConnection(AppConstants.LocalDbFile);
        }

        public AsyncTableQuery<TEntity> Query => Connection.Table<TEntity>();

        public virtual async Task InsertAsync(TEntity record)
        {
            await Connection.InsertAsync(record);
        }

        public virtual async Task UpdateAsync(TEntity record)
        {
            await Connection.UpdateAsync(record);
        }

        public virtual async Task DeleteAsync(TEntity record)
        {
            await Connection.DeleteAsync(record);
        }

        public virtual async Task DeleteAllAsync()
        {
            await Connection.DropTableAsync<TEntity>();
            await Connection.CreateTableAsync<TEntity>();
        }
    }
}
