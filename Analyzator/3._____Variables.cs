using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Analyzator
{
    public static class Variables
    {
        public static List<string> IntList = new List<string>();
        public static List<string> CharsList = new List<string>();
        public static List<string> FloatList = new List<string>();


        public static void VariableDefinition(Regex pattern, string instruction, string number)
        {
            Match match = pattern.Match(instruction);
            
            while (match.Success)
            {
                if (!instruction.Contains("(") || !instruction.Contains(")"))
                {
                    if (instruction.Contains("char"))
                    {
                        string[] split = instruction.Trim().Replace(", ", " ").Split(' ');

                        for (int i = 1; i < split.Length; i++)
                        {
                            Exceptions.Exception6(split[i]);
                            Program.Writter(number + " " + split[i]);
                            CharsList.Add(split[i]);
                        }
                    }
                    if (instruction.Contains("int"))
                    {
                        string[] split = instruction.TrimStart().Replace(", ", " ").Split(' ');

                        for (int i = 1; i < split.Length; i++)
                        {
                            Exceptions.Exception6(split[i]);                            
                            Program.Writter(number + " " + split[i]);
                            IntList.Add(split[i]);
                        }
                    }

                    if (instruction.Contains("float"))
                    {
                        string[] split = instruction.TrimStart().Replace(", ", " ").Split(' ');

                        for (int i = 1; i < split.Length; i++)
                        {
                            Exceptions.Exception6(split[i]);
                            Program.Writter(number + " " + split[i]);
                            FloatList.Add(split[i]);
                        }
                    }
                }                
                match = match.NextMatch();
            }
        }

        public static void VariableInt(string key)
        {
            VariableDefinition(new Regex(@"\b(int)"), key, "01");
        }

        public static void VariableFloat(string key)
        {
            VariableDefinition(new Regex(@"\b(float)"), key, "02");
        }

        public static void VariableChar(string key)
        {
            VariableDefinition(new Regex(@"\b(char)"), key, "03");
        }
    }
}