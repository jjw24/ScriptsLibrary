using Newtonsoft.Json;
using System;
using System.Linq;

namespace Wox.Plugin.ScriptsLibrary.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FileLink
    {
        [JsonProperty]
        public string Path { get; set; }

        public string FileName =>
           Path.Split(new[] { System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.None)
               .Last()
           + " (" + System.IO.Path.GetDirectoryName(Path) + ")";
    }
}
