using System;
using System.Collections.Generic;
using System.Linq;

namespace Wox.Plugin.ScriptsLibrary.Commands
{
    public static class Parameter
    {
        public static List<string> GetParametersFromFile(this string parameters) => parameters.Split(Main.ParameterSeperator).ToList();

        public static int GetParametersFromFileCount(this string parameters)
        {
            if (string.IsNullOrEmpty(parameters))
                return 0;

            if (!parameters.Contains(Main.ParameterSeperator))
                return 0;

            return parameters
                    .Split(Main.ParameterSeperator)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Count();
        }

        public static int GetParametersFromQueryCount(this string query)
        {
            if (!query.Contains(" " + Main.ParameterIndicator + " "))
                return 0;

            var parameters = query.Split(new string[] { Main.ParameterIndicator }, StringSplitOptions.None)[1].Trim();

            return parameters
                .Split(Main.ParameterSeperator)
                .Where(x => !string.IsNullOrEmpty(x))
                .Count();
        }

        public static string GetParametersFromQuery(this string query)
        {
            if (!query.Contains(" " + Main.ParameterIndicator + " "))
                return string.Empty;

            var parameters = query.Split(new string[] { Main.ParameterIndicator }, StringSplitOptions.None)[1];

            var parameterString = parameters.Replace(Main.ParameterIndicator,"").Trim();

            return parameterString.Replace(Main.ParameterSeperator, ' ');
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

        public static bool ValidateString(string parameters)
        {
            bool result = true;

            if (string.IsNullOrEmpty(parameters))
                return true;

            // Empty parameter string is allowed as a default value or parameter not specified.
            if (!parameters.Contains(Main.ParameterSeperator) && parameters != string.Empty)
                return false;

            if (parameters[parameters.Length - 1] == Main.ParameterSeperator)
                return false;

            if (parameters[0] == Main.ParameterSeperator)
                return false;

            return result;
        }
    }
}
