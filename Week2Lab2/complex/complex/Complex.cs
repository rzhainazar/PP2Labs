using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex
{
    [Serializable]
    class Complex
    {
        public int c1, c2;
        public Complex()
        {
            c1 = 0;
            c2 = 0;
        }
        public Complex(int _c1,int _c2)
        {
            c1 = _c1;
            c2 = _c2;
        }
        public static int gcd(int a, int b)//чтобы найти нод
        {
            if (b != 0)
                return gcd(b, a % b);
            else
                return a;
        }
        public static Complex operator +(Complex a, Complex b)
        {
            int Del = (a.c2 / (gcd(a.c2, b.c2))) * b.c2;
            a.c1 = (Del / a.c2) * a.c1;
            b.c1 = (Del / b.c2) * b.c1;
            Complex c = new Complex(a.c1 + b.c1, Del);
            return c;
        }
        public static Complex operator -(Complex a, Complex b)
        {
            int Del = (a.c2 / (gcd(a.c2, b.c2))) * b.c2;
            a.c1 = (Del / a.c2) * a.c1;
            b.c1 = (Del / b.c2) * b.c1;
            Complex c = new Complex(a.c1 - b.c1, Del);
            return c;
        }
        public static Complex operator *(Complex a, Complex b)
        {
            Complex c = new Complex(a.c1 * b.c1, a.c2 * b.c2);
            return c;
        }
        public static Complex operator /(Complex a, Complex b)
        {
            Complex c = new Complex(a.c1 * b.c2, a.c2 * b.c1);
            return c;
        }
        public void Simplify()//упращать два рациональных числа
        {
            int Del = gcd(c1, c2);
            c1 /= Del;
            c2 /= Del;
        }
        public override string ToString()
        {
            return c1 + "/" + c2;
        }
    }
}
