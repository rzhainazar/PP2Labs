using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static bool Prostoe(int a)//фунция для проверки простого числа 
        {
            if (a == 1)
            {
                return false;
            }
            for(int i = 2; i <= Math.Sqrt(a); i++)//ещем делитель
            {
                if (a % i == 0)//если есть делитель то число не простое 
                    return false;
            }return true;//иначе оно простое
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine();//считываем стороку 
            string[] a = s.Split(' ');//разделяем по пробелам и помещаем в массив
            foreach(string t in a)//пробегаемся по каждому стрингу 
            {
                if (Prostoe(int.Parse(t)))//конвертируем числа из str в int и проверяем 
                    Console.WriteLine(t);//выводим если число простое
            }
            Console.ReadKey();
        }
    }
}
