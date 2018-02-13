using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void ShowDirectoryInfo(DirectoryInfo directoryInfo, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            FileSystemInfo[] fileSystemInfo = directoryInfo.GetFileSystemInfos();
            int index = -1;
            foreach (FileSystemInfo file in fileSystemInfo)
            {
                index++;
                if (file.GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                if (index == cursor)
                    Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(file.Name);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C: \Raiymbek\PP2Labs");
            int cursor = 0;
            bool t = true;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            foreach (FileSystemInfo file in directory.GetFileSystemInfos())
            {
                if (file.GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                if (t)
                    Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                t = false;
                Console.WriteLine(file.Name);
            }
            while (true)
            {
                int n = directory.GetFileSystemInfos().Length;
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    cursor--;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    cursor++;
                if (cursor == -1)
                    cursor = n - 1;
                if (cursor == n)
                    cursor = 0;
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (directory.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directory = new DirectoryInfo(directory.GetFileSystemInfos()[cursor].FullName);
                        n = directory.GetFileSystemInfos().Length;
                        cursor = 0;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directory.GetFileSystemInfos()[cursor].FullName);
                        try
                        {
                            Console.Clear();
                            string s = sr.ReadToEnd();
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(s);
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Отказано в доступе!");
                        }
                        finally
                        {
                            sr.Close();
                        }
                    }
                }

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (directory.Parent != null)
                    {
                        directory = directory.Parent;
                        n = directory.GetFileSystemInfos().Length;
                        cursor = 0;
                    }
                }
                ShowDirectoryInfo(directory, cursor);
            }
        }
    }
    
}
