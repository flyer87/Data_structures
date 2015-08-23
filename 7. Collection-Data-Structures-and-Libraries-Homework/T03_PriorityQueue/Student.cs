using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_PriorityQueue
{
    class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Student other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return "Name: " + this.Name + ", Age: " + this.Age;
        }
    }
}
