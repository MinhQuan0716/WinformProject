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
    public partial class frmAttendace : Form
    {

        IAttendanceRepository attendanceRepository = new AttendanceRepository();
        ICourseRepository courseRepository = new CourseRepository();
        List<AttendanceResponse> attendances = new List<AttendanceResponse>();
        bool InsertOrUpdate = false;
        BindingSource source;
        public Account LoginInfo { get; set; }

        public void LoadAttendance(String courseId)
        {

            var Allatd = attendanceRepository.GetAll();
            var atd = new List<Attendance>();
          
                atd.AddRange(Allatd.Where(x=> x.CourseId == courseId));
            
            
            try
            {
                attendances.Clear();
                foreach (var a in atd)
                {
                    attendances.Add(new AttendanceResponse()
                    {
                        AttendanceId = a.AttendanceId,
                        AttStatus = (bool)a.AttStatus,
                        Slot = a.Slot,
                        CourseId = a.CourseId,
                        StudentName = a.StudentName, 
                        AccountId =(int) a.AccountId,
                        ClassDate = (DateTime) a.ClassDate,
                    });
                }

                source = new BindingSource();
                source.DataSource = attendances;

                txtAccountID.DataBindings.Clear();
                txtAttenanceID.DataBindings.Clear();
                txtAttStatus.DataBindings.Clear();
                txtCourseID.DataBindings.Clear();
                txtSlot.DataBindings.Clear();
                textBox1.DataBindings.Clear();
                textBox2.DataBindings.Clear();

                txtAccountID.DataBindings.Add("Text", source, "AccountId");
                txtAttenanceID.DataBindings.Add("Text", source, "AttendanceId");
                txtAttStatus.DataBindings.Add("Text", source, "AttStatus");
                txtCourseID.DataBindings.Add("Text", source, "CourseId");
                txtSlot.DataBindings.Add("Text", source, "Slot");
                textBox1.DataBindings.Add("Text", source, "StudentName");
                textBox2.DataBindings.Add("Text", source, "ClassDate");

                dgvAttendance.DataSource = null;


                dgvAttendance.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadAccount");
            }
        }
        private Attendance GetAttendance()

        {

            Attendance atd = null;
            try
            {
                atd = new Attendance
                {
                    AttendanceId = int.Parse(txtAttenanceID.Text),
                    CourseId = txtCourseID.Text,
                    AccountId = int.Parse(txtAccountID.Text),
                    Slot = int.Parse(txtSlot.Text),
                    AttStatus = Boolean.Parse(txtAttStatus.Text),
                    
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Attendace");
            }

            return atd;

        }



        public frmAttendace()
        {
            InitializeComponent();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAttendanceDetail frmAttendanceDetail = new frmAttendanceDetail
            {
                Text = "Add Attendance",
                InsertOrUpdate = false,
                attendanceRepository = attendanceRepository,
                LoginInfo=LoginInfo
            };
            if (frmAttendanceDetail.ShowDialog() == DialogResult.OK)
            {
                LoadAttendance((string)comboBox1.SelectedValue);
                //Set focus car inserted
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var attend = GetAttendance();
                attendanceRepository.Remove(attend.AttendanceId);
                LoadAttendance((string)comboBox1.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Account");
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAttendance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAttendanceDetail frmAttendanceDetail = new frmAttendanceDetail
            {
                Text = "Update Attendance",
                InsertOrUpdate = true,
                attendanceRepository = attendanceRepository,
                LoginInfo = LoginInfo,
                attendanceInfo=GetAttendance()
            };
            if (frmAttendanceDetail.ShowDialog() == DialogResult.OK)
            {
                LoadAttendance((string)comboBox1.SelectedValue);
                //Set focus car inserted
                source.Position = source.Count - 1;
            }
        }
        private void LoadCourses()
        {
            IEnumerable<Course> courses;
            courses = courseRepository.GetCourseByTeacherName(LoginInfo.Username);
            comboBox1.DisplayMember = "CourseId";
            comboBox1.ValueMember = "CourseId";
            comboBox1.DataSource = courses;
        }
        private void frmAttendace_Load(object sender, EventArgs e)
        {
           
            LoadCourses();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance((string)comboBox1.SelectedValue);
            var days = attendances.GroupBy(x => x.ClassDate).Select(x => x.Key).ToList();
            comboBox2.DataSource = days;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // attendances = dgvAttendance.DataSource as IEnumerable<AttendanceResponse>;
            var check = false;
            String x = "";
            foreach (var a in attendances)
            {
                 
                var attendance = attendanceRepository.GetAttendance(a.AttendanceId);
                var isChanged = attendance.AttStatus ^ a.AttStatus;
                attendance.AttStatus = a.AttStatus;
                DateTime today = DateTime.Now;
                if (isChanged == true)
                {
                    if (today.Date == attendance.ClassDate.Value.Date) attendanceRepository.Update(attendance);
                    else
                    {
                        check = true;
                        x = x + a.AttendanceId + ",";
                    }
                }
            }
            if (check) MessageBox.Show("Attendance Ids fail because of wrong date: "+ x);
            MessageBox.Show("Take Attendance Success!");
            LoadAttendance(comboBox1.SelectedValue as String);
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DateTime date = (DateTime)comboBox2.SelectedValue;
            String courseId = (String)comboBox1.SelectedValue;

            var result = attendanceRepository.GetAll()
                    .Where(x => x.CourseId == courseId && x.ClassDate.Value.Date == date.Date)
                    .ToList();

            source = new BindingSource();
            attendances = result.Select(a => new AttendanceResponse()
            {
                AttendanceId = a.AttendanceId,
                AttStatus = (bool)a.AttStatus,
                Slot = a.Slot,
                CourseId = a.CourseId,
                StudentName = a.StudentName,
                AccountId = (int)a.AccountId,
                ClassDate = (DateTime)a.ClassDate,
            }).ToList();
            source.DataSource = attendances;


            txtAccountID.DataBindings.Clear();
            txtAttenanceID.DataBindings.Clear();
            txtAttStatus.DataBindings.Clear();
            txtCourseID.DataBindings.Clear();
            txtSlot.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();

            txtAccountID.DataBindings.Add("Text", source, "AccountId");
            txtAttenanceID.DataBindings.Add("Text", source, "AttendanceId");
            txtAttStatus.DataBindings.Add("Text", source, "AttStatus");
            txtCourseID.DataBindings.Add("Text", source, "CourseId");
            txtSlot.DataBindings.Add("Text", source, "Slot");
            textBox1.DataBindings.Add("Text", source, "StudentName");
            textBox2.DataBindings.Add("Text", source, "ClassDate");


            dgvAttendance.DataSource = null;
            dgvAttendance.DataSource = source;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
