using StudentLib.Models;
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

namespace StudentManagement
{
    public partial class frmStudent : Form
    {
        public Account LoginInfo { get; set; }
        int counter=0;
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            CreateMyMainMenu();
        }
        public void CreateMyMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;
            ToolStripMenuItem menuFile = new ToolStripMenuItem("&Menu");
         //   ToolStripMenuItem mnuAccount = new ToolStripMenuItem("&Account");
           ToolStripMenuItem mnuCourse = new ToolStripMenuItem("&Course");
            ToolStripMenuItem mnuShowAttend = new ToolStripMenuItem("&ShowAttend");
            ToolStripMenuItem mnuExamResult = new ToolStripMenuItem("&Exam Result");
            ToolStripMenuItem mnuSchedule = new ToolStripMenuItem("&Schedule");
            ToolStripSeparator separator = new ToolStripSeparator();
            ToolStripMenuItem mnuExit = new ToolStripMenuItem("&Exit");
            ToolStripMenuItem mnuWindow = new ToolStripMenuItem("&Window");
            // mainMenu 
            mainMenu.Items.AddRange(new ToolStripItem[] { menuFile, mnuWindow });
            mainMenu.MdiWindowListItem = mnuWindow;
            //menuFile 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] {mnuCourse, mnuShowAttend, mnuExamResult, mnuSchedule, separator, mnuExit });
            //mnuOpen 
            mnuShowAttend.ShortcutKeys = (Keys)((Keys.Control | Keys.A));
            mnuShowAttend.Click += new EventHandler(mnuShowAttend_Click);

              mnuSchedule.ShortcutKeys = (Keys)((Keys.Control | Keys.P));
             mnuSchedule.Click += new EventHandler(mnuSchedule_Click);

            mnuExamResult.ShortcutKeys=(Keys)((Keys.Control| Keys.R));
            mnuExamResult.Click += new EventHandler(mnuExamResult_Click);
            mnuCourse.ShortcutKeys= (Keys)((Keys.Control | Keys.C));
            mnuCourse.Click += new EventHandler(mnuCourse_Click);
            // mnuExit 
            mnuExit.ShortcutKeys = (Keys)((Keys.Alt | Keys.X));
            mnuExit.Click += new EventHandler(mnuExit_Click);

        }
        private void mnuShowAttend_Click(object sender, EventArgs e)
        {
            frmShowAttend frmAccount = new frmShowAttend
            {
                LoginInfo = LoginInfo,
            };
            frmAccount.Text = $"ShowAttendForm {counter++:D2}";
            frmAccount.MdiParent = this;
            frmAccount.Show();

        }//end mnuOpen_Click 
        private void mnuExamResult_Click (object sender, EventArgs e)
        {
            frmShowResult frmAccount = new frmShowResult
            {
                LoginInfo = LoginInfo,
            };
            frmAccount.Text = $"ShowExamResultForm {counter++:D2}";
            frmAccount.MdiParent = this;
            frmAccount.Show();

        }//end mnuOpen_Click 
        private void mnuSchedule_Click(object sender,EventArgs e)
        {
            frmSchedule frmSchedule = new frmSchedule
            {
                LoginInfo=LoginInfo
            };
            frmSchedule.Text = $"ShowScheduleForm {counter++:D2}";
            frmSchedule.MdiParent = this;
            frmSchedule.Show();
        }
        private void mnuCourse_Click(object sender,EventArgs e)
        {
            frmFullCourse frmFullCourse = new frmFullCourse();
            frmFullCourse.Text = $"ShowFullCourseForm {counter++:D2}";
            frmFullCourse.MdiParent = this;
            frmFullCourse.Show();
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
