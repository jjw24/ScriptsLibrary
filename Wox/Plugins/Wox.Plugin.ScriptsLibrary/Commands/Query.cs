using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    public static class Query
    {
        public static string SeperateQueryFromParameters(this string query)
        {
            return query.Split(new string[] { Main.ParameterIndicator }, StringSplitOptions.None)[0].Trim();
        }
    }
}
