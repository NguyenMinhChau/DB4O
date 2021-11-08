using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05.Elmasri_Navathe
{
    public class Department
    {
        //attribute
        public int DNumber { get; set; }
        public string DName { get; set; }
        public List<string> Locations { get; set; }
        //relationships
        public List<Employee> Employees { get; set; }
        public Employee Manager { get; set; }
        public List<Project> Projects { get; set; }
        //on-to-many relationships
        public string MgrStartDate { get; set; }

    }
}
