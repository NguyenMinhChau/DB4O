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
        public string Ssn { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public double Salary { get; set; }
        public string Sex { get; set; }
        public char MInit { get; set; }
        //relationships
        public Department WorksFor { get; set; }
        public Department Manages { get; set; }
        public List<WorksOn> WorksOn { get; set; }
        public List<Dependent> Dependents { get; set; }
        public Employee Supervisor { get; set; }
        public List<Employee> Supervisees { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4} ({5})",FName,LName,Sex,BirthDate,Address,Salary);
        }

        public Employee(string ssn = null, string fname = null, char minit = '0', string lname = null, string address = null, string dob = null, 
            double salary = 0.0, string sex = null, Department wordfor = null, Department Manages = null, Employee Supervisor = null)
        {
            Ssn = ssn;
            FName = fname;
            LName = lname;
            Sex = sex;
            BirthDate = dob;
            Address = address;
            Salary = salary;
        }
    }
}
