using StudentLib.Models;
using StudentLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmShowResult : Form
    {
        IExamResultRepository examResultRepository = new ExamResultRepository();
        public Account LoginInfo { get; set; }
        public frmShowResult()
        {
            InitializeComponent();
        }

        private void frmShowResult_Load(object sender, EventArgs e)
        {
            txtName.Text = LoginInfo.Username;
            txtName.Enabled = false;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var result = examResultRepository.GetResultByStudentID(LoginInfo.AccountId);
            if(result == null)
            {
                MessageBox.Show("Bạn chưa học môn nào trong kỳ này");
            }
            dgvData.Columns.Clear();
            dgvData.AutoGenerateColumns = false;

            dgvData.Columns.Add("CourseId", "CourseId");
            dgvData.Columns["CourseId"].DataPropertyName = "CourseId";

            dgvData.Columns.Add("ExamStartDate", "ExamStartDate");
            dgvData.Columns["ExamStartDate"].DataPropertyName = "ExamStartDate";

            dgvData.Columns.Add("Totaltime", "Totaltime");
            dgvData.Columns["Totaltime"].DataPropertyName = "Totaltime";

            dgvData.Columns.Add("Marks", "Marks");
            dgvData.Columns["Marks"].DataPropertyName = "Marks";

            dgvData.Columns.Add("ExamType", "ExamType");
            dgvData.Columns["ExamType"].DataPropertyName = "ExamType";

            dgvData.Columns.Add("Status", "Status");
            dgvData.Columns["Status"].DataPropertyName = "Status";



            dgvData.DataSource = null;
   
            dgvData.DataSource = result;
        }
    }
}
