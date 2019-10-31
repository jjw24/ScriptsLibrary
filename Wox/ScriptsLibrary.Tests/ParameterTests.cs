using NUnit.Framework;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Tests
{
    [TestFixture]
    public class ParameterTests
    {
        [TestCase("blah.bat -p username password computer","username password computer")]
        [TestCase("blah.bat -p username "+"\""+"password 123" + "\"", @"username 'password 123'")]        
        public void WhenGivenQueryStringThenShouldReturnParametersOnly(string queryString, string expectedString)
        {
            var result = Parameter.GetParametersFromQuery(queryString);
                        
            Assert.True(result == expectedString);
        }

        [TestCase("blah.bat -p username", 1)]
        [TestCase("blah.bat -p ", 0)]
        [TestCase("blah.bat -p username password   computer", 3)]
        public void WhenGivenQueryStringThenShouldReturnExpectedNumberOfParameters(string queryString, int expectedBoolResult)
        {
            var result = queryString.GetParametersFromQueryCount();

            Assert.True(result == expectedBoolResult);
        }
    }
}
