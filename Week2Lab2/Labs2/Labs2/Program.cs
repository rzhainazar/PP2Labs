using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs2
{

    class Program
    {
        static void Main(string[] args)
        { 
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int min = int.Parse(ss[0]);
            int max = int.Parse(ss[1]);
            foreach(string t in ss)
            {
                min = Math.Min(min, int.Parse(t));
                max = Math.Max(max, int.Parse(t));
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
