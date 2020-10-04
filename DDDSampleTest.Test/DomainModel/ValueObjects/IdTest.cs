using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDDSample.DomainModel;

namespace DDDSampleTest.Test.DomainModel.ValueObjects
{
    [TestClass]
    public class IdTest
    {
        [TestMethod]
        public void EqualsTest()
        {
            var id1 = new Id("123");
            var id2 = new Id("123");

            (id1 == id2).IsTrue();
        }

        [TestMethod]
        public void NotEqualsTest()
        {
            var id1 = new Id("123");
            var id2 = new Id("124");

            (id1 == id2).IsFalse();
        }

        [TestMethod]
        public void NotEquals2Test()
        {
            var id1 = new Id("123");
            var id2 = new Id("124");

            (id1 != id2).IsTrue();
        }

        [TestMethod]
        public void ValidateTest()
        {
            try
            {
                var id1 = new Id("1234");
            }
            catch (Exception ex)
            {
                ex.Message.Is("Idは3文字でないといけません");
                return;
            }

            Assert.Fail();
        }
        
    }
}