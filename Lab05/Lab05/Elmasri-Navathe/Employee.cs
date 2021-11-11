using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab05.Elmasri_Navathe
{
    [Serializable]
    public class Employee
    {
        [Key]
        // attributes
        public int Ssn { get; set; }
        public string FName { get; set; }
        public char MInit { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public float Salary { get; set; }
        public char Sex { get; set; }
        //relationships
        public Department WorksFor { get; set; }
        public Department Manages { get; set; }
        public List<WorksOn> WorksOn { get; set; }
        public List<Dependent> Dependents { get; set; }
        public Employee Supervisor { get; set; }
        public List<Employee> Supervisees { get; set; }

        public Employee(int ssn = 0, string fname = null, char minit = '0', string lname = null, string address = null, string dob = null, float salary = 0, char sex = '0')
        {
            Ssn = ssn;
            FName = fname;
            MInit = minit;
            LName = lname;
            Address = address;
            BirthDate = dob;
            Salary = salary;
            Sex = sex;
        }
    }
}
