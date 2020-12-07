using JK.Common.Contracts;
using JK.Common.Data.Ado.Auditing;
using Moq;
using System;
using Xunit;

namespace JK.Common.Tests.Data.Ado.Auditing
{
    public class XmlAuditingServiceTests
    {
        [Fact]
        public void AreEqual_SameObject_ArgumentException()
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now);
            var objectTwo = new ComplexObject(now);
            objectTwo = objectOne;
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var ex = Assert.Throws<ArgumentException>(() => auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo));
        }

        [Fact]
        public void AreEqual_BothNull_NullException()
        {
            ComplexObject objectOne = null;
            ComplexObject objectTwo = null;
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo));
        }

        [Fact]
        public void AreEqual_OneIsNotNullTwoIsNull_NullException()
        {
            var objectOne = new ComplexObject(DateTime.Now);
            ComplexObject objectTwo = null;
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo));
        }

        [Fact]
        public void AreEqual_OneIsNullTwoIsNotNull_NullException()
        {
            ComplexObject objectOne = null;
            var objectTwo = new ComplexObject(DateTime.Now);
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo));
        }

        [Fact]
        public void AreEqual_DifferentId_ArgumentException()
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { Id = 1 };
            var objectTwo = new ComplexObject(now) { Id = 2 };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var ex = Assert.Throws<ArgumentException>(() => auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        public void AreEqual_BooleanCompares(bool valueOne, bool valueTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { BooleanProperty = valueOne };
            var objectTwo = new ComplexObject(now) { BooleanProperty = valueTwo };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        [Theory]
        [InlineData(12.34, 12.34, true)]
        [InlineData(12.34, 56.78, false)]
        public void AreEqual_DecimalCompares(decimal valueOne, decimal valueTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { DecimalProperty = valueOne };
            var objectTwo = new ComplexObject(now) { DecimalProperty = valueTwo };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        [Theory]
        [InlineData(12.34, 12.34, true)]
        [InlineData(12.34, 56.78, false)]
        public void AreEqual_DoubleCompares(double valueOne, double valueTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { DoubleProperty = valueOne };
            var objectTwo = new ComplexObject(now) { DoubleProperty = valueTwo };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        [Theory]
        [InlineData(12.34, 12.34, true)]
        [InlineData(12.34, 56.78, false)]
        public void AreEqual_FloatCompares(float valueOne, float valueTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { FloatProperty = valueOne };
            var objectTwo = new ComplexObject(now) { FloatProperty = valueTwo };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        [Theory]
        [InlineData(1234, 1234, true)]
        [InlineData(1234, 5678, false)]
        public void AreEqual_IntCompares(int valueOne, int valueTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { IntProperty = valueOne };
            var objectTwo = new ComplexObject(now) { IntProperty = valueTwo };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        [Theory]
        [InlineData("foo", "foo", true)]
        [InlineData("foo", "hello", false)]
        public void AreEqual_StringCompares(string valueOne, string valueTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { StringProperty = valueOne };
            var objectTwo = new ComplexObject(now) { StringProperty = valueTwo };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        [Theory]
        [InlineData(3, "Three", 3, "Three", true)]
        [InlineData(3, "Three", 4, "False", false)]
        public void AreEqual_ChildObjectCompares(int idOne, string titleOne, int idTwo, string titleTwo, bool expected)
        {
            var now = DateTime.Now;
            var objectOne = new ComplexObject(now) { ChildObjectSimple = new SimpleObject { Id = idOne, Title = titleOne } };
            var objectTwo = new ComplexObject(now) { ChildObjectSimple = new SimpleObject { Id = idTwo, Title = titleTwo } };
            var auditRepo = new Mock<IAuditRepository>();
            var auditService = new XmlAuditingService(auditRepo.Object);
            var actual = auditService.AreEqual<int, ComplexObject>(objectOne, objectTwo);
            Assert.Equal(expected, actual);
            this.AssertAuditRecord(auditService.Record, objectOne);
        }

        private void AssertAuditRecord(AuditRecord record, IIdentifiable<int> entity)
        {
            Assert.Equal(entity.Id.ToString(), record.ObjectId);
            Assert.Equal("JK.Common.Tests.ComplexObject", record.ObjectName);
        }
    }
}
