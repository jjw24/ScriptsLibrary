using System;
using System.Collections.Generic;
using System.Linq;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    public static class Parameter
    {
        public static List<string> GetParametersFromFile(this string parameters) => parameters.Split(' ').ToList();

        public static int GetParametersFromFileCount(this string parameters)
        {
            if (string.IsNullOrEmpty(parameters))
                return 0;

            return GetParametersFromFile(parameters)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Count();
        }

        public static int GetParametersFromQueryCount(this string query)
        {
            if (!query.Contains(" " + Main.ParameterIndicator + " "))
                return 0;

            return GetParametersFromQuery(query)
                .Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .Count();
        }

        public static string GetParametersFromQuery(this string query)
        {
            if (!query.Contains(" " + Main.ParameterIndicator + " "))
                return string.Empty;

            var parameters = query.Split(new string[] { Main.ParameterIndicator }, StringSplitOptions.None)[1];

            var parameterString = parameters.Replace(Main.ParameterIndicator,"").Trim();

            return parameterString.Replace("\"", "'");            
        }

        public static bool IsRequiredParametersEntered(int queryParameters, int fileParameters)
        {
            if (queryParameters == fileParameters)
                return true;

            return false;
        }

        public static bool QueryParametersMatchFileParameters(this string query, string fileParameters)
        {
            return GetParametersFromQueryCount(query) == GetParametersFromFileCount(fileParameters);
        }
    }
}
