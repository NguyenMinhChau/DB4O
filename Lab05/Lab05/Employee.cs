using Lab05.DB;
using Lab05.Elmasri_Navathe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab05
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LayDanhSachNhanVien();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filterObj = new Lab05.Elmasri_Navathe.Employee();
            var result = (Lab05.Elmasri_Navathe.Employee)Database.DB.QueryByExample(filterObj)[0];
            Database.Delete(result);
            LayDanhSachNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var nhanvien = new Lab05.Elmasri_Navathe.Employee
            {
                Ssn = Guid.NewGuid().ToString(),
                FName = txtFistName.Text,
                LName = txtLastName.Text,
                Sex = cbGioiTinh.SelectedItem.ToString(),
                BirthDate = dtpNgaySinh.Text,
                Address = txtDiaChi.Text,
                Salary = double.Parse(txtLuong.Text)
            };
            Database.Store(nhanvien);
            LayDanhSachNhanVien();
        }

        private void LayDanhSachNhanVien()
        {
            var filterObject = new Lab05.Elmasri_Navathe.Employee();
            var result = Database.DB.QueryByExample(filterObject);
            dgvEmployee.DataSource = result;
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFistName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
            //cbGioiTinh.Text = dgvEmployee.Rows[e.RowIndex].Cells[7].Value.ToString();
            dtpNgaySinh.Text = dgvEmployee.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDiaChi.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtLuong.Text = dgvEmployee.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var filterObj = new Lab05.Elmasri_Navathe.Employee(txtMaNV.Text);
            var result = (Lab05.Elmasri_Navathe.Employee)Database.DB.QueryByExample(filterObj)[0];
            result.FName = txtFistName.Text;
            result.LName = txtLastName.Text;
            result.Sex = cbGioiTinh.SelectedItem.ToString();
            result.BirthDate = dtpNgaySinh.Text;
            result.Address = txtDiaChi.Text;
            result.Salary = double.Parse(txtLuong.Text);
            Database.DB.Store(result);
            LayDanhSachNhanVien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var result = Database.DB.Query<Lab05.Elmasri_Navathe.Employee>(delegate (Lab05.Elmasri_Navathe.Employee nv)
              {
                  return nv.LName.ToLower().Contains(txtLastName.Text.ToLower());
              });
            dgvEmployee.DataSource = result;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LayDanhSachNhanVien();
            txtFistName.Text = "";
            txtLastName.Text = "";
            cbGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtLuong.Text = "";
         }
    }
}
