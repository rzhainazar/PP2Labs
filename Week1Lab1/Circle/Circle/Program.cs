using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Circle
    {
        public int r;
        public double area;
        public int diameter;

        public Circle()
        {
            r = 1; ;
        }
        public Circle(int r)
        {
            this.r = r;
        }

        public void FindArea()
        {
            area = Math.PI * r * r;
        }

        public void FindDiameter()
        {
            diameter = r * 2;
        }

        public override string ToString()
        {
            return "Area:" + area + ' ' + "Diameter:" + diameter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           // int k = int.Parse(Console.ReadLine());
            Circle c = new Circle();

            c.FindArea();
            c.FindDiameter();

            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
