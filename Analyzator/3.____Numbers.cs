using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analyzator
{
    class Numbers
    {
        public static List<string> Integers = new List<string>();
        public static List<string> Fractions = new List<string>();

        public static void IsInteger(string instruction)
        {
            Regex pattern = new Regex(@"(\b\d[0-9]*)");
            Match match = pattern.Match(instruction);

            while (match.Success)
            {
                Integers.Add(match.Groups[1].Value);
                match = match.NextMatch();
            }
        }

        public static void IsFractionalNumber(string instruction)
        {
            Regex pattern = new Regex(@"(?:[0-9]*[.][0-9]*)");
            Match match = pattern.Match(instruction);

            while (match.Success)
            {
                Fractions.Add(match.Groups[0].Value);
                match = match.NextMatch();
            }
        }
    }
}
