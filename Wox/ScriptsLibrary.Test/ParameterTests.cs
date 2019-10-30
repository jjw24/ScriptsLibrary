using NUnit.Framework;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Test
{
    [TestFixture]
    public class ParameterTests
    {
        [TestCase("blah.bat -p username;password;computer")]
        public void WhenGivenQueryStringThenShouldReturnParametersOnly(string queryString)
        {
            var result = Parameter.GetParametersFromQuery(queryString);

            //Assert.True(result.Count == 3);
            Assert.True(result== "username password computer");
        }

        [TestCase("blah.bat -p username;", 0)]
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