using MongoDB.Driver;

namespace MongoDB_Sample
{
    public class MongoDataContext
    {
        public IMongoDatabase Database { get; }

        public MongoDataContext(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);

            IMongoClient client = new MongoClient(mongoUrl);
            Database = client.GetDatabase(mongoUrl.DatabaseName);
        }
    }
}
