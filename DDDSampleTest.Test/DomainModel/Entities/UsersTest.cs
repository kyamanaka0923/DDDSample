using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDDSample.DomainModel;

namespace DDDSampleTest.Test.DomainModel.Entities
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void GetByIdTest()
        {
            var user1 = new User(new Id("001"), new Name("user1"));
            var user2 = new User(new Id("002"), new Name("user2"));

            var users = new Users();

            users.Add(user1);
            users.Add(user2);

            users.Count.Is(2);
            var responseUser = users.GetById(new Id("001"));
            responseUser.Name.Value.Is("user1");

        }
        
    }
}