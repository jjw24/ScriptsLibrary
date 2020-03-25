using Newtonsoft.Json;
using System.Collections.Generic;
using Wox.Plugin.ScriptsLibrary.Models;

namespace Wox.Plugin.ScriptsLibrary
{
    public class Settings
    {
        [JsonProperty]
        public List<Script> ScriptList { get; set; } = new List<Script>();
    }
}
