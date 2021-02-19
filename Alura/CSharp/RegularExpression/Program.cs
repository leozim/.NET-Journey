using System;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string texto = "O numero de cerular do leozim eh: 9665-6968";
            // Console.WriteLine(Regex.Match(texto, padrao));

            // var padrao = "[0-9]{4}[-][0-9]{4}";
            // string texto = "O numero de cerular do leozim eh: 9665-6968";
            // Match match = Regex.Match(texto, padrao);
            // Console.WriteLine(match.Value);

            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string texto = "O numero de cerular do leozim eh: 99665-6968";
            Match match = Regex.Match(texto, padrao);
            Console.WriteLine(match.Value);
        }
    }
}