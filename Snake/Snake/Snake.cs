using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public List <Point> body;
        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(4, 3));
            body.Add(new Point(3, 3));
            body.Add(new Point(2, 3));
        }
        public void Move(int x, int y, bool moovable)
        {
            int i = 1;
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            if (moovable == false)
                Console.Write(' ');
            Console.SetCursorPosition(body[0].x, body[0].y);
            Console.ForegroundColor = Menu.snakeBodyColor;
            Console.Write('O');
            for (i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x = body[0].x + x;
            body[0].y = body[0].y + y;
            if (body[0].x == -1)
                body[0].x = 63;
            if (body[0].x == 64)
                body[0].x = 0;
            if (body[0].y == -1)
                body[0].y = 22;
            if (body[0].y == 23)
                body[0].y = 0;
            
        }
        public void Draw()
        {
            Console.SetCursorPosition(body[0].x, body[0].y);
            Console.ForegroundColor = Menu.snakeHeadColor;
            Console.Write('O');
        }
        public void AddToBody()
        {
            Point p = new Point(body[body.Count - 1].x, body[body.Count - 1].y);//еще раз добавляем последнее значение 
            body.Add(p);
        }
        public bool CheckGame(List<Point> body1)
        {
            for (int i = 1; i < body.Count; i++)
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            for (int i = 0; i < body1.Count; i++)
                if (body[0].x == body1[i].x && body[0].y == body1[i].y)
                    return true;
            return false;
        }
    }
}
