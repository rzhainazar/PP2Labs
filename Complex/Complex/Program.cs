using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int x, y;

        public Complex() { }

        public Complex(int a, int b)
        {
            x = a;
            y = b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex n = new Complex();
            n.x = c1.x + c2.x;
            n.y = c1.y + c2.y;
            return n;
        }

        public override string ToString()
        {
            return x + " " + y;
        }


        class Program
    {
        static void Main(string[] args)
        {
                Complex c1 = new Complex(7, 9);
                Complex c2 = new Complex(5, 8);
                Complex result = c1 + c2;
                Console.WriteLine(result);
            }
    }
}
