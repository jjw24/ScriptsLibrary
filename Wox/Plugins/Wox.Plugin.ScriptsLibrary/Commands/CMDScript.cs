using System.Diagnostics;
using Wox.Plugin.ScriptsLibrary.Models;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    internal static class CMDScript
    {
        internal static void RunCMDFromFileLink(string scriptPath)
        {
            Process.Start(scriptPath);
        }
    }
}
