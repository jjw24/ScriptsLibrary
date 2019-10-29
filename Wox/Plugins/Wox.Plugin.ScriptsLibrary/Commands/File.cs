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
    }
}
