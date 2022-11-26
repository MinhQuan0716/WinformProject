using StudentLib.Models;
using StudentLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmShowCourse : Form
    {
        ICourseRepository courseRepository = new CourseRepository();
        public Account LoginInfo { get; set; }
        public frmShowCourse()
        {
            InitializeComponent();
        }
      
        private void btnShow_Click(object sender, EventArgs e)
        {
            txtName.Text = LoginInfo.Username;
            var course = courseRepository.GetCourseByTeacherName(LoginInfo.Username);
            dgvData.Columns.Clear();
            dgvData.AutoGenerateColumns = false;

            dgvData.Columns.Add("CourseId", "CourseId");
            dgvData.Columns["CourseId"].DataPropertyName = "CourseId";

            dgvData.Columns.Add("SubjectName", "SubjectName");
            dgvData.Columns["SubjectName"].DataPropertyName = "SubjectName";

            dgvData.Columns.Add("TeacherName", "TeacherName");
            dgvData.Columns["TeacherName"].DataPropertyName = "TeacherName";

            dgvData.DataSource = null;
            dgvData.DataSource = course;
        }

        private void frmShowCourse_Load(object sender, EventArgs e)
        {

        }
    }
}
