using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05.Elmasri_Navathe
{
    public class Project
    {
        // attributes
        public int PNumber { get; set; }
        public string PName { get; set; }
        public string Location { get; set; }
        // relationships
        public Department ControlledBy { get; set; }
        public List<WorksOn> WorksOn { get; set; }
    }
}
