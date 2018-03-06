using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Snake
{
    class Program
    {
        public static string login;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Write your login : ");
            login = Console.ReadLine();
            Console.Clear();
            Menu menu = new Menu();
            menu.OpenMenu();
        }
    }
}
