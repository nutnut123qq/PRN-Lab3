using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{
    public class Student : IComparable<Student>
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }

        public int CompareTo(Student other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString() => $"ID: {ID}, Age: {Age}, FullName: {FullName}";
    }
}
