using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analyzator
{
    public class Analys
    {
        public static void FindVariables(string key)
        {
            Variables.VariableInt(key);
            Variables.VariableFloat(key);
            Variables.VariableChar(key);           
        }


        public static void FindAndAnalysFunc(string key)
        {
            FunctionAnalysis.FunctionDefinition(key);
        }


        public static void FindNumbers(string key)
        {
            Numbers.IsFractionalNumber(key);
            Numbers.IsInteger(key);
        }


        public static void FindSymbols(string key)
        {
            Symbols.IsSymbol(key);
        }


        public static void ArithmeticAnalysis( ref string key)
        {
            char[] symbols = key.ToCharArray();
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '=')
                {
                    Arithmetics.equality(ref key);
                }

                if (symbols[i] == '+')
                {
                    Arithmetics.addition(ref key);
                }

                if (symbols[i] == '-')
                {
                    Arithmetics.difference(ref key);
                }

                if (symbols[i] == '*')
                {
                    Arithmetics.multiplication(ref key);
                }

                if (symbols[i] == '/')
                {
                    Arithmetics.division(ref key);
                }
                continue;
            }
        }

        public static void ExceptionAnalys(string key)
        {
            Exceptions.Exception1(key);
            Exceptions.Exception2(key);
            Exceptions.Exception3(key);

        }
    }
}