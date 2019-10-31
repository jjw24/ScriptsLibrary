using NUnit.Framework;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Tests
{
    [TestFixture]
    public class ParameterTests
    {
        [TestCase("blah.bat -p username;password;computer","username password computer")]
        [TestCase("blah.bat -p username;"+"\""+"password 123" + "\"", @"username 'password 123'")]        
        public void WhenGivenQueryStringThenShouldReturnParametersOnly(string queryString, string expectedString)
        {
            var result = Parameter.GetParametersFromQuery(queryString);
                        
            Assert.True(result == expectedString);
        }

        [TestCase("blah.bat -p username;", 0)]
        [TestCase("blah.bat -p username; password;   computer", 3)]
        public void WhenGivenQueryStringWithInsufficientParametersThenShouldReturnExpectedNumber(string queryString, int expectedBoolResult)
        {
            var result = queryString.GetParametersFromQueryCount();

            Assert.True(result == expectedBoolResult);
        }

        [TestCase("username;password;computer", true)]
        [TestCase(";username;password;computer", false)]
        [TestCase(";", false)]
        [TestCase("username;password;computer;", false)]
        [TestCase(" ", false)]
        [TestCase("", true)]
        public void WhenGivenParameterStringThenShouldReturnExpectedBoolResult(string parameterString, bool expectedBoolResult)
        {
            var result = Parameter.ValidateString(parameterString);

            Assert.True(result == expectedBoolResult);
        }
    }
}
