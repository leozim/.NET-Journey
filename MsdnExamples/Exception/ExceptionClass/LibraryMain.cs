using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClass
{
    public class LibraryMain
    {

        public static void Main(String[] args)
        {
            string s = "It was a cold day when...";
            string toFind = null;
            try
            {

                int[] indexes = Library.FindOccurrences(s, toFind);
                ShowOccurrences(s, "a", indexes);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                throw new MyInneException("Valor nulo!", toFind);
            }

        }

        public static void ShowOccurrences(string s, string toFind, int[] indexes)
        {
            Console.Write($"{toFind} occurs at the following character positions: ");
            for(int ctr = 0; ctr < indexes.Length; ctr++)
            {
                Console.Write("{0}{1}", indexes[ctr],
                                ctr == indexes.Length - 1 ? "" : ", ");
            }
            Console.WriteLine();
        }
    }
}
