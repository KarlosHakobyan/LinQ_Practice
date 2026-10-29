using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    public class StudentModel
    {
        public StudentModel(string name, double grade)
        {
            Name = name;
            Grade = grade;
        }

        public string Name { get; set; }
        public double Grade { get; set; }
    }
}
