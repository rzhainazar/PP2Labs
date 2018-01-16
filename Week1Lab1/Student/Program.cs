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
            name = "Olzhas";
            age = 17;
            GPA = 3.3;
        }

        public Student(string name, int age, int GPA)
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
            Student s = new Student();
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
