using Lab05.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class CongTy : Form
    {
        public CongTy()
        {
            InitializeComponent();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Employee();
            form.Show();
        }

        private void CongTy_Load(object sender, EventArgs e)
        {
            Database.DbFileName = "employee.dat";
            Database.Open();
        }

        private void CongTy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.CloseDB();
        }
    }
}
