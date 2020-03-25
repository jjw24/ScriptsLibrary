using NUnit.Framework;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Test
{
    [TestFixture]
    public class CMDScriptTests
    {
        [TestCase]
        public void test()
        {
            CMDScript.RunCMDWithParameters("C:\\Users\\JJW\\Desktop\\Hello.bat", "JWU Blah");
        }
    }
}
