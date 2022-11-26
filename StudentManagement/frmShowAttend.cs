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
using StudentLib.Models;
namespace StudentManagement
{
    public partial class frmShowAttend : Form
    {
        IAttendanceRepository attendanceRepository = new AttendanceRepository();
        IAccountRepository accountRepository = new AccountRepository();
        public Account LoginInfo { get; set; }
        public frmShowAttend()
        {
            InitializeComponent();
        }
     /*   private void LoadData()
        {
            var acc=accountRepository.GetStudent();
            cboAccount.DataSource = acc;
            cboAccount.DisplayMember = "UserName";
        }*/

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var att = attendanceRepository.GetAttendanceByStudent(LoginInfo.AccountId);
            if(att == null)
            {
                MessageBox.Show("Bạn chưa học môn nào trong kỳ này");
            }
            dgvData.DataSource= att;
            
        }

        private void frmShowAttend_Load(object sender, EventArgs e)
        {
           
        }
    }
}
