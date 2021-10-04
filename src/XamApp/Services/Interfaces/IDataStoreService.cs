using System.Threading.Tasks;
using SQLite;
using XamApp.Models.Entities;

namespace XamApp.Services.Interfaces
{
    public interface IDataStoreService<TEntity> where TEntity : IEntityRecord, new()
    {
        AsyncTableQuery<TEntity> Query { get; }
        Task InsertAsync(TEntity record);
        Task UpdateAsync(TEntity record);
        Task DeleteAsync(TEntity record);
        Task DeleteAllAsync();
    }
}
