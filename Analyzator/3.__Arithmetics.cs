using System;
using System.Text.RegularExpressions;


namespace Analyzator
{
    class Arithmetics
    {
        public static void addition(ref string key)
        {
            CheckOperations(ref key, new Regex(@"([\+])((?:[0-9]*[.][0-9]*)|[0-9a-z]*)"));
        }
        public static void difference(ref string key)
        {
            CheckOperations(ref key, new Regex(@"([\-])((?:[0-9]*[.][0-9]*)|[0-9a-z]*)"));
        }
        public static void multiplication(ref string key)
        {
            CheckOperations(ref key, new Regex(@"([\*])((?:[0-9]*[.][0-9]*)|[0-9a-z]*)"));
        }
        public static void division(ref string key)
        {
            CheckOperations(ref key, new Regex(@"([\/])((?:[0-9]*[.][0-9]*)|[0-9a-z]*)"));
        }


        public static void CheckOperations(ref string key, Regex pattern)
        {
            if (key.Contains("'"))
            {
                throw new ArgumentException("004 The symbol \" '<val>' \" cannot be used in an arithmetic operation. Error on '");
            }

            Exceptions.Exception5(key);

            Match match = pattern.Match(key);

            Exceptions.Exception8(match);

            Program.Writter("11 " + match.Groups[1].Value);

            ChooseTokens(match.Groups[2].Value);
            key = key.Replace(match.Groups[0].Value, string.Empty);
        }


        public static void equality(ref string key)
        {
            Exceptions.Exception5(key);
            Regex pattern = new Regex(@"([a-z0-9_]*)([=])([0-9a-z.'-]*)");
            Match match = pattern.Match(key);

            while (match.Success)
            {
                Exceptions.Exception7(match);               
                Exceptions.Exception4(key);
                Exceptions.Exception5(match.Groups[1].Value);

                ChooseTokens(match.Groups[1].Value);

                Program.Writter("12 " + match.Groups[2].Value);

                ChooseActions(match.Groups[3].Value);

                match = match.NextMatch();
            }
        }


        public static void ChooseTokens(string value)
        {
            if (Numbers.Integers.Contains(value))
            {
                Program.Writter("05 " + value);
            }
            if (Numbers.Fractions.Contains(value))
            {
                Program.Writter("06 " + value);
            }

            if (Symbols.SymbolsList.Contains(value))
            {
                Program.Writter("07 " + value);
            }

            if (Variables.IntList.Contains(value) || Variables.CharsList.Contains(value) || Variables.FloatList.Contains(value))
            {
                Program.Writter("14 " + value);
            }
        }


        public static void ChooseActions(string value)
        {
            if (!value.Contains("-") && !value.Contains("'"))
            {
                ChooseTokens(value);
            }

            else if (value.Contains("-") && !value.Contains("'"))
            {
                ChooseTokens(value);
            }

            else if (!value.Contains("-") && value.Contains("'"))
            {
                ChooseTokens(value);
            }

            else if (value.Contains("-") && value.Contains("'"))
            {
                throw new ArgumentException("004 The character does not take value '-'");
            }
            else
            {
                ChooseTokens(value);
            }
        }
    }
}
