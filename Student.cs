using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Student
    {
        public Student(int id , string name , int age , string group , double grade , bool isActive)
        {
            Id = id;
            Name = name;
            Age = age;
            Group = group;
            Grade = grade;
            IsActive = isActive;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public double Grade { get; set; }
        public bool IsActive { get; set; }

    }
}
