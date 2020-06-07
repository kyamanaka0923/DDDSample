using DDDSample.DomainModel;
using DDDSample.Infrastructure;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDSampleTest.Test.Infrastructure
{
    [TestClass]
    public class UserInfrastructureSQLiteTest
    {
        private Mock<IConfigurationSection> section;
        private Mock<IConfiguration> configuration;

        private UserInfrastructureSQLite infrastructureSQLite;

        [TestInitialize]
        public void Initialize()
        {
            var section = new Mock<IConfigurationSection>();
            section.SetupGet(x => x[It.Is<string>(s => s == "Default")]).Returns("TestData/database.db");

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(section.Object);

            infrastructureSQLite = new UserInfrastructureSQLite(configuration.Object);
        }        

        [TestMethod]
        public void FindAll_Normal()
        {
            var users = infrastructureSQLite.FindAll();

            users.Count.Is(2);
            users.GetById(new Id("001")).Name.Value.Is("user1");
        }

        [TestMethod]
        public void FindById()
        {
            var user = infrastructureSQLite.FindById(new Id("001"));

            user?.Name.Value.Is("user1");
        }
        
    }
}