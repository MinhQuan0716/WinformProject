using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLib.Models;
using StudentLib.Repository;
namespace StudentManagement
{
    public partial class frmMain : Form
    {
        public Account LoginInfo { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }
        int counter = 0;
        private void frmMain_Load(object sender, EventArgs e)
        {
            CreateMyMainMenu();
        }
        public void CreateMyMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;
            ToolStripMenuItem menuFile = new ToolStripMenuItem("&Menu");
            ToolStripMenuItem mnuAccount = new ToolStripMenuItem("&Account");
            ToolStripMenuItem mnuCourse = new ToolStripMenuItem("&Course");
            ToolStripMenuItem mnuAttend = new ToolStripMenuItem("&Attend");
            ToolStripMenuItem mnuExamResult = new ToolStripMenuItem("&Exam Result");
            ToolStripMenuItem mnuSchedule = new ToolStripMenuItem("&Schedule");
            ToolStripSeparator separator = new ToolStripSeparator();
            ToolStripMenuItem mnuExit = new ToolStripMenuItem("&Exit");
            ToolStripMenuItem mnuWindow = new ToolStripMenuItem("&Window");
            // mainMenu 
            mainMenu.Items.AddRange(new ToolStripItem[] { menuFile, mnuWindow });
            mainMenu.MdiWindowListItem = mnuWindow;
            //menuFile 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuAccount, mnuCourse, mnuAttend, mnuExamResult, mnuSchedule, separator, mnuExit });
            //mnuOpen 
            mnuAccount.ShortcutKeys = (Keys)((Keys.Control | Keys.A));
            mnuAccount.Click += new EventHandler(mnuAccount_Click);
            mnuCourse.ShortcutKeys = (Keys)((Keys.Control | Keys.C));
            mnuCourse.Click += new EventHandler(mnuCourse_Click);
               mnuAttend.ShortcutKeys = (Keys)((Keys.Control | Keys.W));
             mnuAttend.Click += new EventHandler(mnuAttend_Click);
              mnuExamResult.ShortcutKeys = (Keys)((Keys.Control | Keys.E));
            mnuExamResult.Click += new EventHandler(mnuExamResult_Click);
             mnuSchedule.ShortcutKeys = (Keys)((Keys.Control | Keys.S));
            mnuSchedule.Click += new EventHandler(mnuSchedule_Click);
            // mnuExit 
            mnuExit.ShortcutKeys = (Keys)((Keys.Alt | Keys.X));
            mnuExit.Click += new EventHandler(mnuExit_Click);

        }
        //end CreateMyMainMenu
        //Show frmChild form 
        private void mnuAccount_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount
            {
             LoginInfo=LoginInfo,
            };
           frmAccount.Text = $"AccountForm {counter++:D2}";
            frmAccount.MdiParent = this;
            frmAccount.Show();

        }//end mnuOpen_Click 
        private void mnuCourse_Click(object sender, EventArgs e)
        {
            frmCourse frmCourse = new frmCourse();
           frmCourse.Text = $"CourseForm {counter++:D2}";
          frmCourse.MdiParent = this; 
            frmCourse.Show();
        }//end mnuMember_Click 

        private void mnuExamResult_Click(object sender, EventArgs e)
        {
            frmExamResult product = new frmExamResult();
            product.Text = $"ProductForm {counter++:D2}";
            product.MdiParent = this; 
            product.Show();
        }
        private void mnuAttend_Click(object sender, EventArgs e)
        {
            frmAdminAttendace frmAdminAttendace = new frmAdminAttendace();
            frmAdminAttendace.Text = $"AttendanceForm {counter++:D2}";
            frmAdminAttendace.MdiParent = this;
            frmAdminAttendace.Show();
        }
        private void mnuSchedule_Click(object sender,EventArgs e)
        {
            frmAdminSchedule frmAdminSchedule = new frmAdminSchedule();
            frmAdminSchedule.Text = $"ScheduleForm {counter++:D2}";
            frmAdminSchedule.MdiParent = this;
            frmAdminSchedule.Show();
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }//end MainForm
}

