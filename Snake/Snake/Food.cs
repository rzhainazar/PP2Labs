using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public int x, y;
        public Food()
        {
            x = new Random().Next(1, 63);
            y = new Random().Next(1, 21);
        }
        public void NewPosition(List <Point> body, List<Point> body1)
        {
            while (true)
            {
                bool k = false;
                x = new Random().Next(1, 63);
                y = new Random().Next(1, 21);
                foreach (Point point in body)
                {
                    if (x == point.x && y == point.y)
                        k = true;
                }
                foreach (Point point in body1)
                {
                    if (x == point.x && y == point.y)
                        k = true;
                }
                if (k == false)
                    break;
            }
        }
    }
}