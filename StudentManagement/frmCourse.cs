using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLib.Repository;
using StudentLib.Models;
namespace StudentManagement
{
    public partial class frmCourse : Form
    {
        public ICourseRepository courseRepository = new CourseRepository();
        IEnumerable<Course> courses;
        BindingSource source;
        public Course courseInfo { get; set; }
        bool InsertOrUpdate { get; set; }   

        public frmCourse()
        {
            InitializeComponent();
        }
        public void LoadCourse()
        {
            var c= courseRepository.GetCourses();
            try
            {
                source = new BindingSource();
                source.DataSource = c;
                txtCourseID.DataBindings.Clear();
                txtSubjectName.DataBindings.Clear();
                txtTeacherName.DataBindings.Clear();
                txtCourseID.DataBindings.Add("Text", source, "CourseID");
            txtTeacherName.DataBindings.Add("Text", source, "TeacherName");
                txtSubjectName.DataBindings.Add("Text", source, "SubjectName");
                dgvData.DataSource = null;
                dgvData.DataSource = source;
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
       private Course GetCourseObject()

        {

           Course course = null;

            try
            {
                course = new Course()
                {
                    CourseId=txtCourseID.Text,
                    SubjectName=txtSubjectName.Text,
                    TeacherName=txtTeacherName.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get account");
            }

            return course;

        }//end GetCarobject
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCourse();
        }
        private void frmCourse_Load(object sender, EventArgs e)
        {
            LoadCourse();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCourseDetail frmCourseDetail = new frmCourseDetail()
            {
                Text = "Add Course",
                InsertOrUpdate = false,
                courseRepository = courseRepository,
            };
            if(frmCourseDetail.ShowDialog() == DialogResult.OK)
            {
                LoadCourse();
                source.Position = source.Count - 1;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmCourseDetail frmCourseDetail = new frmCourseDetail()
            {
                Text = "Update Course",
                InsertOrUpdate = true,
                courseInfo = GetCourseObject(),
                courseRepository = courseRepository,
            };
            if (frmCourseDetail.ShowDialog() == DialogResult.OK)
            {
                LoadCourse();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var co = GetCourseObject();
                courseRepository.Remove(co.CourseId);
                LoadCourse();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
    }
}
