using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Db4objects.Db4o.Linq;
using System.Linq;
using System.Windows.Forms;

namespace ADB2020MidTerm
{
    public partial class FormCongTy : Form
    {
        public FormCongTy()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var congty = new Company()
            {
                MaCongTy = Guid.NewGuid().ToString(),
                TenCongTy = txtTenCT.Text,
                MaSoThue = txtMaSoThue.Text,
                SoNha = txtSoNha.Text,
                DuongPho = txtDuongPho.Text,
                QuanHuyen = txtQuan.Text
            };
            Database.Store<Company>(congty);
            LayDanhSachCongTy();
        }

        private void LayDanhSachCongTy()
        {
            //Linq
            //var danhsach = from Company cty in Database.DB
            //select cty;
            //dgvCongTy.DataSource = danhsach.ToList();
            var filterObj = new Company();
            var reusult = Database.DB.QueryByExample(filterObj);
            dgvCongTy.DataSource = reusult.ToList();
        }

        private void FormCongTy_Load(object sender, EventArgs e)
        {
            LayDanhSachCongTy();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LayDanhSachCongTy();
            txtDuongPho.Text = "";
            txtMaCT.Text = "";
            txtMaSoThue.Text = "";
            txtQuan.Text = "";
            txtSoNha.Text = "";
            txtTenCT.Text = "";
        }

        private void dgvCongTy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCT.Text = dgvCongTy.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaSoThue.Text = dgvCongTy.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenCT.Text = dgvCongTy.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoNha.Text = dgvCongTy.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDuongPho.Text = dgvCongTy.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQuan.Text = dgvCongTy.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để update
            var filterObj = new Company(txtMaCT.Text);
            var result = (Company)Database.DB.QueryByExample(filterObj)[0];
            // Gán lại giá trị
            result.MaSoThue = txtMaSoThue.Text;
            result.TenCongTy = txtTenCT.Text;
            result.SoNha = txtSoNha.Text;
            result.DuongPho = txtDuongPho.Text;
            result.QuanHuyen = txtQuan.Text;
            //Store DB
            Database.DB.Store(result);
            // Load lại data
            LayDanhSachCongTy();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để delete
            var filterObj = new Company(txtMaCT.Text);
            var result = (Company)Database.DB.QueryByExample(filterObj)[0];
            // Delete Db
            Database.DB.Delete(result);
            // Load lại DB
            LayDanhSachCongTy();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Đi tìm gần đúng: Cụ thể theo tên
            var result = Database.DB.Query<Company>(delegate (Company student) {
                return student.TenCongTy.ToLower().Contains(txtTenCT.Text.ToLower());
            });
            // Trả về kết quả
            dgvCongTy.DataSource = result.ToList();
        }
    }
}
