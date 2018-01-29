using System;
using CodeCoverage.Domain.Entities;
using NUnit.Framework;

namespace CodeCoverage.Domain.Tests.Entities
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void VerifyName()
        {
            var sut = new Person(Guid.NewGuid(), "Test name", null, null, null, null);
            Assert.AreEqual("Test name", sut.Name);
        }

        [Test]
        public void VerifyId()
        {
            var sut = new Person(Guid.NewGuid(), "Test name", null, null, null, null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }
    }
}