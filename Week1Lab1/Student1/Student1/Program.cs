using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string name;
        public int age;
        public double GPA;

        public Student()
        {
            name = "Raiymbek";
            age = 17;
            GPA = 3.0;
        }

        public Student(string name, int age, double GPA)
        {
            this.name = name;
            this.age = age;
            this.GPA = GPA;
        }
        public override string ToString()
        {
            return name + " " + age + " " + GPA;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Raim",57, 3.2);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}