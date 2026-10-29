using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class LinqLauncher
    {
        public static void Launch()
        {
            List<Student> students = new List<Student>
            {
              new (1, "Anna", 20, "A", 90, true),
              new (2, "David", 22, "B", 65, true),
              new (3, "Maria", 19, "A", 95, true),
              new (4, "John", 23, "C", 45, false),
              new (5, "Kate", 21, "B", 82, true),
              new (6, "Alex", 20, "A", 70, true),
              new (7, "Emma", 24, "C", 88, true),
              new (8, "Daniel", 18, "B", 55, false),
              new (9, "Sophia", 22, "A", 78, true),
              new (10, "Michael", 19, "C", 92, true)
            };

            Console.WriteLine("\n--------------------- STUDENTS LIST -------------------------\n");

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Group: {student.Group} Grade: {student.Grade}");
            }

            List<Student> filteredStudents = students.Where(e => e.IsActive).ToList();

            Console.WriteLine("\n--------------------- FILTERED STUDENTS BY ACTIVE -------------------------\n");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Group: {student.Group} Grade: {student.Grade}");
            }

            Console.WriteLine("\n--------------------- ORDERED STUDENTS BY DESCENDING-------------------------\n");

            List<Student> orderedStudents = students.OrderByDescending(e => e.Grade).ToList();
            foreach (var student in orderedStudents)
            {

                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            }

            Console.WriteLine("\n--------------------- NEW STUDENTS LIST BY SELECT-------------------------\n");

            List<StudentModel> newStudentsList = students
            .Select(e => new StudentModel(e.Name, e.Grade))
            .ToList();
            foreach (var student in newStudentsList)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            }


            Console.WriteLine("\n--------------------- STUDENTS FILTRATION BY ANY / ALL -------------------------\n");

            bool result = students.Any(e => e.Grade >= 90);
            Console.WriteLine(result);

            bool result2 = students.Where(s => s.IsActive).All(s => s.Grade > 40);

            //     bool result2 = students.All(e => e.Grade < 60 || e.IsActive);

            Console.WriteLine(result2);


            Console.WriteLine("\n--------------------- STUDENTS BY FIRSTORDEFAULT -------------------------\n");

            Student? firstStudent = students.FirstOrDefault(e => (e.Group == "A" && e.Grade > 85));

            if (firstStudent != null)
            {
                Console.WriteLine($"Name: {firstStudent.Name}, Grade: {firstStudent.Grade}");

            }
            else
            {
                Console.WriteLine("Student is not founded.");
            }


            Console.WriteLine("\n--------------------- STUDENTS COUNT / AVERAGE , MAX AND MIN USING -------------------------\n");

            Console.WriteLine($"Students count: {students.Count()}");
            Console.WriteLine($"Active students count: {students.Count(e => e.IsActive)}");
            Console.WriteLine($"Students average grade: {students.Average(e => e.Grade)}");
            Console.WriteLine($"Students Maximum Grade: {students.Max(e => e.Grade)} \nStudents Minimum Grade: {students.Min(e => e.Grade)}");

            Console.WriteLine("\n--------------------- GROUPBY USING -------------------------\n");

            var groupedStudents = students.GroupBy(e => e.Group);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"\n--- Students of group {group.Key} ---");

                foreach (var student in group)
                {
                    Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
                }

                Console.WriteLine($"\n--- Students count of group {group.Key} ---");
                Console.WriteLine(group.Count());

                Console.WriteLine($"\n--- Students average grade of group {group.Key} ---");
                Console.WriteLine(group.Average(e => e.Grade));
            }

            /* ALTERNATIVE VERSINON
              var groupedStudents = students
                .GroupBy(s => s.Group)
                .Select(g => new
                {
                 Group = g.Key,
                 Count = g.Count(),
                 AverageGrade = g.Average(s => s.Grade),
                 MaxGrade = g.Max(s => s.Grade)
                })
                .OrderBy(g => g.Group)
                .ToList();

                foreach (var group in groupedStudents)
                 {
                    Console.WriteLine(
                    $"Group: {group.Group}, " +
                    $"Count: {group.Count}, " +
                    $"Average: {group.AverageGrade:F2}, " +
                    $"Max: {group.MaxGrade}");
                 }*/


            Console.WriteLine("\n--------------------- TOP 3 STUDENTS BY GRADE -------------------------\n");

            var topStudents = students
                .Where(s => s.IsActive && s.Grade >= 70)
                .OrderByDescending(s => s.Grade)
                .Take(3)
                .Select(s => new
                {
                    s.Name,
                    s.Group,
                    s.Grade
                })
                .ToList();

            foreach (var student in topStudents)
            {
                Console.WriteLine(
                    $"Name: {student.Name}, " +
                    $"Grade: {student.Grade}, " +
                    $"Group: {student.Group}");
            }
        }
    }
}
