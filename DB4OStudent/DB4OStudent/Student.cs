using System;
using System.Collections.Generic;

namespace DB4OStudent
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegisterYear { get; set; }
        public DateTime DOB { get; set; }
        public int YearOld => DateTime.Now.Year - DOB.Year;

        public string StudentCode { get; set; }
        public List<Course> Course { get; set; }

        public Student(string id = null, string firstname = null, string lastname = null, int register = 0, string studentcode = null)
        {
            StudentId = id;
            FirstName = firstname;
            LastName = lastname;
            RegisterYear = register;
            StudentCode = studentcode;
        }
    }

    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
