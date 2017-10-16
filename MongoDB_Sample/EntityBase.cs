using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Sample
{
    public abstract class EntityBase
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}