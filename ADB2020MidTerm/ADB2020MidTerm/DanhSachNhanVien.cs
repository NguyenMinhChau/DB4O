using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Db4objects.Db4o.Linq;
using System.Linq;
using System.Windows.Forms;

namespace ADB2020MidTerm
{
    public partial class DanhSachNhanVien : Form
    {
        public DanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            
            var result = from Company cty in Database.DB
                         select cty;

            cbCongTyNV.DataSource = result.ToList();
            cbCongTyNV.DisplayMember = "TenCongTy";
            cbCongTyNV.ValueMember = "MaCongTy";
            LayDanhSachNhanVien();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            var congTy = from Company cty in Database.DB
                         where cty.MaCongTy == cbCongTyNV.SelectedValue.ToString()
                         select cty;
            var nhanvien = new Employee
            {
                ID = Guid.NewGuid().ToString(),
                HoTen = txtTenNV.Text,
                Luong = double.Parse(txtLuong.Text),
                Skill = txtSkill.Text,
                HomeBase = congTy.ToList()[0]
            };
            Database.Store(nhanvien);
            LayDanhSachNhanVien();
        }

        private void LayDanhSachNhanVien()
        {
            //Linq
            //var nhanvien = from Employee nv in Database.DB
            //select nv;
            //dgvNhanVien.DataSource = nhanvien.ToList();
            var filterObj = new Employee();
            var reusult = Database.DB.QueryByExample(filterObj);
            dgvNhanVien.DataSource = reusult.ToList();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSkill.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLuong.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbCongTyNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để update
            var filterObj = new Employee(txtMaNV.Text);
            var result = (Employee)Database.DB.QueryByExample(filterObj)[0];
            // Gán lại giá trị
            result.HoTen = txtTenNV.Text;
            result.Skill = txtSkill.Text;
            result.Luong = double.Parse(txtLuong.Text);
            //Store DB
            Database.DB.Store(result);
            // Load lại data
            LayDanhSachNhanVien();
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để delete
            var filterObj = new Employee();
            var result = (Employee)Database.DB.QueryByExample(filterObj)[0];
            // Delete Db
            Database.Delete(result);
            // Load lại DB
            LayDanhSachNhanVien();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Đi tìm gần đúng: Cụ thể theo tên
            var result = Database.DB.Query<Employee>(delegate (Employee nv) {
                return nv.HoTen.ToLower().Contains(txtTenNV.Text.ToLower());
            });
            // Trả về kết quả
            dgvNhanVien.DataSource = result.ToList();
        }

        private void btnLoadNV_Click(object sender, EventArgs e)
        {
            LayDanhSachNhanVien();
            txtLuong.Text = "";
            txtMaNV.Text = "";
            txtSkill.Text = "";
            txtTenNV.Text = "";
        }
    }
}
