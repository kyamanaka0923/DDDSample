using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDDSample.DomainModel;

namespace DDDSampleTest.Test.DomainModel.ValueObjects
{
    [TestClass]
    public class PersonTypeTest
    {
        [TestMethod]
        public void NameTest()
        {
            var person = PersonType.Administrator;

            person.Name.Is("システム管理者");
        }

        [TestMethod]
        public void GetAllTest()
        {
            var persons = PersonType.GetAll<PersonType>();

            var ids = persons.Select(x => x.Id);
            ids.Count().Is(2);
            persons.Single(x => x.Id == 1).Name.Is("システム管理者");
            persons.Single(x => x.Id == 2).Name.Is("一般ユーザ");
        }

        [TestMethod]
        public void EqualsTest()
        {
            var admin = PersonType.Administrator;
            var admin2 = PersonType.Administrator;

            var user = PersonType.User;

            (admin == admin2).IsTrue();
            (admin != user).IsTrue();
        }
    }
}