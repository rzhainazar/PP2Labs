using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Wall
    {
        public List<Point> body;
        public Wall()
        {
            body = new List<Point>();
        }
        public void LoadLevel(int level)
        {
            Console.Clear();
            body.Clear();
            string path = @"C:\Raiymbek\PP2Labs\Snake\Levels\Level";
            path += level.ToString() + ".txt";
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < 23; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == '#')
                        body.Add(new Point(j, i));
            }
            sr.Close();
        }
        public void Draw()
        {
            foreach(Point point in body)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#");
            }
        }
    }
}
