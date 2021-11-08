using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05.Elmasri_Navathe
{
    public class WorksOn
    {
        // attribute
        public float Hours { get; set; }
        //owner attributes
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
