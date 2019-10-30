using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace ScriptsLibrary.Tests
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
