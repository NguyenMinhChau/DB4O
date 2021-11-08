using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05.Elmasri_Navathe
{
    public class Dependent
    {
        // attributes
        public string Name { get; set; }
        public char Sex { get; set; }
        public string BirthDate { get; set; }
        public string Relationship { get; set; }
        // relationships
        public Employee DependentOf { get; set; }
    }
}
