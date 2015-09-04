using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_Students_and_Courses
{
    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            return this.LastName.CompareTo(other.LastName);
        }
    }
}
