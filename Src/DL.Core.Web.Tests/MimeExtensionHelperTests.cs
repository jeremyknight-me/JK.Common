using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Web.Tests
{
    [TestClass]
    public class MimeExtensionHelperTests
    {
        [TestMethod]
        public void GetRequestContentType_InvalidExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.abcxyz");
            Assert.AreEqual("application/octet-stream", actual);
        }

        [TestMethod]
        public void GetRequestContentType_JpgExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.jpg");
            Assert.AreEqual("image/jpeg", actual);
        }

        [TestMethod]
        public void GetRequestContentType_JpegExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.jpeg");
            Assert.AreEqual("image/jpeg", actual);
        }

        [TestMethod]
        public void GetRequestContentType_PdfExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.pdf");
            Assert.AreEqual("application/pdf", actual);
        }

        [TestMethod]
        public void GetRequestContentType_DocExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.doc");
            Assert.AreEqual("application/msword", actual);
        }

        [TestMethod]
        public void GetRequestContentType_DocxExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.docx");
            Assert.AreEqual("application/vnd.openxmlformats-officedocument.wordprocessingml.document", actual);
        }

        [TestMethod]
        public void GetRequestContentType_XlsExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.xls");
            Assert.AreEqual("application/vnd.ms-excel", actual);
        }

        [TestMethod]
        public void GetRequestContentType_XlsmExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.xlsm");
            Assert.AreEqual("application/vnd.ms-excel.sheet.macroEnabled.12", actual);
        }

        [TestMethod]
        public void GetRequestContentType_XlsxExtention_CorrectMimeType()
        {
            string actual = MimeExtensionHelper.GetMimeType("file.xlsx");
            Assert.AreEqual("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", actual);
        }
    }
}
