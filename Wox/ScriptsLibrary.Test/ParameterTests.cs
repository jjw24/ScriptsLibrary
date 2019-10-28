using NUnit.Framework;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Test
{
    [TestFixture]
    public class ParameterTests
    {
        [TestCase("username;password;computer")]
        public void WhenGivenParameterStringThenShouldSplitStringsToListWithoutSeperator(string parameterString)
        {
            var result = Parameter.SplitString(parameterString);

            Assert.True(result.Count == 3);
            Assert.True(result[0] + ";"+ result[1] + ";"+ result[2] == parameterString);
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