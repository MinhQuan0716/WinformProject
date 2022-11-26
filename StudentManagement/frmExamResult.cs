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
    public partial class frmExamResult : Form
    {
      public   IExamResultRepository examResultRepository = new ExamResultRepository();
        public bool InsertOrUpdate { get; set; }
        public ExamResult examResultInfo { get; set; }
        BindingSource source;
        public frmExamResult()
        {
            InitializeComponent();
        }
        public void LoadAccount()
        {
            var acc = examResultRepository.GetResult();
            try
            {
                source = new BindingSource();
                source.DataSource = acc;
                txtExamID.DataBindings.Clear();
                txtAccountID.DataBindings.Clear();
                txtCourseID.DataBindings.Clear();
                txtStartDate.DataBindings.Clear();
                txtMark.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtTotalTime.DataBindings.Clear();
                txtExamType.DataBindings.Clear();
                /*********************************/
                txtExamID.DataBindings.Add("Text", source, "ExamId");
                txtAccountID.DataBindings.Add("Text", source, "AccountID");
                txtCourseID.DataBindings.Add("Text", source, "CourseID");
                txtStartDate.DataBindings.Add("Text", source, "ExamStartDate");
                txtExamType.DataBindings.Add("Text", source, "ExamType");
                txtMark.DataBindings.Add("Text", source, "Marks");
                txtStatus.DataBindings.Add("Text", source, "ExamStatus");
                txtTotalTime.DataBindings.Add("Text", source, "TotalTime");

                txtExamID.ReadOnly = true;
                dgvData.DataSource = null;
                dgvData.DataSource = source;


                if (acc.Count() == 0)
                {
                    //btnDelete.Enabled = false;
                }
                else
                {
                  //  btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadAccount");
            }
        }
        private ExamResult GeResultObject()

        {

           ExamResult account = null;

            try
            {
                account = new ExamResult
                {
                    ExamId=txtExamID.Text,
                    AccountId = int.Parse(txtAccountID.Text),
                 CourseId = txtCourseID.Text,
                   ExamStartDate = DateTime.Parse(txtStartDate.Text),
                   ExamStatus=Boolean.Parse(txtStatus.Text),
                    Totaltime=int.Parse(txtTotalTime.Text),
                  ExamType=txtExamType.Text,
                  Marks=int.Parse(txtMark.Text)

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get result");
            }

            return account;

        }//end GetCarobject
        private void frmExamResult_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmExamResultDetail frmExamResultDetail = new frmExamResultDetail()
            {
                Text = "Add result",
                InsertOrUpdate = false,
                examResultRepository = examResultRepository,
            };
            if(frmExamResultDetail.ShowDialog() == DialogResult.OK)
            {
                LoadAccount();
                source.Position = source.Count - 1;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string examId = txtExamID.Text;
            var exam = examResultRepository.GetResultByID(examId);
            var form = new frmExamResultDetail()
            {
                InsertOrUpdate = true,
                resultInfo = exam,

            };
            form.ShowDialog();
        }
    }
}
