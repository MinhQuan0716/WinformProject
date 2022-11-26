using StudentLib.Repository;
using StudentLib.Models;
namespace StudentManagement
{
    public partial class frmLogin : Form
    {
        private IAccountRepository accountRepository=new AccountRepository();
        public Account AdminInfo { get; set; }
        public Account StudentInfo { get; set; }
        public Account TeacherInfo { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int role = accountRepository.CheckLogin(textBox1.Text, textBox2.Text);
            if (role == 1)
            {
                AdminInfo = accountRepository.GetLoginInfo(textBox1.Text, textBox2.Text, role);
                frmMain frmMain = new frmMain
                {
                    LoginInfo=AdminInfo,
                    
            };
                frmMain.ShowDialog();
            }
            else if(role == 3)
            {
               StudentInfo = accountRepository.GetLoginInfo(textBox1.Text, textBox2.Text, role);
                frmStudent frmStudent = new frmStudent
                {
                    LoginInfo = StudentInfo,
                };
                frmStudent.ShowDialog();
            } else if (role == 2)
            {
                TeacherInfo = accountRepository.GetLoginInfo(textBox1.Text, textBox2.Text, role);
                frmTeacher frmTeacher = new frmTeacher
                {
                    LoginInfo = TeacherInfo,
                };
                frmTeacher.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}