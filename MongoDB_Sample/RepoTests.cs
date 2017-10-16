using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Sample
{
    [TestClass]
    public class RepoTests
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MongoDataContext("mongodb://localhost:27017/sampledb"));

        [TestInitialize]
        public async Task Initialize()
        {
            var serkan = new User()
            {
                FirstName = "SERKAN",
                LastName  = "BIRCAN",
                Email     = "serkan@siniradam.net"
            };

            await unitOfWork.Users.AddNewAsync(serkan);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await unitOfWork.Users.DeleteAllAsync();
        }

        [TestMethod]
        public void CheckConnection_When_Db_Available()
        {
            var isConnected = unitOfWork.CheckConnection();
            Assert.IsTrue(isConnected);
        }

        [TestMethod]
        public async Task GetByField_When_Its_Exist()
        {
            var users = await unitOfWork.Users.GetByFieldAsync("firstname", "SERKAN");
            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            // Arrange
            var users = await unitOfWork.Users.GetByFieldAsync("firstname", "SERKAN");
            var user = users.FirstOrDefault();

            // Act
            var isUpdated = await unitOfWork.Users.UpdateAsync(user.Id, "email", "serkanbircan21@outlook.com");

            // Assert
            users = await unitOfWork.Users.GetByFieldAsync("firstname", "SERKAN");
            user = users.FirstOrDefault();

            Assert.IsTrue(isUpdated);
            Assert.AreEqual("serkanbircan21@outlook.com", user.Email);

        }

    }
}
