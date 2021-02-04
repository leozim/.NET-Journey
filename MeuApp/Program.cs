using System;
using System.Text;

namespace MeuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // var id = Guid.NewGuid();
            // id.ToString();

            // id = new Guid(); //inicializa um Guid com zeros
            // id = new Guid("37936e0f-f519-4dc0-a94f-a2729cdfc19c");

            // Console.WriteLine(id);

            /*STRING*/

            // var price = 10.2;
            // var moeda = "Moeda";
            // // string text = "O preço do produto é: " + price;
            // // string text = String.Format("O preço de {1} do produto é {0}", price, moeda);
            // string text = $@"O preço do produto é {price}!"; //o @ ignora caracteres especiais como o '\n'

            /*COMPARAÇÃO DE TEXTO*/
            // string text = "Testando o .NET";
            // Console.WriteLine(text.CompareTo("testando"));
            // Console.WriteLine(text.Contains(".net", StringComparison.OrdinalIgnoreCase));
            // Console.WriteLine(text.trim()); //limpa os espaços do começo e do fim

            /*STRING BUILDER*/
            // var texto = new StringBuilder();
            // texto.Append("Este texto é um teste ");
            // texto.Append("viu?");
            // Console.WriteLine(texto);

            

        }
    }
}
