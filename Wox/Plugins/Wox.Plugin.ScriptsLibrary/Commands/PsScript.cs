using System.Diagnostics;
using System.Management.Automation;
using System.Threading;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    internal static class PsScript
    {
        internal static string RunAndReturnOutput(this string command, string workingDirectory)
        {
            var stringFromOutput = string.Empty;

            using (var powerShellInstance = PowerShell.Create())
            {
                powerShellInstance.AddScript($"cd \"{workingDirectory}\"");

                // execution with PowerShell 5, use pwsh.exe for PowerShell 6 (Core)
                powerShellInstance.AddScript(command);

                var outputCollection = new PSDataCollection<PSObject>();

                var result = powerShellInstance.BeginInvoke<PSObject, PSObject>(null, outputCollection);

                while (result.IsCompleted == false)
                {
                    Thread.Sleep(500);
                    // time out command?
                }

                foreach (PSObject outputItem in outputCollection)
                {
                    if (outputItem != null)
                        stringFromOutput += outputItem.ToString();
                }
            }

            return stringFromOutput;
        }

        internal static void RunPsWithParameters(string scriptPath, string parameters)
        {
            var arguments = $"-ExecutionPolicy Bypass \"{scriptPath} {parameters} ; Read-Host -Prompt \\\"Press Enter to exit\\\"\"";
            
            var info = new ProcessStartInfo
            {
                FileName = "Powershell.exe",
                Arguments = arguments,
            };

            Process.Start(info);
        }

        internal static void SetupEnvironment(string filePath)
        {
            var fileParams = string.Empty;
            var fileParams2 = string.Empty;
            var workingDirectory = ".\\Plugins\\Wox.Plugin.ScriptsLibrary\\Commands";
            var command = $"PowerShell -ExecutionPolicy Bypass -File \"{filePath}\"" + " " + fileParams + " " + fileParams2;
        }
    }
}
