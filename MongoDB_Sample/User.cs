using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Sample
{
    public class User : EntityBase
    {
        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}