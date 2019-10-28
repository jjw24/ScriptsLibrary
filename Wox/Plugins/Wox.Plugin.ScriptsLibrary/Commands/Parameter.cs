using System.Collections.Generic;
using System.Linq;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    public static class Parameter
    {
        private static readonly char Seperator = ';';

        public static List<string> SplitString(string parameters) => parameters.Split(Seperator).ToList();

        public static bool ValidateString(string parameters)
        {
            bool result = true;

            if (string.IsNullOrEmpty(parameters))
                return true;

            // Empty parameter string is allowed as a default value or parameter not specified.
            if (!parameters.Contains(Seperator) && parameters == "")
                return false;

            if (parameters[parameters.Length - 1] == Seperator)
                return false;

            if (parameters[0] == Seperator)
                return false;

            return result;
        }
    }
}
