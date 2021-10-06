using Db4objects.Db4o;
using System;
using System.Windows.Forms;

namespace Lab01_04
{
    public partial class Form1 : Form
    {
        // Đọc document Db4o tại: https://sceweb.uhcl.edu/liaw/Presentations/oodb/db4o/db4o7_2_Tutorial/
        IObjectContainer db = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvPilot_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = Db4oFactory.OpenFile("PilotDb.db");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Bước 1: Validator

            //Bước 2: Tạo mới 1 Pilot
            var pilot = new Pilot() {
                Id = Guid.NewGuid().ToString(),
                Name = txtName.Text,
                Point = double.Parse(txtPoint.Text)
            };

            // Bước 3: Store DB
            db.Store(pilot);

            // Bước 4: Load lại Data
            loadAllData();
        }

        private void loadAllData()
        {
            var filterObject = new Pilot();
            var result = db.QueryByExample(filterObject);

            // Đổ dữ liệu ra dgv_Pilot
            dgvPilot.DataSource = result;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

    }
}
