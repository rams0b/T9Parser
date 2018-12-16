using NUnit.Framework;
using T9.Reader;

namespace T9.Tests
{
    [TestFixture]
    class T9FileOperationTests
    {
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
