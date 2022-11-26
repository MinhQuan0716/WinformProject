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
    public partial class frmAttendanceDetail : Form
    {
        public IAttendanceRepository attendanceRepository = new AttendanceRepository();
        IAccountRepository accountRepository = new AccountRepository();
        ICourseRepository courseRepository = new CourseRepository();
        IScheduleRepository scheduleRepository = new ScheduleRepository();  
        public bool InsertOrUpdate { get; set; }
        public Attendance attendanceInfo { get; set; }
        public Account LoginInfo { get; set; }
        public frmAttendanceDetail()
        {
            InitializeComponent();
        }

        public void Add()
        {
            var course = courseRepository.GetCourses();
            
            cboCourse.DisplayMember = "CourseId";
            cboCourse.ValueMember = "CourseId";
            cboCourse.DataSource = course;


            //var account = accountRepository.GetStudent();
            //cboAccount.DataSource = account.ToList();
            //cboAccount.DisplayMember = "Username";

            IEnumerable<int> slots = new List<int>() { 1, 2, 3, 4, 5, 6 };
            comboBox1.DataSource = slots;
        }
        private bool CheckDupAttend(int accountid,String courseId)
        {
            //Account accout = cboAccount.SelectedValue as Account;
            var atd = new Attendance
            {

                ClassDate = dateTimePicker1.Value,
                //CourseId = cboCourse.SelectedValue as String,
                //AccountId = accout.AccountId,
                //StudentName = accout.Username,
                Slot = comboBox1.SelectedValue as int?,
                AttStatus = false,
            };
            var attend = attendanceRepository.GetAttendanceByStudent(accountid)
                                            .FirstOrDefault(x => x.CourseId == courseId && x.Slot == atd.Slot
                                                            && x.ClassDate.Value.Date == atd.ClassDate.Value.Date);
            if (attend != null) return true;
            return false;
        }
        private bool CheckNumberOfSlot(String courseId,int accountId)
        {
            var numberOfAttendances = attendanceRepository.GetAttendanceByStudent(accountId)
                                                    .Where(x => x.CourseId == courseId)
                                                    .Count();
            var numberOfSlots = courseRepository.GetCourse(courseId).NumberOfSlots;
            if (numberOfSlots <= numberOfAttendances) return false;
            else return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = dateTimePicker1.Value;
                if (date.Date < DateTime.Now.Date||date.Date>DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày giờ phải từ hôm nay trở đi");
                    return;
                }
                if (InsertOrUpdate != true)
                {
                    Account accout = cboAccount.SelectedValue as Account;
                    //Course course = cboCourse.SelectedValue as Course;
                    if (accout == null)
                    {
                        MessageBox.Show("Please pick account first");
                        return;
                    }
                    var checkDup = CheckDupAttend(accout.AccountId,cboCourse.SelectedValue as string);
                    if (checkDup)
                    {
                        MessageBox.Show("Học sinh bị trùng lịch");
                        return;
                    }
                    
                    var atd = new Attendance
                    {

                        ClassDate = dateTimePicker1.Value,
                        CourseId = cboCourse.SelectedValue as String,
                        AccountId = accout.AccountId,
                        StudentName = accout.Username,
                        Slot = comboBox1.SelectedValue as int?,
                        AttStatus = false,
                    };
                    if (!CheckNumberOfSlot(atd.CourseId,(int)atd.AccountId))
                    {
                        MessageBox.Show("Học sinh đã có đủ slot cho môn học");
                        return;
                    }
                    attendanceRepository.AddNew(atd);
                   
                    
                }
                else
                {
                    //Account account =accountRepository.GetStudent().FirstOrDefault(x=> x.AccountId == attendanceInfo.AccountId);
                    var checkDup = CheckDupAttend((int)attendanceInfo.AccountId, attendanceInfo.CourseId);
                    if (checkDup)
                    {
                        MessageBox.Show("Học sinh bị trùng lịch");
                        return;
                    }
                    var atd02 = attendanceRepository.GetAttendance(attendanceInfo.AttendanceId);
                    atd02.ClassDate = dateTimePicker1.Value.Date;
                    atd02.Slot = comboBox1.SelectedValue as int?;
                    atd02.AttStatus = false;
                    attendanceRepository.Update(atd02);              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public bool CheckCourse(Account LoginInfo,Attendance attendance)
        {
            bool correct = false;
            var course = courseRepository.GetCourseByTeacherName(LoginInfo.Username);
            var att = attendanceRepository.GetAttendance(attendance.AttendanceId);
            if (att==null)
            {
                correct = true;
            }
            if (course == null)
            {
                correct = false;
            }
            else
            {
                foreach (var item in course)
                {
                    if (item.CourseId.Equals(attendance.CourseId))
                    {
                        correct = true;
                        break;
                    }
                    else
                    {
                        correct = true;
                    }

                }
            }
            return correct;
        }
        private void frmAttendanceDetail_Load(object sender, EventArgs e)
        {
            
         
            if (InsertOrUpdate == true) //Update mode 
            {

                cboAccount.Text = attendanceInfo.StudentName;
                cboCourse.Text = attendanceInfo.CourseId;
                cboCourse.Enabled = false;
                cboAccount.Enabled = false;
                IEnumerable<int> slots = new List<int>() { 1, 2, 3, 4, 5, 6 };
                comboBox1.DataSource = slots;
                comboBox1.SelectedIndex = (int)attendanceInfo.Slot  - 1;
            }
            else
            {
                Add();
                cboCourse_SelectionChangeCommitted(sender,e);
            }
        }

        private void cboCourse_SelectedValueChanged(object sender, EventArgs e)
        {
           

        }

        private void cboCourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string courseId = (String)cboCourse.SelectedValue;

            var schedules = scheduleRepository.GetAll()
                        .Where(x => x.CourseId == courseId)
                        .Select(x => x.AccountId)
                        .ToList();

            var accounts = accountRepository.GetStudent()
                .Where(x => schedules.Contains(x.AccountId)).ToList();

            cboAccount.DisplayMember = "Username";
            //cboAccount.ValueMember = "AccountId";
            if (accounts == null || accounts.Count() == 0) cboAccount.DataSource = null;
            cboAccount.DataSource = accounts;
        }
    }
}
