using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Student (string FirstName, string LastName, double Grade)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }
    }
}
