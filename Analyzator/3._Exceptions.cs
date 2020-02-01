using System;
using System.Text.RegularExpressions;


namespace Analyzator
{
    class Exceptions
    {
        public static void Exception0(string line)
        {
            if (!line.Contains(";"))
            {
                throw new ArgumentException("001 Missing end of line character. Error in line : " + line);
            }
        }


        public static void Exception1(string line)
        {
            if (line.Contains("(") && !line.Contains(")"))
            {
                throw new ArgumentException("001 Missing closing bracket. Error in line : " + line);
            }


            else if (!line.Contains("(") && line.Contains(")"))
            {
                throw new ArgumentException("001 Missing opening bracket. Error in line : " + line);
            }
        }


        public static void Exception2(string line)
        {
            Regex pattern = new Regex(@"(([.+-/*])([=+-/*.]+))+");
            Match match = pattern.Match(line);

            while (match.Success)
            {
                throw new ArgumentException("002 Two operations can not go in a row. Error on '" + match.Groups[1].Value + "' in line : " + line);
            }
        }


        public static void Exception3(string line)
        {
            Regex pattern = new Regex(@"([=])([+*/])");
            Match match = pattern.Match(line);

            while (match.Success)
            {
                throw new ArgumentException("003 After '=' can not go immediately '+' | '*' | '/'. Error on '" + match.Groups[0].Value + "' in line : " + line);
            }
        }

        public static void Exception4(string line)
        {
            Regex pattern = new Regex(@"([0-9a-z]*)([=])([0-9a-z.'-]*)");
            Match match = pattern.Match(line);


            if (Variables.CharsList.Contains(match.Groups[1].Value) && Variables.IntList.Contains(match.Groups[3].Value))
            {
                throw new ArgumentException("007 You cannot assign a char value to a variable of another type.");
            }

            if (Variables.CharsList.Contains(match.Groups[1].Value) && Variables.FloatList.Contains(match.Groups[3].Value))
            {
                throw new ArgumentException("007 You cannot assign a char value to a variable of another type.");
            }

            if (Variables.IntList.Contains(match.Groups[1].Value) && Variables.CharsList.Contains(match.Groups[3].Value))
            {
                throw new ArgumentException("007 You cannot assign a int value to a variable of another type.");
            }

            if (Variables.IntList.Contains(match.Groups[1].Value) && Variables.FloatList.Contains(match.Groups[3].Value))
            {
                throw new ArgumentException("007 You cannot assign a int value to a variable of another type.");
            }

            if (Variables.FloatList.Contains(match.Groups[1].Value) && Variables.CharsList.Contains(match.Groups[3].Value))
            {
                throw new ArgumentException("007 You cannot assign a float value to a variable of char type.");
            }
        }

        public static void Exception5(string line)
        {
            Regex pattern = new Regex(@"([.]+[0-9]*[.]+[0-9]*)");
            Match match = pattern.Match(line);
            
            while (match.Success)
            {
                throw new ArgumentException("008 incorrect fractional number. In line : " + line);
            }
        }


        public static void Exception6(string line)
        {
            Regex pattern = new Regex(@"([!?.,><\|/':+)*&^%$#@№][}={]*)");
            //Regex pattern = new Regex(@"([a-z0-9_]*)");
            Match match = pattern.Match(line);

            while (match.Success)
            {
                throw new ArgumentException("008 incorrect identifier. In line : " + line);
            }
        }

        public static void Exception7(Match value)
        {
            if (value.Groups[1].Value == string.Empty && value.Groups[3].Value == string.Empty)
            {
                throw new ArgumentException("009 Variable and assigned value are not specified");
            }
            else if (value.Groups[1].Value != string.Empty && value.Groups[3].Value == string.Empty)
            {
                throw new ArgumentException("009 No variable is specified to which the value is assigned");
            }

            else if (value.Groups[3].Value == string.Empty && value.Groups[1].Value != string.Empty)
            {
                throw new ArgumentException("009 No value assigned");
            }
        }

        public static void Exception8(Match match)
        {          
           if (match.Groups[2].Value == string.Empty)
            {

                throw new ArgumentException("010 An arithmetic operation '" + match.Groups[1].Value + "' cannot end with an operation sign.");
            }           
        }

    }
}

