using System.Diagnostics;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    public static class CMDScript
    {
        public static void RunCMDWithParameters(string scriptPath, string parameters)
        {
            Process.Start(scriptPath, parameters);
        }
    }
}
