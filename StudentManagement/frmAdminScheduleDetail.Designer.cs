namespace StudentManagement
{
    partial class frmAdminScheduleDetail
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
            this.lbScheduleID = new System.Windows.Forms.Label();
            this.lbAcountID = new System.Windows.Forms.Label();
            this.lbCourse = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.cboAccountID = new System.Windows.Forms.ComboBox();
            this.cboCourseID = new System.Windows.Forms.ComboBox();
            this.txtScheduleID = new System.Windows.Forms.TextBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbScheduleID
            // 
            this.lbScheduleID.AutoSize = true;
            this.lbScheduleID.Location = new System.Drawing.Point(26, 43);
            this.lbScheduleID.Name = "lbScheduleID";
            this.lbScheduleID.Size = new System.Drawing.Size(84, 20);
            this.lbScheduleID.TabIndex = 0;
            this.lbScheduleID.Text = "ScheduleID";
            // 
            // lbAcountID
            // 
            this.lbAcountID.AutoSize = true;
            this.lbAcountID.Location = new System.Drawing.Point(26, 104);
            this.lbAcountID.Name = "lbAcountID";
            this.lbAcountID.Size = new System.Drawing.Size(78, 20);
            this.lbAcountID.TabIndex = 1;
            this.lbAcountID.Text = "AccountID";
            // 
            // lbCourse
            // 
            this.lbCourse.AutoSize = true;
            this.lbCourse.Location = new System.Drawing.Point(30, 167);
            this.lbCourse.Name = "lbCourse";
            this.lbCourse.Size = new System.Drawing.Size(69, 20);
            this.lbCourse.TabIndex = 2;
            this.lbCourse.Text = "CourseID";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(26, 227);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(76, 20);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "Start Date";
            // 
            // cboAccountID
            // 
            this.cboAccountID.FormattingEnabled = true;
            this.cboAccountID.Location = new System.Drawing.Point(139, 100);
            this.cboAccountID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboAccountID.Name = "cboAccountID";
            this.cboAccountID.Size = new System.Drawing.Size(292, 28);
            this.cboAccountID.TabIndex = 4;
            // 
            // cboCourseID
            // 
            this.cboCourseID.FormattingEnabled = true;
            this.cboCourseID.Location = new System.Drawing.Point(139, 167);
            this.cboCourseID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCourseID.Name = "cboCourseID";
            this.cboCourseID.Size = new System.Drawing.Size(292, 28);
            this.cboCourseID.TabIndex = 5;
            // 
            // txtScheduleID
            // 
            this.txtScheduleID.Location = new System.Drawing.Point(139, 32);
            this.txtScheduleID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScheduleID.Name = "txtScheduleID";
            this.txtScheduleID.Size = new System.Drawing.Size(292, 27);
            this.txtScheduleID.TabIndex = 6;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "hh:mm:ss dddd MMMM dd, yyyy";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(139, 220);
            this.dtpTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(292, 27);
            this.dtpTime.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(84, 347);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(378, 356);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "hh:mm:ss dddd MMMM dd, yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(139, 286);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(292, 27);
            this.dtpEndDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "End Date";
            // 
            // frmAdminScheduleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.txtScheduleID);
            this.Controls.Add(this.cboCourseID);
            this.Controls.Add(this.cboAccountID);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbCourse);
            this.Controls.Add(this.lbAcountID);
            this.Controls.Add(this.lbScheduleID);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdminScheduleDetail";
            this.Text = "frmScheduleDetail";
            this.Load += new System.EventHandler(this.frmScheduleDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbScheduleID;
        private Label lbAcountID;
        private Label lbCourse;
        private Label lbTime;
        private ComboBox cboAccountID;
        private ComboBox cboCourseID;
        private TextBox txtScheduleID;
        private DateTimePicker dtpTime;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpEndDate;
        private Label label1;
    }
}