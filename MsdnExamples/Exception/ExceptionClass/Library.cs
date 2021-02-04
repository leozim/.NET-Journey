using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClass
{
    public static class Library
    {
        public static int[] FindOccurrences(string s, string f)
        {
            var indexes = new List<int>();
            int currentIndex = 0;
            try
            {
                while(currentIndex >= 0 && currentIndex < s.Length)
                {
                    currentIndex = s.IndexOf(f, currentIndex);
                    if(currentIndex >= 0)
                    {
                        indexes.Add(currentIndex);
                        currentIndex++;
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                // Perform some action here, such as logging this exeception.
                /*O THROW LANÇA A EXCEPTION CAPTURADA E SEM PERDER O STACKTRACE*/
                throw;
            }

            return indexes.ToArray();
        }

    }
}
