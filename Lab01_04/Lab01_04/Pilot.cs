using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_04
{
    public class Pilot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
        // Dành cho việc add Pilot (hàm tạo)
        public Pilot(string id = null, string name = "", double point = 0.0)
        {
            Id = id;
            Name = name;
            Point = point;
        }
    }
}
