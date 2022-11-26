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
    public partial class frmFullCourse : Form
    {
        ICourseRepository courseRepository = new CourseRepository();
        IEnumerable<Course> courses;
        BindingSource source;
        public frmFullCourse()
        {
            InitializeComponent();
        }
        public void LoadCourse()
        {
            var c = courseRepository.GetCourses();
            try
            {
                source = new BindingSource();
                source.DataSource = c;
                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = false;

                dgvData.Columns.Add("CourseId", "CourseId");
                dgvData.Columns["CourseId"].DataPropertyName = "CourseId";

                dgvData.Columns.Add("SubjectName", "SubjectName");
                dgvData.Columns["SubjectName"].DataPropertyName = "SubjectName";

                dgvData.Columns.Add("TeacherName", "TeacherName");
                dgvData.Columns["TeacherName"].DataPropertyName = "TeacherName";

                dgvData.DataSource = null;
                dgvData.DataSource = c;
                /*  if (c.Count() == 0)
                  {
                    //btnDelete.Enabled = false;
                  }
                  else
                  {
                      //btnDelete.Enable=true;
                  }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadAccount");
            }
        }
        private void frmFullCourse_Load(object sender, EventArgs e)
        {
            LoadCourse();
        }
    }
}
