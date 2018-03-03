using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader(@"C:\Raiymbek\PP2Labs\Week2Lab2\Lab2_1\input.txt");
           // string ss = sr.ReadToEnd();
            string str = File.ReadAllText(@"C:\Raiymbek\PP2Labs\Week2Lab2\Lab2_1\input.txt");
            //sr.Close();
            StreamWriter sw = new StreamWriter(@"C:\Raiymbek\PP2Labs\Week2Lab2\Lab2_1\output.txt");
            string[] arguments = str.Split();
            int ans = 99999;
            foreach (string s in arguments)
            {
                bool t = true;
                for (int i = 2; i <= Math.Sqrt(int.Parse(s)); i++)
                    if (int.Parse(s) % i == 0)
                        t = false;
                if (t == true && int.Parse(s) != 1)
                    ans = Math.Min(ans, int.Parse(s));
            }
            sw.WriteLine(ans);
            sw.Close();
        }
    }
    
}
