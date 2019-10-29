using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Wox.Plugin.ScriptsLibrary.Models;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    internal static class File
    {
        //ToFinish
        internal static bool SomeSortOfValidation()
        {
            return false;
        }
                
        internal static List<Script> LoadFileLinkFromArray(this string[] arrayList)
        {
            var newList = new List<Script>();

            arrayList.ToList().ForEach(x => newList.Add(
                                                        new Script
                                                        {
                                                            Path = x
                                                        }));

            return newList;
        }

        public static void RunFileWithParameters(this string scriptPath, string parameters)
        {
            switch(GetScriptType(scriptPath))
            {
                case ScriptType.Cmd:
                    CMDScript.RunCMDFromFileLink(scriptPath, parameters);
                    break;
                case ScriptType.Powershell:
                    PsScript.Run(scriptPath, parameters);
                    break;
                default:
                    break;

            }
        }

        public static ScriptType GetScriptType(this string path)
        {
            var extension = System.IO.Path.GetExtension(path);

            switch (extension)
            {
                case ".ps1":
                    return ScriptType.Powershell;
                case ".bat":
                    return ScriptType.Cmd;
                default:
                    return ScriptType.Cmd;
            }
        }
    }
}
