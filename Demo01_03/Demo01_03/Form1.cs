using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Demo01_03
{
    public partial class Form1 : Form
    {
        // Đock document Db4o tại: 
        IObjectContainer db = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = Db4oFactory.OpenFile("PilotDB.db");
            loadAllData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Bước 1: Validator

            // Bước 2: Tạo mới
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
            var filterObj = new Pilot();
            var result = db.QueryByExample(filterObj);
            // Đổ dũ liệu ra dgvPilot
            dgvPilot.DataSource = result;
            txtId.Text = "";
            txtName.Text = "";
            txtPoint.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadAllData();
        }

        // Click vào để chỉnh sửa
        private void dgvPilot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvPilot.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text= dgvPilot.Rows[e.RowIndex].Cells[1].Value.ToString(); ;
            txtPoint.Text = dgvPilot.Rows[e.RowIndex].Cells[2].Value.ToString(); ;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để update
            var filterObj = new Pilot(txtId.Text);
            var result = (Pilot) db.QueryByExample(filterObj)[0];
            // Gán lại giá trị
            result.Name = txtName.Text;
            result.Point = double.Parse(txtPoint.Text);
            //Store DB
            db.Store(result);
            // Load lại data
            loadAllData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để delete
            var filterObj = new Pilot(txtId.Text);
            var result = (Pilot)db.QueryByExample(filterObj)[0];
            // Delete Db
            db.Delete(result);
            // Load lại DB
            loadAllData();
        }
        // Cách 1: Search bằng Native Query
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Đi tìm chính xác
            //var filterObj = new Pilot(null, txtName.Text, 0.0);
            // var result = db.QueryByExample(filterObj);
            //dgvPilot.DataSource = result;

            // Đi tìm gần đúng: Cụ thể theo tên
            var result = db.Query<Pilot>(delegate (Pilot pilot) {
                return pilot.Name.ToLower().Contains(txtName.Text.ToLower());
            });
            // Trả về kết quả
            dgvPilot.DataSource = result.ToList();
        }

        // Cách 2: Search bằng LINQ
        private void btnSearch_Linq_Click(object sender, EventArgs e)
        {
            IEnumerable<Pilot> result = from Pilot pilot in db
                                            // Đi tìm gần đúng: Cụ thể theo tên và Point
                                        where pilot.Name.ToLower().Contains(txtName.Text.ToLower())
                                        && pilot.Point >= double.Parse(txtPoint.Text)
                                        select pilot;
            // Trả về kết quả
            dgvPilot.DataSource = result.ToList();
        }
    }
}
