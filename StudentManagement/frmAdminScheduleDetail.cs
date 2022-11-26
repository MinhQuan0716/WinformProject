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
    public partial class frmAdminScheduleDetail : Form
    {
        public IScheduleRepository scheduleRepositorys = new ScheduleRepository();
        IAccountRepository accountRepository = new AccountRepository();
        ICourseRepository courseRepository = new CourseRepository();


        public bool InsertOrUpdate { get; set; }
        public Schedule scheduleInfo { get; set; }
        public frmAdminScheduleDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Account account = cboAccountID.SelectedValue as Account;
            Course course = cboCourseID.SelectedValue as Course;
            try
            {
                var schedule = new Schedule
                {
                    
                    CourseId = course.CourseId,
                    AccountId = account.AccountId,
                    StartDate = dtpTime.Value,
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
                        AccountId = account.AccountId,
                        StartDate = dtpTime.Value,
                        EndDate = dtpEndDate.Value,
                    };
                    if(CheckDuplicate(schedule02) == false)
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
            var account = accountRepository.GetStudent();
            cboAccountID.DataSource = account.ToList();
            cboAccountID.DisplayMember = "Username";
            var course = courseRepository.GetCourses();
            cboCourseID.DataSource = course.ToList();
            cboCourseID.DisplayMember = "CourseId";
        }
        public bool CheckDuplicate(Schedule schedule)
        {
            var s = scheduleRepositorys.GetScheduleByStudent((int)schedule.AccountId);
            List<Schedule> schedules = new List<Schedule>();
            schedules = s.ToList();
            bool correct=false;
            if (schedules.Count == 0)
            {
                correct= false;
            }
            else
            {

                foreach (var item in schedules)
                {
                    DateTime d1 = item.StartDate;
                    DateTime d2 = item.EndDate;
                    if (item.CourseId.Equals(schedule.CourseId))
                    {
                        
                      correct= true;
                        break;
                    }
                    else if (d1.Date.Equals(schedule.StartDate.Date) && d1.Month.Equals(schedule.StartDate.Month) && d1.Year.Equals(schedule.StartDate.Year))
                    {
                        correct = true;
                        break;
                    }
                    else if (d2.Date.Equals(schedule.StartDate.Date) && d2.Month.Equals(schedule.StartDate.Month) && d2.Year.Equals(schedule.StartDate.Year))
                    {
                        correct = true;
                        break;
                    }
                    else
                    {
                        correct= false;
                    }
                }

            }
            return correct;
        }
        private void frmScheduleDetail_Load(object sender, EventArgs e)
        {
            Add();
            cboAccountID.SelectedIndex = 0;
            cboCourseID.SelectedIndex = 0;            
            if (InsertOrUpdate == true) //Update mode 
            {
                //Show car to perform updating 
                txtScheduleID.Text = scheduleInfo.AccountId.ToString();
                cboAccountID.Text = scheduleInfo.AccountId.ToString();
                cboCourseID.Text = scheduleInfo.CourseId.ToString();
                dtpTime.Text = scheduleInfo.StartDate.ToString();
                dtpEndDate.Text = scheduleInfo.EndDate.ToString();
            }
            txtScheduleID.Enabled = false;
        }
    }
}
