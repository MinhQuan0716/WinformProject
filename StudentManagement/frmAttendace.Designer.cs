namespace StudentManagement
{
    partial class frmAttendace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbAttendID = new System.Windows.Forms.Label();
            this.lbCourseID = new System.Windows.Forms.Label();
            this.lbAccountID = new System.Windows.Forms.Label();
            this.lbSlot = new System.Windows.Forms.Label();
            this.lbAttenanceStatus = new System.Windows.Forms.Label();
            this.txtAttenanceID = new System.Windows.Forms.TextBox();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.txtAttStatus = new System.Windows.Forms.TextBox();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.btnExist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAttendID
            // 
            this.lbAttendID.AutoSize = true;
            this.lbAttendID.Location = new System.Drawing.Point(39, 53);
            this.lbAttendID.Name = "lbAttendID";
            this.lbAttendID.Size = new System.Drawing.Size(100, 20);
            this.lbAttendID.TabIndex = 0;
            this.lbAttendID.Text = "AttendanceID";
            // 
            // lbCourseID
            // 
            this.lbCourseID.AutoSize = true;
            this.lbCourseID.Location = new System.Drawing.Point(66, 121);
            this.lbCourseID.Name = "lbCourseID";
            this.lbCourseID.Size = new System.Drawing.Size(69, 20);
            this.lbCourseID.TabIndex = 1;
            this.lbCourseID.Text = "CourseID";
            // 
            // lbAccountID
            // 
            this.lbAccountID.AutoSize = true;
            this.lbAccountID.Location = new System.Drawing.Point(57, 184);
            this.lbAccountID.Name = "lbAccountID";
            this.lbAccountID.Size = new System.Drawing.Size(78, 20);
            this.lbAccountID.TabIndex = 2;
            this.lbAccountID.Text = "AccountID";
            // 
            // lbSlot
            // 
            this.lbSlot.AutoSize = true;
            this.lbSlot.Location = new System.Drawing.Point(441, 53);
            this.lbSlot.Name = "lbSlot";
            this.lbSlot.Size = new System.Drawing.Size(35, 20);
            this.lbSlot.TabIndex = 3;
            this.lbSlot.Text = "Slot";
            // 
            // lbAttenanceStatus
            // 
            this.lbAttenanceStatus.AutoSize = true;
            this.lbAttenanceStatus.Location = new System.Drawing.Point(441, 121);
            this.lbAttenanceStatus.Name = "lbAttenanceStatus";
            this.lbAttenanceStatus.Size = new System.Drawing.Size(125, 20);
            this.lbAttenanceStatus.TabIndex = 4;
            this.lbAttenanceStatus.Text = "AttendanceStatus";
            // 
            // txtAttenanceID
            // 
            this.txtAttenanceID.Location = new System.Drawing.Point(150, 49);
            this.txtAttenanceID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAttenanceID.Name = "txtAttenanceID";
            this.txtAttenanceID.ReadOnly = true;
            this.txtAttenanceID.Size = new System.Drawing.Size(258, 27);
            this.txtAttenanceID.TabIndex = 5;
            // 
            // txtCourseID
            // 
            this.txtCourseID.Location = new System.Drawing.Point(150, 121);
            this.txtCourseID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.ReadOnly = true;
            this.txtCourseID.Size = new System.Drawing.Size(258, 27);
            this.txtCourseID.TabIndex = 6;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(150, 180);
            this.txtAccountID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.ReadOnly = true;
            this.txtAccountID.Size = new System.Drawing.Size(258, 27);
            this.txtAccountID.TabIndex = 7;
            // 
            // txtSlot
            // 
            this.txtSlot.Location = new System.Drawing.Point(560, 49);
            this.txtSlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.ReadOnly = true;
            this.txtSlot.Size = new System.Drawing.Size(258, 27);
            this.txtSlot.TabIndex = 8;
            // 
            // txtAttStatus
            // 
            this.txtAttStatus.Location = new System.Drawing.Point(560, 117);
            this.txtAttStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAttStatus.Name = "txtAttStatus";
            this.txtAttStatus.ReadOnly = true;
            this.txtAttStatus.Size = new System.Drawing.Size(258, 27);
            this.txtAttStatus.TabIndex = 9;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Location = new System.Drawing.Point(24, 349);
            this.dgvAttendance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RowHeadersWidth = 51;
            this.dgvAttendance.RowTemplate.Height = 25;
            this.dgvAttendance.Size = new System.Drawing.Size(1071, 297);
            this.dgvAttendance.TabIndex = 10;
            this.dgvAttendance.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendance_CellDoubleClick);
            // 
            // btnExist
            // 
            this.btnExist.Location = new System.Drawing.Point(406, 300);
            this.btnExist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(86, 31);
            this.btnExist.TabIndex = 14;
            this.btnExist.Text = "EXIT";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Student Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(560, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(178, 27);
            this.textBox1.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(219, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 28);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search With Course";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "Take Attendance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(682, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Class Date";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(805, 219);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(178, 27);
            this.textBox2.TabIndex = 21;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(394, 226);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 28);
            this.comboBox2.TabIndex = 30;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // frmAttendace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 659);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.txtAttStatus);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.txtAttenanceID);
            this.Controls.Add(this.lbAttenanceStatus);
            this.Controls.Add(this.lbSlot);
            this.Controls.Add(this.lbAccountID);
            this.Controls.Add(this.lbCourseID);
            this.Controls.Add(this.lbAttendID);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAttendace";
            this.Text = "frmAttendace";
            this.Load += new System.EventHandler(this.frmAttendace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbAttendID;
        private Label lbCourseID;
        private Label lbAccountID;
        private Label lbSlot;
        private Label lbAttenanceStatus;
        private TextBox txtAttenanceID;
        private TextBox txtCourseID;
        private TextBox txtAccountID;
        private TextBox txtSlot;
        private TextBox txtAttStatus;
        private DataGridView dgvAttendance;
        private Button btnExist;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label2;
        private Button button1;
        private Label label3;
        private TextBox textBox2;
        private ComboBox comboBox2;
    }
}