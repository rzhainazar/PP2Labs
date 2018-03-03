using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        public int width;
        public int length;
        public int area;
        public int per;

        public Rectangle()
        {
            width = 0;
            length = 0;
        }
        public Rectangle(int a, int b)
        {
            width = b;
            length = a;
        }

        public void FindArea()
        {
            area = length * width;
        }

        public void FindPerim()
        {
            per = 2 * (length + width);
        }

        public override string ToString()
        {
            return "Area:" + area + ' ' + "Perimeter:" + per;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //string s = Console.ReadLine();
            //string[] par = s.Split(' ');
            int a = int.Parse(par[0]);
            int b = int.Parse(par[1]);

            Rectangle r = new Rectangle(a, b);

            r.FindArea();
            r.FindPerim();

            Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
