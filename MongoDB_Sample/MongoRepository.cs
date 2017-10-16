using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_Sample
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> 
        where TEntity : EntityBase
    {
        protected abstract IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(MongoDataContext dataContext)
        {

        }
        public virtual async Task AddNewAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetByFieldAsync(string field, string value)
        {
            var filter = Builders<TEntity>.Filter.Eq(field, value);
            var result = await Collection.Find(filter).ToListAsync();

            return result;
        }

        public virtual async Task<TEntity> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var entity = await Collection.Find(filter).FirstOrDefaultAsync();

            return entity;
        }

        public virtual async Task<long> DeleteAllAsync()
        {
            var filter = new BsonDocument();
            var result = await Collection.DeleteManyAsync(filter);
            return result.DeletedCount;
        }

        public virtual async Task<bool> UpdateAsync(ObjectId id, string field, string value)
        {
            var update = Builders<TEntity>.Update.Set(field, value);
            var result = await Collection.UpdateOneAsync(u => u.Id == id, update);

            return result.ModifiedCount != 0;
        }
    }
}
