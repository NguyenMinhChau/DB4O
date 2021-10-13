using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ADB2020MidTerm
{
    [Serializable]
    public class Employee
    {
        [Key]
        public string ID { get; set; }
        public string HoTen { get; set; }
        public string Skill { get; set; }
        public Company HomeBase { get; set; }
        public double Luong { get; set; }
        //relationship
        public Employee QuanLy { get; set; }
        public List<Employee> NhanViens { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1} ({2})", HoTen, Skill, Luong);
            
        }
        public Employee(string id = null, string ht = null, string skill = null, Company homebase = null, double luong = 0.0)
        {
            ID = id;
            HoTen = ht;
            Skill = skill;
            HomeBase = homebase;
            Luong = luong;
        }
    }
}
