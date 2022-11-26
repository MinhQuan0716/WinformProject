using StudentLib.Models;
using StudentLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace StudentManagement
{
    public partial class frmScheduleDetail : Form
    {
        public IScheduleRepository scheduleRepositorys = new ScheduleRepository();
        IAccountRepository accountRepository = new AccountRepository();
        ICourseRepository courseRepository = new CourseRepository();

        public Account LoginInfo { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Schedule scheduleInfo { get; set; }
        public frmScheduleDetail()
        {
            InitializeComponent();
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {

            Course course = comboBox1.SelectedValue as Course;
            try
            {
                var schedule = new Schedule
                {

                    CourseId = course.CourseId,
                    AccountId = LoginInfo.AccountId,
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                };
                if (InsertOrUpdate == false)
                {


                    if (CheckDuplicate(schedule) == false)
                    {
                        scheduleRepositorys.AddNew(schedule);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate");
                    }



                }




                else
                {
                    var schedule02 = new Schedule
                    {
                        ScheduleId = int.Parse(txtScheduleID.Text),
                        CourseId = course.CourseId,
                        AccountId = LoginInfo.AccountId,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                    };
                    if (CheckDuplicate(schedule02) == false)
                    {
                        scheduleRepositorys.Update(schedule02);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate");
                    }

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void Add()
        {
            
            var course = courseRepository.GetCourses();
            //comboBox1.DataSource = course.ToList();
            //comboBox1.DisplayMember = "CourseId";
        }
        public bool CheckDuplicate(Schedule schedule)
        {
            var s = scheduleRepositorys.GetScheduleByStudent((int)schedule.AccountId);
            List<Schedule> schedules = new List<Schedule>();
            schedules = s.ToList();
            bool correct = false;
            if (schedules.Count == 0)
            {
                correct = false;
            }
            else
            {

                foreach (var item in schedules)
                {
                    if (item.CourseId.Equals(schedule.CourseId))
                    {

                        correct = true;
                        break;
                    }

                    else
                    {
                        correct = false;
                    }
                }

            }
            return correct;
        }
        private void frmScheduleDetail_Load(object sender, EventArgs e)
        {
            //Add();
           /* cboAccountID.SelectedIndex = 0;*/
            //comboBox1.SelectedIndex = 0;
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "yyyy/MM/dd hh:mm:ss";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "yyyy/MM/dd hh:mm:ss";
            if (InsertOrUpdate == true) //Update mode 
            {
                //Show car to perform updating 
                txtScheduleID.Text = scheduleInfo.AccountId.ToString();
                txtAccountID.Text = LoginInfo.AccountId.ToString();
                /*  cboAccountID.Text = scheduleInfo.AccountId.ToString();*/
                comboBox1.Text = scheduleInfo.CourseId.ToString();
                dtpStartDate.Text = scheduleInfo.StartDate.ToString();  
                dtpEndDate.Text = scheduleInfo.EndDate.ToString();
            }
            txtScheduleID.Enabled = false;
            txtAccountID.Enabled = false;
         
        }
    }
}
