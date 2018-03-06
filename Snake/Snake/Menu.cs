using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Snake
{
    class Menu
    {
        public static int maxLevel = 0, pos = -1, x = 1, y = 0, speed = 200, sc = 0, levelCount = 1, score = 0;
        public static Wall wall = new Wall();
        public static Snake snake = new Snake();
        public static bool playGame = true, moovable = false;
        public static Food food = new Food();
        public static ConsoleColor snakeBodyColor = ConsoleColor.Gray;
        public static ConsoleColor snakeHeadColor = ConsoleColor.Yellow;
        public void MoveSnakeThread()
        {
            speed = 200;
            playGame = true;
            Console.SetWindowSize(100, 31);
            food.x = 10;
            food.y = 10;
            wall.LoadLevel(levelCount);
            wall.Draw();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(10, 10);
            Console.Write('@');
            Console.ForegroundColor = ConsoleColor.Black;
            while (playGame == true)
            {
                moovable = false;
                if (snake.body[0].x == food.x && snake.body[0].y == food.y)
                {
                    snake.AddToBody();
                    food.NewPosition(snake.body, wall.body);
                    score++;
                    moovable = true;
                    speed = Math.Max(100, speed - 10);
                }
                if (score == 5 && levelCount == 1)
                {
                    x = 1;
                    y = 0;
                    levelCount++;
                    wall.LoadLevel(levelCount);
                    snake.body.Clear();
                    wall.Draw();
                    snake.body.Add(new Point(4, 3));
                    snake.body.Add(new Point(3, 3));
                    snake.body.Add(new Point(2, 3));
                }
                if (score == 10)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Your score is : ");
                    Console.WriteLine(score + sc);
                    Console.WriteLine("Press escape to continue");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }
                if (snake.CheckGame(wall.body) == true)
                {
                    Console.Clear();
                    playGame = false;
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Your score is : ");
                    Console.WriteLine(score + sc);
                    Console.WriteLine("Press escape to continue");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(food.x, food.y);
                Console.WriteLine("@");
                Console.SetCursorPosition(0, 23);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Score: ");
                Console.SetCursorPosition(7, 23);
                Console.Write(score);
                snake.Move(x, y, moovable);
                snake.Draw();
                Thread.Sleep(speed);
            }
        }
        public void OpenMenu()
        {
            int cursor = 0;
            List<string> menu = new List<string>();
            menu.Add("Start game");
            menu.Add("Exit");
            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == cursor)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(menu[i]);
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    cursor--;
                if (key.Key == ConsoleKey.DownArrow)
                    cursor++;
                if (cursor == -1)
                    cursor = 1;
                if (cursor == 2)
                    cursor = 0;
                Console.Clear();
                for (int i = 0; i < 2; i++)
                {
                    if (i == cursor)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(menu[i]);
                }
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    if (cursor == 1)
                    {
                        break;
                    }
                    if (cursor == 0)
                    {
                        x = 1; y = 0; sc = 0; levelCount = 1; score = 0;
                        wall = new Wall();
                        snake = new Snake();
                        playGame = true; moovable = false;
                        food = new Food();
                        Thread t = new Thread(MoveSnakeThread);
                        t.Start();
                        while (true)
                        {
                            ConsoleKeyInfo k = new ConsoleKeyInfo();
                            k = Console.ReadKey();
                            if (k.Key == ConsoleKey.Escape)
                                break;
                            if ((k.Key == ConsoleKey.UpArrow || k.Key == ConsoleKey.W))
                            {
                                y = -1;
                                x = 0;
                            }
                            if ((k.Key == ConsoleKey.DownArrow || k.Key == ConsoleKey.S))
                            {
                                y = 1;
                                x = 0;
                            }
                            if ((k.Key == ConsoleKey.LeftArrow || k.Key == ConsoleKey.A))
                            {
                                x = -1;
                                y = 0;
                            }
                            if (k.Key == ConsoleKey.RightArrow || k.Key == ConsoleKey.D)
                            {
                                x = 1;
                                y = 0;
                            }                           
                        }
                        Console.Clear();
                        playGame = false;
                    }
                }
            }
        }
    }
}
