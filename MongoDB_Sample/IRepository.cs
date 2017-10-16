using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_Sample
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task AddNewAsync(TEntity entity);
        Task<bool> UpdateAsync(ObjectId id, string field, string value);
        Task<TEntity> GetByIdAsync(ObjectId id);
        Task<IEnumerable<TEntity>> GetByFieldAsync(string field, string value);
        Task<long> DeleteAllAsync();
    }
}