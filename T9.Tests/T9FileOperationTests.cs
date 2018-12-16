using NUnit.Framework;
using System;
using System.IO;
using T9.Reader;

namespace T9.Tests
{
    [TestFixture]
    class T9FileOperationTests
    {
        [SetUp]
        public void RunBeforeAccessingAppPath()
        {
            var dirParent = Directory.GetParent(Path.GetDirectoryName(typeof(T9FileOperation).Assembly.Location)).Parent.Parent.FullName;
            dirParent = dirParent + "\\T9ParsingUI\\bin\\Debug";
            Environment.CurrentDirectory = dirParent;
            Directory.SetCurrentDirectory(dirParent);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void When_SaveOutputFile_NullContent_Expect_True(bool isLarge)
        {
            bool returnValue = T9FileOperation.SaveOutputFile(isLarge, null);

            Assert.IsTrue(returnValue == true);
        }

        [TestCase]
        public void When_GetLargeFileData_Expect_NonEmptyString()
        {
            string returnValue = T9FileOperation.GetLargeFileData();

            Assert.IsFalse(string.IsNullOrEmpty(returnValue));
        }

        [TestCase]
        public void When_GetSmallFileData_Expect_NonEmptyString()
        {
            string returnValue = T9FileOperation.GetSmallFileData();

            Assert.IsFalse(string.IsNullOrEmpty(returnValue));
        }
    }
}
