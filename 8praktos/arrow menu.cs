using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8praktos
{
    public static class ArrowMenu
    {
        public static int ShowMenu(List<MenuItem> options, string category)
        {
            Console.WriteLine($"{category}\n");

            int currentPosition = 0;

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine($"{category}\n");
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{(currentPosition == i ? "->" : "   ")} {options[i].Description}");
                }

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && currentPosition > 0)
                {
                    currentPosition--;
                }
                else if (key.Key == ConsoleKey.DownArrow && currentPosition < options.Count - 1)
                {
                    currentPosition++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }

            } while (key.Key != ConsoleKey.Enter);

            return currentPosition;
        }
    }
}
