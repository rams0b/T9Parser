using NUnit.Framework;
using T9.Parser;

namespace T9.Tests
{
    [TestFixture]
    public class DictionarySearchTests
    {

        [TestCase(null)]
        [TestCase("")]
       public void When_InsertFromRaw_EmptyString_Expect_UserError(string emptystring)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(emptystring);

            Assert.IsTrue(dictionary.ToString().Contains("Empty string"));
        }

        [TestCase("1\n#$%^&&*(*^%^%(*(*&&*^&")]
        [TestCase("1\n5565465877899765757979")]
        public void When_InsertFromRaw_PassingInvalid_Expect_EmptyString(string invalidString)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(invalidString);

            Assert.IsTrue(dictionary.ToString() == string.Empty);
        }

        [TestCase("1")]
        public void When_InsertFromRaw_LengthWithNoData_Expect_UserError(string noData)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(noData);

            Assert.IsTrue(dictionary.ToString().Contains("Length provided but data missing"));
        }

        [TestCase("ABCHGYTYKLJKHJHGHJ")]
        public void When_InsertFromRaw_NoLength_Expect_UserError(string nolengthString)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(nolengthString);

            Assert.IsTrue(dictionary.ToString().Contains("Length not found"));
        }

        [TestCase("100000\nhello world")]
        public void When_InsertFromRaw_InvalidLength_Expect_UserError(string invalidLength)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(invalidLength);

            Assert.IsTrue(dictionary.ToString().Contains("Invalid length"));
        }

        [TestCase("1\nABCHGYTYKLJKHJHGHJ")]
        public void When_InsertFromRaw_UpperCase_Expect_CaseString(string upperCase)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(upperCase);

            Assert.IsFalse(dictionary.ToString() == string.Empty);
        }

        [TestCase("1\nhello world")]
        public void When_InsertFromRaw_ValidSingleString_Expect_CaseString(string singleString)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(singleString);

            Assert.IsTrue(dictionary.ToString() == "Case #1: 4433555 555666096667775553\r\n");
        }

        [TestCase("2\nhello world\nsomething else")]
        public void When_InsertFromRaw_ValidMultipleStrings_Expect_CaseString(string multistrings)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(multistrings);

            Assert.IsFalse(dictionary.ToString() == string.Empty);
        }

        [TestCase("1\nmalik")]
        public void When_ToString_Valid_Expect_CaseString(string validstring)
        {
            DictionarySearch dictionary = new DictionarySearch();
            dictionary.InsertFromRaw(validstring);

            Assert.IsFalse(dictionary.ToString() == string.Empty);
        }

        [TestCase()]
        public void When_ToString_EmptyObject_Expect_EmptyString()
        {
            DictionarySearch dictionary = new DictionarySearch();
   
            Assert.IsTrue(dictionary.ToString() == string.Empty);
        }
    }
}
