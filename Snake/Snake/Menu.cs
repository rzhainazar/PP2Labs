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
            int speedReturn = speed;
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
            int pos = -1;
            while (playGame)
            {
                for (int i = 0; i < highScores.name.Count; i++)
                {
                    if (highScores.name[i] == Program.login)
                    {
                        pos = i;
                        break;
                    }
                }
                if (pos == -1)
                {
                    highScores.name.Add(Program.login);
                    highScores.score.Add(0);
                    pos = highScores.name.Count - 1;
                }
                moovable = false;
                if (snake.body[0].x == food.x && snake.body[0].y == food.y)
                {
                    snake.AddToBody();
                    food.NewPosition(snake.body, wall.body);
                    score++;
                    moovable = true;
                    speed = Math.Max(100, speed - 10);
                }
                highScores.score[pos] = Math.Max(score + sc, highScores.score[pos]);
                if (score == 5 && levelCount < maxLevel)
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
                    score = 0;
                    sc = levelCount * 5 - 5;
                }
                if (score == 5 && levelCount == maxLevel)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Your score is : ");
                    Console.WriteLine(score + sc);
                    Console.Write("Your maximail score is : ");
                    Console.WriteLine(highScores.score[pos]);
                    Console.WriteLine("Press escape to continue");
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Console.ReadKey();
                    break;
                }
                if (snake.CheckGame(wall.body))
                {
                    Console.Clear();
                    playGame = false;
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Your score is : ");
                    Console.WriteLine(score + sc);
                    Console.Write("Your maximail score is : ");
                    Console.WriteLine(highScores.score[pos]);
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
            SaveHighScore(highScores);
            speed = speedReturn;
        }
        public static HighScores ShowLeaderBoard()
        {
            FileStream fs = new FileStream(@"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Snake\data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            HighScores highScores = bf.Deserialize(fs) as HighScores;
            fs.Close();
            return highScores;
        }
        public void SaveHighScore(HighScores highScores)
        {
            FileStream fs = new FileStream(@"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Snake\data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, highScores);
            fs.Close();
        }
        public HighScores Sort(HighScores highScores)
        {
            for (int i = 0; i < highScores.name.Count - 1; i++)
            {
                for (int j = i + 1; j < highScores.name.Count; j++)
                    if (highScores.score[i] < highScores.score[j])
                    {
                        string a = highScores.name[i];
                        int b = highScores.score[i];
                        highScores.name[i] = highScores.name[j];
                        highScores.score[i] = highScores.score[j];
                        highScores.name[j] = a;
                        highScores.score[j] = b;
                    }
            }
            return highScores;
        }
        public static HighScores highScores = ShowLeaderBoard();
        public void OpenMenu()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Levels");
            maxLevel = directoryInfo.GetFileSystemInfos().Length;
            int cursor = 0;
            List<string> menu = new List<string>();
            menu.Add("Start game");
            menu.Add("Leader board");
            menu.Add("Choose difficulty level");
            menu.Add("Exit");
            while (true)
            {
                for (int i = 0; i < 4; i++)
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
                    cursor = 3;
                if (cursor == 4)
                    cursor = 0;
                Console.Clear();
                for (int i = 0; i < 4; i++)
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
                        highScores = Sort(highScores);
                        for (int i = 0; i < highScores.name.Count; i++)
                        {
                            Console.Write(highScores.name[i]);
                            Console.Write(" - ");
                            Console.WriteLine(highScores.score[i]);
                        }
                        while(true)
                        {
                            ConsoleKeyInfo k = Console.ReadKey();
                            if (k.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    if (cursor == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Press button to choose difficulty level");
                        Console.Write("Easy   : ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("OO");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  --->  Q");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Normal : ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("OO");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("O");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  --->  W");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Hard   : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("OO");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("O");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  --->  E");
                        ConsoleKeyInfo k = Console.ReadKey();
                        if (k.Key == ConsoleKey.Q)
                        {
                            snakeBodyColor = ConsoleColor.Gray;
                            snakeHeadColor = ConsoleColor.Yellow;
                            speed = 200;
                        }
                        if (k.Key == ConsoleKey.W)
                        {
                            snakeBodyColor = ConsoleColor.Cyan;
                            snakeHeadColor = ConsoleColor.Magenta;
                            speed = 180;
                        }
                        if (k.Key == ConsoleKey.E)
                        {
                            snakeBodyColor = ConsoleColor.DarkCyan;
                            snakeHeadColor = ConsoleColor.Green;
                            speed = 160;
                        }
                        Console.Clear();
                    }
                    if (cursor == 3)
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
