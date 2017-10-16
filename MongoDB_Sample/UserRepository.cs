using MongoDB.Driver;

namespace MongoDB_Sample
{
    public class UserRepository : MongoRepository<User>
    {
        private readonly MongoDataContext _dataContext;
        protected override IMongoCollection<User> Collection => _dataContext.Database.GetCollection<User>("users");

        public UserRepository(MongoDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}