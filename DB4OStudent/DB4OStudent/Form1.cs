using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB4OStudent
{
    public partial class Form1 : Form
    {
        IObjectContainer db = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = Db4oFactory.OpenFile("StudentDB.db");
            loadAllData();

            /*
             var result = from Course sv in db
                        select sv;
            MessageBox.Show(result.Count().ToString());
             */


            /*
             var abd = new Course {
                CourseCode = "COMP101",
                CourseName = "Advanced DB"
            }
            var web = new Course {
                CourseCode = "COMP102",
                CourseName = "Web Technology"
            }
            //db.Store(abd);
            //db.Store(web);

            // Add Student who learns 2 courses above
            var student = new Student {
                StudentId = "4501104001",
                FirstName = "David",
                LastName = "Join",
                DOB = new DateTime(2001,10,10),
                RegisterYear = 2019,
                Courses = new List<Course>()
            }
            student.Courses.Add(abd)
            student.Courses.Add(web)

            db.Store(student);

            var result = from Student sv in db
                        select sv;
            MessageBox.Show(result.Count().ToString());
             */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var student = new Student() {
                StudentId = Guid.NewGuid().ToString(),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                RegisterYear = int.Parse(txtRegister.Text),
                DOB = DateTime.Parse(dtp_dob.Text),
                StudentCode = Guid.NewGuid().ToString()
            };
            db.Store(student);
            loadAllData();

        }

        private void loadAllData()
        {
            var filterObj = new Student();
            var reusult = db.QueryByExample(filterObj);
            dgv_student.DataSource = reusult;
        }

        private void dgv_student_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgv_student.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgv_student.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgv_student.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRegister.Text = dgv_student.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtp_dob.Text = dgv_student.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAge.Text = dgv_student.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để update
            var filterObj = new Student(txtId.Text);
            var result = (Student)db.QueryByExample(filterObj)[0];
            // Gán lại giá trị
            result.FirstName = txtFirstName.Text;
            result.LastName = txtLastName.Text;
            result.RegisterYear = int.Parse(txtRegister.Text);
            result.DOB = DateTime.Parse(dtp_dob.Text);
            //Store DB
            db.Store(result);
            // Load lại data
            loadAllData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Đi tìm theo Id để delete
            var filterObj = new Student(txtId.Text);
            var result = (Student) db.QueryByExample(filterObj)[0];
            // Delete Db
            db.Delete(result);
            // Load lại DB
            loadAllData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Đi tìm gần đúng: Cụ thể theo tên
            var result = db.Query<Student>(delegate (Student student) {
                return student.LastName.ToLower().Contains(txtLastName.Text.ToLower()) && student.YearOld.ToString().Contains(txtAge.Text.ToString());
            });
            // Trả về kết quả
            dgv_student.DataSource = result.ToList();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadAllData();
            txtAge.Text = "";
            txtFirstName.Text = "";
            txtId.Text = "";
            txtLastName.Text = "";
            txtRegister.Text = "";
        }
    }
}
