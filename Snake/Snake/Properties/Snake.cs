using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Properties
{
    class Snake
    {
        public void Draw()
        {
            int x = 0, y = 0;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine('O');
            while (true)
            {
                ConsoleKeyInfo k = new ConsoleKeyInfo();
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.UpArrow && y > 0)
                    y--;
                if (k.Key == ConsoleKey.DownArrow)
                    y++;
                if (k.Key == ConsoleKey.LeftArrow && x > 0)
                    x--;
                if (k.Key == ConsoleKey.RightArrow)
                    x++;
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine('O');
            }
        }
    }
}
