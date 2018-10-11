using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Lab1;
using Algorithms.Lab2;
using Algorithms.Lab3;
using Xunit;
using Xunit.Abstractions;
using Student = Algorithms.Lab3.Student;

namespace Algorithms
{
    public class RunTest
    {
        private readonly ITestOutputHelper Console;

        public RunTest(ITestOutputHelper console)
        {
            Console = console;
        }
        
        [Fact]
        public void Lab1()
        {
            var node = new TreeNode();
            node.Insert(new Lab1.Student {Card = 4, City = City.Dnipro, Name = Guid.NewGuid().ToString(), Gender = Gender.Female, Year = 1});
            node.Insert(new Lab1.Student {Card = 10, City = City.Kyiv, Name = Guid.NewGuid().ToString(), Gender = Gender.Male, Year = 2});
            node.Insert(new Lab1.Student {Card = 3, City = City.Lviv, Name = Guid.NewGuid().ToString(), Gender = Gender.Female, Year = 3});
            node.Insert(new Lab1.Student {Card = 7, City = City.Kyiv, Name = Guid.NewGuid().ToString(), Gender = Gender.Male, Year = 4});
            node.Insert(new Lab1.Student {Card = 9, City = City.Kyiv, Name = Guid.NewGuid().ToString(), Gender = Gender.Female, Year = 5});
            node.Insert(new Lab1.Student {Card = 1, City = City.Vinnytsia, Name = Guid.NewGuid().ToString(), Gender = Gender.Male, Year = 5});

            var studentsAll = node.Across(node, s => s.City == City.Kyiv && s.Gender == Gender.Female && s.Year == 5).ToList();
            var studentsFound = node.Across(node, s => true).ToList();
            foreach (var n in studentsAll)
            {
                node.Remove(n);
            }
            var studentsAfterRemove = node.Across(node, s => true).ToList();

            Print("Before", studentsAll);
            Print("Found", studentsFound);
            Print("After remove", studentsAfterRemove);
        }

        [Fact]
        public void Lab2()
        {
            var bubble = new Bubble();

            Lab2.Student[][] students = {
                // PI-301z
                new[]
                {
                    new Lab2.Student{AverageMark = 54, FirstName = "A", LastName = "AA", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 32, FirstName = "B", LastName = "BB", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 83, FirstName = "C", LastName = "CC", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 65, FirstName = "D", LastName = "DD", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 43, FirstName = "E", LastName = "EE", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 43, FirstName = "F", LastName = "FF", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 71, FirstName = "G", LastName = "GG", Group = "PI-301z"},
                    new Lab2.Student{AverageMark = 11, FirstName = "H", LastName = "HH", Group = "PI-301z"},    
                },
                // PI-302z
                new[]
                {
                    new Lab2.Student{AverageMark = 53, FirstName = "S", LastName = "SS", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 31, FirstName = "T", LastName = "TT", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 85, FirstName = "U", LastName = "UU", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 67, FirstName = "V", LastName = "VV", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 42, FirstName = "W", LastName = "WW", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 42, FirstName = "X", LastName = "XX", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 75, FirstName = "Y", LastName = "YY", Group = "PI-301y"},
                    new Lab2.Student{AverageMark = 19, FirstName = "Z", LastName = "ZZ", Group = "PI-301y"},    
                },
            };

            var studentComparer = new Lab2StudentComparer();

            Print("Before", students[0]);
            var result = bubble.Sort(students[0], studentComparer);
            Print("After", result);

            var allStudents = new List<Lab2.Student>();

            foreach (var group in students)
            {
                foreach (var student in group)
                {
                    allStudents.Add(student);
                }
            }
            
            Print("Before", allStudents);
            result = bubble.Sort(allStudents.ToArray(), studentComparer);
            Print("After", result);
            
            
            Print("Before", students[0]);
            var heap  = new Heap<Lab2.Student>(students[0], studentComparer);
            heap.Sort();
            Print("After", heap.Array.ToArray());
        }

        [Fact]
        public void Lab3()
        {
            Student[] students =
            {
                new Student {AverageMark = 45, CanPlay = false, Firstname = "A", Surname = "AA"},
                new Student {AverageMark = 93, CanPlay = true, Firstname = "B", Surname = "BB"},
                new Student {AverageMark = 23, CanPlay = false, Firstname = "C", Surname = "CC"},
                new Student {AverageMark = 15, CanPlay = true, Firstname = "D", Surname = "DD"},
                new Student {AverageMark = 19, CanPlay = false, Firstname = "E", Surname = "EE"},
                new Student {AverageMark = 88, CanPlay = true, Firstname = "F", Surname = "FF"},
                new Student {AverageMark = 34, CanPlay = false, Firstname = "G", Surname = "GG"},
                new Student {AverageMark = 79, CanPlay = true, Firstname = "H", Surname = "HH"},
                new Student {AverageMark = 90, CanPlay = false, Firstname = "I", Surname = "II"},
                new Student {AverageMark = 57, CanPlay = true, Firstname = "J", Surname = "JJ"},
            };
            
            
            var interpolation = new Interpolation();
            var bubble = new Bubble();
            students = bubble.Sort(students, new Lab3StudentComparer());
            students = students.OrderBy(s => s.AverageMark).ToArray();

            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }

            int index = interpolation.Search(students, s => s.AverageMark, 57);
            if (index == -1)
            {
                Console.WriteLine("Nothing found.");                
            }
            else
            {
                Console.WriteLine($"Found: {students[index]}");
                List<Student> tmp = new List<Student>(students);
                tmp.RemoveAt(index);
                students = tmp.ToArray();
                
                foreach (var student in students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
        
        [Fact]
        public void ControlWork()
        
        private void Print(string message, IEnumerable<Lab2.Student> students)
        {
            Console.WriteLine($"{message}");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        private void Print(string message, IEnumerable<TreeNode> nodes)
        {
            Console.WriteLine($"{message}");
            foreach (var student in nodes.OrderBy(s => s.Student.Card).Select(s => s.Student))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}