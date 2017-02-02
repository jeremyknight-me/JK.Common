using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class InternetProtocolAddressSpecificationTests
    {
        private InternetProtocolAddressSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new InternetProtocolAddressSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidIp_ReturnsTrue()
        {
            const string ipAddress = "255.255.255.255";
            bool actual = this.specification.IsSatisfiedBy(ipAddress);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_AboveRange_ReturnsFalse()
        {
            const string ipAddress = "300.300.300.300";
            bool actual = this.specification.IsSatisfiedBy(ipAddress);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_NotEnoughSegments_ReturnsFalse()
        {
            const string ipAddress = "300.300.300.300";
            bool actual = this.specification.IsSatisfiedBy(ipAddress);
            Assert.IsFalse(actual);
        }
    }
}
