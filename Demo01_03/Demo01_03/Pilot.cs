using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01_03
{
    public class Pilot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }

        // Hàm tạo: Đối với String thì nenen để mặc định là null
        public Pilot(string id = null, string name = null, double point = 0.0)
        {
            Id = id;
            Name = name;
            Point = point;
        }
    }
}
