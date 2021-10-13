using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB2020MidTerm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void danhSáchCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCongTy();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Database.DbFileName = "EmployeeManager.db";
            Database.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Close();
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DanhSachNhanVien();
            form.Show();
        }
    }
}
