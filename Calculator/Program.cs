using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisião");
            Console.WriteLine("5 - Sair");
	        
            //adicionando comentario para o merge

            Console.WriteLine("----------------");
            Console.WriteLine("Selecione uma opção");
            short resultado = short.Parse(Console.ReadLine());

            
            switch(resultado)
            {
                case 1: Soma();
                        break;
                case 2: Subtracao();
                        break;
                case 3: Multiplicacao();
                        break;
                case 4: Divisao();
                        break;
                
                
                
                
                case 5: System.Environment.Exit(0);
                        break;
                default: Menu();
                        break;
            }
        }

        static void Soma(){

            Console.Clear();
            Console.WriteLine("Insira dois valores para operação: ");

            float valor1 = float.Parse(Console.ReadLine()); //Console.ReadLine recebe uma String
            float valor2 = float.Parse(Console.ReadLine());
            
            
            
            // Console.WriteLine("");//pular linha

            float resultado = valor1 + valor2;

            Console.WriteLine($"O resultado da soma é {resultado}"); //INTERPOLARIZAÇÃO DE STRING
            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            Console.Clear();
            Console.WriteLine("Insira dois valores para operação de subtração");
            float valor1 = float.Parse(Console.ReadLine());//Parse serve para converter texto ao tipo desejado
            float valor2 = float.Parse(Console.ReadLine());//Parse serve para converter texto ao tipo desejado
            
            float resultado = valor1 - valor2;
            
            
            

            Console.WriteLine("");
            Console.WriteLine("A subtração da soma eh: " + resultado);
            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();
            Console.WriteLine("Insiria dois valores para operação de divisão");
            float valor1 = float.Parse(Console.ReadLine());
            float valor2 = float.Parse(Console.ReadLine());

            bool ehValido = valor1 >= valor2;
            float? resultado = ehValido == true ? valor1 / valor2 : null;

            if(resultado != null) Console.WriteLine(resultado);
            else Console.WriteLine("O segundo valor não pode ser maior que o primeiro valor para esta operação");
            Console.ReadKey();
            Menu();
        }

        static void Multiplicacao()
        {
            Console.Clear();
            Console.WriteLine("Insiria dois valores para operação de multiplicação");
            float valor1 = float.Parse(Console.ReadLine());
            float valor2 = float.Parse(Console.ReadLine());

            float resultado = valor1 * valor2;

            Console.WriteLine(resultado);
            Console.ReadKey();
            Menu();
        }
    }
}
