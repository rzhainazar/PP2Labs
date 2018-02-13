using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace complex
{
    class Program
    {
        static void f1(Complex ans)
        {
            FileStream fs = new FileStream(@"C:\Raiymbek\PP2Labs\Week2Lab2\complex\data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, ans);
            fs.Close();
        }
        static Complex f2()
        {
            FileStream fs = new FileStream(@"C:\Raiymbek\PP2Labs\Week2Lab2\complex\data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Complex ans = bf.Deserialize(fs) as Complex;
            fs.Close();
            return ans;
        }
        static void Main(string[] args)
        {
            Complex ans = new Complex(); ;
            Complex k = new Complex(0, 1);
            ans = f2();
            Console.WriteLine(ans);
            string x = Console.ReadLine();
            string[] xx = x.Split(' ');
            foreach(string s in xx)
            {
                string[] num = s.Split('/');
                Complex c = new Complex(int.Parse(num[0]), int.Parse(num[1]));
                if (ans.c2 == 0)
                    ans = c;
                else
                    ans += c;
            }
            ans.Simplify();
            f1(ans);
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
