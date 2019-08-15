using Newtonsoft.Json;
using System.Collections.Generic;
using Wox.Plugin.ScriptsLibrary.Models;

namespace Wox.Plugin.ScriptsLibrary
{
    public class Settings
    {
        public string Profile { get; set; }
        public string Region { get; set; }

        [JsonProperty]
        public List<FileLink> FolderLinks { get; set; } = new List<FileLink>();
    }
}
