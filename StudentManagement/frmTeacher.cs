using Microsoft.VisualBasic.Devices;
using StudentLib.Models;
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
   
    public partial class frmTeacher : Form
    {
        public Account LoginInfo { get; set; }  
        public frmTeacher()
        {
            InitializeComponent();
        }

        private void frmTeacher_Load(object sender, EventArgs e)
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
            //  ToolStripMenuItem mnuCourse = new ToolStripMenuItem("&Course");
            ToolStripMenuItem mnuAttend = new ToolStripMenuItem("&Attend");
            ToolStripMenuItem mnuCourse = new ToolStripMenuItem("&Course");
         
            ToolStripSeparator separator = new ToolStripSeparator();
            ToolStripMenuItem mnuExit = new ToolStripMenuItem("&Exit");
            ToolStripMenuItem mnuWindow = new ToolStripMenuItem("&Window");
            // mainMenu 
            mainMenu.Items.AddRange(new ToolStripItem[] { menuFile, mnuWindow });
            mainMenu.MdiWindowListItem = mnuWindow;
            //menuFile 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuAttend, mnuCourse,  separator, mnuExit });
            //mnuOpen 
            mnuAttend.ShortcutKeys = (Keys)((Keys.Control | Keys.A));
            mnuAttend.Click += new EventHandler(mnuAttend_Click);

            mnuCourse.ShortcutKeys = (Keys)((Keys.Control | Keys.P));
            mnuCourse.Click += new EventHandler(mnuCourse_Click);

            // mnuExit 
            mnuExit.ShortcutKeys = (Keys)((Keys.Alt | Keys.X));
            mnuExit.Click += new EventHandler(mnuExit_Click);

        }
        private void  mnuAttend_Click(Object sender ,EventArgs args)
        {
            frmAttendace frmAttendace = new frmAttendace
            {
                LoginInfo=LoginInfo
            };
            frmAttendace.Show();
        }
        private void mnuCourse_Click(object sender,EventArgs args)
        {
            frmShowCourse frmShowCourse = new frmShowCourse
            {
                LoginInfo = LoginInfo
            };
            frmShowCourse.Show();
        }
        private void mnuExit_Click(object sender,EventArgs args)
        {
            Close();
        }
    }
}
