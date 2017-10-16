namespace MongoDB_Sample
{
    public class UnitOfWork
    {
        private readonly MongoDataContext _dataContext;

        public UserRepository Users { get; private set; }

        public UnitOfWork(MongoDataContext dataContext)
        {
            _dataContext = dataContext;

            Users = new UserRepository(dataContext);
        }

        public bool CheckConnection()
        {
            try
            {
                _dataContext.Database.ListCollections();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
