using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Linq;


namespace Analyzator
{
    class Program
    {
        private static List<string> linesList = new List<string>();

        public static void Writter(string line)
        {
            linesList.Add(line);
        }

        static void Main(string[] args)
        {
            Console.SetBufferSize(200, 10000);
            if (File.Exists("../../CodeText.txt"))
            {
                using (StreamReader sr = new StreamReader("../../CodeText.txt", Encoding.Default))
                {
                    Writter(@"---------------------------------------------------Start analysis:---------------------------------------------------┐");
                    Writter("*********************************************************************************************************************|");
                    Writter("");
                    Writter("");

                    string lines;
                    while ((lines = sr.ReadLine()) != null)
                    {
                        string[] line = lines.ToLower().Split(';');
                        for (int i = 0; i < line.Length - 1; i++)
                        {
                            try
                            {
                                Exceptions.Exception0(lines);

                                Writter("String analysis: " + line[i]);
                                Writter("_____________________________________________________________________________________________________________________|");
                                Analys.ExceptionAnalys(line[i]);
                                Analys.FindVariables(line[i]);
                                Analys.FindAndAnalysFunc(line[i]);
                                Analys.FindNumbers(line[i]);
                                Analys.FindSymbols(line[i]);
                                Analys.ArithmeticAnalysis(ref line[i]);
                                Writter("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^|");
                                Writter("");
                                Writter("");
                            }
                            catch (Exception ex)
                            {
                                Writter("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!|");
                                Writter("");
                                Writter("Exception : " + ex.Message);
                                Writter("");
                                Writter("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!|");
                                Writter("");
                                Writter("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^|");
                                Writter("");
                                Writter("");
                            }
                        }
                    }
                    Writter("");
                    Writter("**********************************************************************************************************************|");
                    Writter("-------------------------------------------------Analysis complete----------------------------------------------------┘");

                    File.WriteAllLines("Result.txt", linesList);
                    linesList.ForEach(l => Console.WriteLine(l));
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No such file exists");
                Console.ReadKey();
            }
        }
    }
}