using Newtonsoft.Json;
using System;
using System.Linq;

namespace Wox.Plugin.ScriptsLibrary.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Script
    {
        [JsonProperty]
        public string Path { get; set; }

        [JsonProperty]
        public string FileName =>
           Path.Split(new[] { System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.None)
               .Last();

        [JsonProperty]
        public string Parameters { get; set; }

        /// <summary>
        /// Contains user added scripts
        /// </summary>
        /// <remarks>
        /// <para>UniqueIdentifier is the path</para>
        /// </remarks>
        [JsonProperty]
        public string UniqueIdentifier { get; set; }

        [JsonProperty]
        public string Description { get; set; }
    }

    public enum ScriptType
    {
        Cmd = 0,
        Powershell = 1
    }
}
