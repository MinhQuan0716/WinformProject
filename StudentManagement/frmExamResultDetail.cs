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
    public partial class frmExamResultDetail : Form
    {
   public  IAccountRepository accountRepository=new AccountRepository();
     public   ICourseRepository courseRepository=new CourseRepository();
        public IExamTypeRepository examTypeRepository = new ExamTypeRepository();
       public IExamResultRepository examResultRepository=new ExamResultRepository();
        public IAttendanceRepository attendanceRepository = new AttendanceRepository();
      public  bool InsertOrUpdate { get; set; }
        public ExamResult resultInfo { get; set; }
        Regex r = new Regex(@"([A-z])+([0-9])+");
        public frmExamResultDetail()
        {
            InitializeComponent();
        }
        private void LoadAccount()
        {
            var acc = accountRepository.GetStudent();
            cboAccount.DataSource = acc.ToList();
            cboAccount.DisplayMember = "UserName";
        }
        private void LoadCourse()
        {
            var co = courseRepository.GetCourses();
            cboCourse.DataSource= co.ToList();
            cboCourse.DisplayMember = "CourseId";
        }
        private void LoadType()
        {
            var type = examTypeRepository.GetTypes();
            cboExamType.DataSource = type.ToList();
            cboExamType.DisplayMember = "ExamTypeName";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmExamResultDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == false)
            {
                LoadAccount();
                LoadCourse();
                LoadType();
                cboAccount.SelectedIndex = 0;
                cboCourse.SelectedIndex = 0;
                cboExamType.SelectedIndex = 0;
            }else  if (InsertOrUpdate == true)
            {
                txtExamID.Text = resultInfo.ExamId;
                txtTotalTime.Text = resultInfo.Totaltime.ToString();
                txtMarks.Text=resultInfo.Marks.ToString();
                var accountName = accountRepository.GetAccount((int)resultInfo.AccountId).Username;
                cboAccount.Text = accountName;
                cboCourse.Text = resultInfo.CourseId;
            }
        }
        public bool CheckInput(string input)
        {
            bool correct = true;
            if (input.Equals(""))
            {
                correct= false;
            } else if(!System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z ]"))
            {
                correct = false;
            }
            return correct;
        }
        private bool checkDup()
        {
            string res = "OK";
            Account account = cboAccount.SelectedValue as Account;
            Course course = cboCourse.SelectedValue as Course;
            var exam = examResultRepository.GetResultByStudentID(account.AccountId)
                                            .FirstOrDefault(x=> x.CourseId == course.CourseId);
            if (exam != null) return true;
            return false;

        }
        public bool absentTooMuch()
        {
            Account account = cboAccount.SelectedValue as Account;
            Course course = cboCourse.SelectedValue as Course;
            var attendances = attendanceRepository.GetAttendanceByStudent(account.AccountId)
                                                    .Where(x => x.CourseId == course.CourseId);
            if (attendances.Count() > 0)
            {
                var absent = attendances.Where(x => (bool)x.AttStatus ==false).Count();
                //var absent = attendances.Count() - attended;
                var rate = (double) absent /  attendances.Count();
                if (rate > 0.2) return true;
                else return false;
            }
            else
            {
                return true;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Account account = cboAccount.SelectedValue as Account;
            Course course = cboCourse.SelectedValue as Course;
            ExamType type=cboExamType.SelectedValue as ExamType;
            try
            {
                
                

                if (InsertOrUpdate == false)
                {
                    var examTest = examResultRepository.GetResultByStudentID(account.AccountId)
                                                        .FirstOrDefault(x=> x.CourseId == course.CourseId);
                    if (examTest != null)
                    {
                        MessageBox.Show("Sinh viên đã có điểm môn này");
                        return;
                    }

                    var result = new ExamResult
                    {
                        ExamId = txtExamID.Text,
                        CourseId = course.CourseId,
                        AccountId = account.AccountId,
                        ExamStartDate = dateTimePicker1.Value,
                        ExamStatus = checkBox1.Checked,
                        ExamType = type.ExamtypeId,
                        Totaltime = int.Parse(txtTotalTime.Text),
                        Marks = int.Parse(txtMarks.Text),
                    };
                    if (result.Marks > 10 || result.Marks < 0) throw new Exception("Invalid mark");
                    int numberOfSlots = (int)courseRepository.GetCourse(course.CourseId).NumberOfSlots;

                    var attendances = attendanceRepository.GetAll()
                       .Where(x => x.AccountId == account.AccountId && x.CourseId == course.CourseId).ToList();

                    if (attendances.Count == 0)
                    {
                        MessageBox.Show("Sinh viên không học môn này");
                        return;
                    }
                    if (attendances.Count() < numberOfSlots)
                    {
                        MessageBox.Show("Sinh viên chưa được phân đủ lịch học");
                        return;
                    }
                    int attend = attendances.Where(x => x.AttStatus == true).Count();
                    //int numberOfAttendanceEntity = attendances
                    //tinh
                    


                    float rate = (float)attend / (float)numberOfSlots;

                    if (rate >= 0.8)
                    {
                        examResultRepository.AddNew(result);
                        MessageBox.Show("Add New Success");
                        this.Close();
                    }
                    else MessageBox.Show("Sorry, Student've absent exceed 20%");
                }
                else
                {
                    var result = resultInfo;
                    result.Marks = int.Parse(txtMarks.Text);
                    result.ExamStatus = checkBox1.Checked;
                    if (checkBox1.Checked) result.Status = "Passed";
                    else result.Status = "Not passed";
                    var attendances = attendanceRepository.GetAll()
                        .Where(x => x.AccountId == result.AccountId && x.CourseId == result.CourseId).ToList();
                    if (attendances.Count == 0)
                    {
                        MessageBox.Show("Student dont have class");
                        return;
                    }
                    int attend = attendances.Where(x => x.AttStatus == true).Count();

                    //tinh
                    int numberOfSlots = (int)courseRepository.GetCourse(result.CourseId).NumberOfSlots;
                    float rate = (float)attend / (float)numberOfSlots;

                    if (rate >= 0.8)
                    {
                        examResultRepository.Update(result);
                        MessageBox.Show("Update Success");
                        Close();
                    }
                    else MessageBox.Show("Sorry, Student've absent exceed 20%");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
