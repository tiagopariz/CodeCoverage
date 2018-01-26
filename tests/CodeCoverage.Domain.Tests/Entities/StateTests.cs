using System;
using CodeCoverage.Domain.Entities;
using NUnit.Framework;

namespace CodeCoverage.Domain.Tests.Entities
{
    [TestFixture]
    public class StateTests
    {
        [Test]
        public void VerifyName()
        {
            var sut = new State(Guid.NewGuid(), "Test name");
            Assert.AreEqual("Test name", sut.Name);
        }
    }
}