using System;

namespace HtmlEditor {

    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOptions(option);
        }

         public static void DrawScreen()
        {
            Console.Write("+");
            for (int i = 1; i <= 32; i++)
                Console.Write("-");
            Console.WriteLine("+");

            for (int i = 1; i <= 11; i++){
                Console.Write("|");
                for(int k = 1; k <= 32; k++)
                    Console.Write(" ");
                Console.WriteLine("|");
            }

            Console.Write("+");
            for (int i = 1; i <= 32; i++)
                Console.Write("-");
            Console.WriteLine("+");

        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3,1);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3,2);
            Console.WriteLine("============");
            Console.SetCursorPosition(3,3);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3,5);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3,6);
            Console.WriteLine("2 - Abrir arquivo");
            Console.SetCursorPosition(3,8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3,9);
            Console.WriteLine("Opção: ");
        }
    
        public static void HandleMenuOptions(short option)
        {
            switch(option)
            {
                case 1: Editor.Show(); break;
                case 2: Viewer.Show(""); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }

        }
    }
}