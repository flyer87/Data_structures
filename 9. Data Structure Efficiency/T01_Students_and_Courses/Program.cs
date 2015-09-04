using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;
using System.Text;

namespace T01_Students_and_Courses
{
    class Program
    {
        static OrderedDictionary<string, SortedSet<Student>> studentsByCourse =
                  new OrderedDictionary<string, SortedSet<Student>>();

        static void AddStudents()
        {            
            if (!File.Exists("StudentData.txt"))
            {
                throw new FileNotFoundException("StudentData.txt");
            }

            foreach (string line in File.ReadLines("StudentData.txt"))
            {
                string[] tokens = line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0].Trim();
                string lastName = tokens[1].Trim();
                string course = tokens[2].Trim();

                var student = new Student { FirstName = firstName, LastName = lastName };
                studentsByCourse.AppendValueToKey(course, student);
            }
        }

        static void PrintStudents()
        {
            StringBuilder result = new StringBuilder();
            foreach (KeyValuePair<string, SortedSet<Student>> students in studentsByCourse)
            {
                StringBuilder studentsAsString = new StringBuilder();
                foreach (var student in students.Value)
                {
                    studentsAsString.Append(student.FirstName + " " + student.LastName + ", ");
                }
                string course = students.Key + ": ";
                result.AppendLine(course + studentsAsString);
            }

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            AddStudents();
            PrintStudents();
        }
    }
}
