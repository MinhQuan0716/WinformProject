using StudentLib.Models;
using StudentLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmCourseDetail : Form
    {
        public frmCourseDetail()
        {
            InitializeComponent();
        }
        Regex r = new Regex(@"([A-z])+([0-9])+");
        public ICourseRepository courseRepository=new CourseRepository();
        IAccountRepository AccountRepository = new AccountRepository();
        public Course courseInfo { get; set; }
      public bool InsertOrUpdate { get; set; }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void LoadCombo()
        {
            var name = AccountRepository.GetTeacher();
            cboName.DataSource = name.ToList();
            cboName.DisplayMember = "UserName";
        }
        public bool CheckInput(string input, string input2)
        {
            bool correct = true;
            if (input.Equals("") || input2.Equals(""))
            {
                correct = false;
            }
            else if (!r.IsMatch(input))
            {
                correct = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-Z ]"))
            {
                correct = false;
            }


            return correct;
        }
        //private bool checkDupTeacher()
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Account account = cboName.SelectedValue as Account;
                
                var Course = new Course
                {
                    CourseId = txtCourseID.Text,
                    SubjectName = txtSubjectame.Text,
                    TeacherName = account.Username,
                    NumberOfSlots = int.Parse(textBox1.Text)
                };
                if (InsertOrUpdate == false)
                {
                    if (CheckInput(txtCourseID.Text, txtSubjectame.Text)==true)
                    {
                        
                        courseRepository.AddNew(Course);
                    }
                    else
                    {
                        MessageBox.Show("Error in validation");
                    }
                    
                }
                else
                {

                    if (CheckInput(txtCourseID.Text, txtSubjectame.Text) == true)
                    {
                        courseRepository.Update(Course);
                    }
                    else
                    {
                        MessageBox.Show("Error in validation");
                    }

                }
            } catch(Exception ex)
            {
           MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new Course" : "Update Course");
            }
        }
       


        private void frmCourseDetail_Load(object sender, EventArgs e)
        {
            LoadCombo();
            
            cboName.SelectedIndex = 0;
            if (InsertOrUpdate == true)
            {
                txtCourseID.Text= courseInfo.CourseId;
                txtSubjectame.Text = courseInfo.SubjectName;
              
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

          
        }
    }
}
