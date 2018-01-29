using System;
using CodeCoverage.Prompt.Dto;
using NUnit.Framework;

namespace CodeCoverage.Prompt.Tests.Dto
{
    [TestFixture]
    public class PersonDtoTests
    {
        [Test]
        public void VerifyName()
        {
            var sut = new PersonDto(Guid.NewGuid(), "Test name", null, null, null, null);
            Assert.AreEqual("Test name", sut.Name);
        }
    }
}