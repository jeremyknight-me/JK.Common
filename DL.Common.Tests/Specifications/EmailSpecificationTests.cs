using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class EmailSpecificationTests
    {
        private EmailSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new EmailSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidEmailAddress_ReturnsTrue()
        {
            const string email = "someemail@domain.com";
            bool actual = this.specification.IsSatisfiedBy(email);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidEmailAddress_ReturnsFalse()
        {
            const string email = "some@email@domain.com";
            bool actual = this.specification.IsSatisfiedBy(email);
            Assert.IsFalse(actual);
        }
    }
}
