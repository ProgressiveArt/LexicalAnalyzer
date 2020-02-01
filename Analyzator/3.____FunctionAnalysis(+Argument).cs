using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analyzator
{
    class FunctionAnalysis
    {
        public static void FunctionDefinition(string key)
        {
            Regex pattern = new Regex(@"([a-z_0-9]*)\((?<2>[^*/=();+.]*?)\)");
            Match match = pattern.Match(key);

            while (match.Success)
            {
                if (match.Groups[1].Value == string.Empty) break;
                if (!Variables.IntList.Contains(match.Groups[1].Value))
                {
                    Program.Writter("04 " + match.Groups[1].Value);
                    string[] ArgSplit = match.Groups[2].Value.Replace(", ", " ").Split(' ');

                    for (int i = 0; i < ArgSplit.Length; i++)
                    {
                        Exceptions.Exception6(ArgSplit[i]);
                        if (ArgSplit[i] == "") break;

                        if (ArgSplit[i] == "int")
                        {
                            i++;
                            
                            Program.Writter("08" + " " + ArgSplit[i]);
                        }

                        else if (ArgSplit[i] == "float")
                        {
                            i++;
                            Program.Writter("09" + " " + ArgSplit[i]);
                        }

                        else if (ArgSplit[i] == "char")
                        {
                            i++;
                            Program.Writter("10" + " " + ArgSplit[i]);
                        }

                        else
                        {
                            throw new ArgumentException("006 Argument type - '" + ArgSplit[i] + "' not specified. Error in line : " + key);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("005 Variable '" + match.Groups[1].Value + "' cannot be a function. Error in line : " + key);
                }
                match = match.NextMatch();
            }
        }
    }
}
