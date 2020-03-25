using NUnit.Framework;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Tests
{
    [TestFixture]
    public class ScripRuntTests
    {
        [TestCase]
        public void RunCMDScriptTest()
        {
            CMDScript.RunCMDWithParameters("C:\\Users\\JJW\\Desktop\\Hello.bat", "JWU Blah");
        }

        [TestCase]
        public void RunPsScriptTest()
        {
            File.RunFileWithParameters("C:\\Users\\JJW\\Desktop\\hello PS.ps1", "JWU Blah");
        }
    }
}
