using System;

namespace iofile
{
    internal class Program
    {
        private const string fileName = "planes.txt";

        private static void Main(string[] args)
        {
            infSystem infSystem = new infSystem("planes.txt");
            ConsoleKeyInfo consoleKey;
            do
            {
                Console.Clear();
                Console.WriteLine("Авиарейсы компании SibirAir:");
                Console.WriteLine("1. Вывести данные о авиарейсах.");
                Console.WriteLine("2. Добавить запись о авиарейсе.");
                Console.WriteLine("3. Удалить запись авиарейса.");
                Console.WriteLine("Esc. Выход.");
                consoleKey = Console.ReadKey();
                switch (consoleKey.KeyChar)
                {
                    case '1':
                        infSystem.outputMain();
                        break;
                    case '2':
                        infSystem.inputMain();
                        break;
                    case '3':
                        infSystem.deleteMain();
                        break;
                }
            }
            while (consoleKey.Key != ConsoleKey.Escape);
        }
    }
}
