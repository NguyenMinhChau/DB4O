using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ADB2020MidTerm
{
    [Serializable]
    public class Company
    {
        [Key]
        public string MaCongTy { get; set; }
        public string MaSoThue { get; set; }
        public string TenCongTy { get; set; }
        public string SoNha { get; set; }
        public string DuongPho { get; set; }
        public string QuanHuyen { get; set; }
        public int SoLuongNhanVien => NhanViens != null ? NhanViens.Count : 0;
        //relationship
        public Employee GiamDoc { get; set; }
        public List<Employee> NhanViens { get; set; }

        public override string ToString()
        {
            return TenCongTy;
        }
        public Company(string id = null, string mst = null, string tct = null, string sn = null, string dp = null, string qh = null)
        {
            MaCongTy= id;
            MaSoThue = mst;
            TenCongTy = tct;
            SoNha = sn;
            DuongPho = dp;
            QuanHuyen = qh;
        }
    }
}
