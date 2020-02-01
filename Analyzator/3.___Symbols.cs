using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzator
{
    class Symbols
    {
        public static List<string> SymbolsList = new List<string>();

        public static void IsSymbol(string key)
        {
            Regex pattern = new Regex(@"(\'(?<val>.?)\')");
            Match match = pattern.Match(key);

            while (match.Success)
            {
                SymbolsList.Add(match.Groups[1].Value);
                match = match.NextMatch();
            }
        }
    }
}
