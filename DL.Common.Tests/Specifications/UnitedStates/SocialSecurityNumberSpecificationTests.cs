using DL.Common.Specifications.UnitedStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications.UnitedStates
{
    [TestClass]
    public class SocialSecurityNumberSpecificationTests
    {
        [TestMethod]
        public void IsSatisfiedBy_NoFormatting_True()
        {
            this.RunTest("078051120", true);
        }

        [TestMethod]
        public void IsSatisfiedBy_Spaces_True()
        {
            this.RunTest("078 05 1120", true);
        }

        [TestMethod]
        public void IsSatisfiedBy_Dashes_True()
        {
            this.RunTest("078-05-1120", true);
        }

        [TestMethod]
        public void IsSatisfiedBy_Left800Less_True()
        {
            this.RunTest("899-05-1120", true);
        }

        [TestMethod]
        public void IsSatisfiedBy_NoFormatting_False()
        {
            this.RunTest("000000000", false);
        }

        [TestMethod]
        public void IsSatisfiedBy_Spaces_False()
        {
            this.RunTest("000 00 0000", false);
        }

        [TestMethod]
        public void IsSatisfiedBy_Dashes_False()
        {
            this.RunTest("000-00-0000", false);
        }

        [TestMethod]
        public void IsSatisfiedBy_MiddleAllZeroes_False()
        {
            this.RunTest("111-00-1111", false);
        }

        [TestMethod]
        public void IsSatisfiedBy_RightAllZeroes_False()
        {
            this.RunTest("111-11-0000", false);
        }

        [TestMethod]
        public void IsSatisfiedBy_Left666_False()
        {
            this.RunTest("666-12-4321", false);
        }

        [TestMethod]
        public void IsSatisfiedBy_Left900Plus_False()
        {
            this.RunTest("900-12-4321", false);
        }

        private void RunTest(string ssn, bool expected)
        {
            var specification = new SocialSecurityNumberSpecification();
            bool actual = specification.IsSatisfiedBy(ssn);
            Assert.AreEqual(expected, actual);
        }
    }
}
