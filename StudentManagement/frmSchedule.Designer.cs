using System.Windows.Forms;

namespace StudentManagement
{
    partial class frmSchedule
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
            this.lbAccountID = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.txtScheduleID = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lbCourseID = new System.Windows.Forms.Label();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScheduleID
            // 
            this.lbScheduleID.AutoSize = true;
            this.lbScheduleID.Location = new System.Drawing.Point(54, 41);
            this.lbScheduleID.Name = "lbScheduleID";
            this.lbScheduleID.Size = new System.Drawing.Size(88, 20);
            this.lbScheduleID.TabIndex = 0;
            this.lbScheduleID.Text = "Schedule ID";
            // 
            // lbAccountID
            // 
            this.lbAccountID.AutoSize = true;
            this.lbAccountID.Location = new System.Drawing.Point(61, 101);
            this.lbAccountID.Name = "lbAccountID";
            this.lbAccountID.Size = new System.Drawing.Size(78, 20);
            this.lbAccountID.TabIndex = 1;
            this.lbAccountID.Text = "AccountID";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(91, 157);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(46, 20);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "Time ";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(29, 240);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 25;
            this.dgvSchedule.Size = new System.Drawing.Size(662, 246);
            this.dgvSchedule.TabIndex = 6;
            this.dgvSchedule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellDoubleClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(762, 262);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(86, 31);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(762, 339);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 31);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(762, 405);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 31);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExist
            // 
            this.btnExist.Location = new System.Drawing.Point(990, 96);
            this.btnExist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(86, 31);
            this.btnExist.TabIndex = 10;
            this.btnExist.Text = "EXIT";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // txtScheduleID
            // 
            this.txtScheduleID.Location = new System.Drawing.Point(162, 37);
            this.txtScheduleID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScheduleID.Name = "txtScheduleID";
            this.txtScheduleID.ReadOnly = true;
            this.txtScheduleID.Size = new System.Drawing.Size(283, 27);
            this.txtScheduleID.TabIndex = 11;
            this.txtScheduleID.TabStop = false;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(162, 91);
            this.txtAccountID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.ReadOnly = true;
            this.txtAccountID.Size = new System.Drawing.Size(283, 27);
            this.txtAccountID.TabIndex = 12;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(162, 147);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(283, 27);
            this.txtTime.TabIndex = 13;
            // 
            // lbCourseID
            // 
            this.lbCourseID.AutoSize = true;
            this.lbCourseID.Location = new System.Drawing.Point(533, 41);
            this.lbCourseID.Name = "lbCourseID";
            this.lbCourseID.Size = new System.Drawing.Size(69, 20);
            this.lbCourseID.TabIndex = 14;
            this.lbCourseID.Text = "CourseID";
            // 
            // txtCourseID
            // 
            this.txtCourseID.Location = new System.Drawing.Point(617, 37);
            this.txtCourseID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.ReadOnly = true;
            this.txtCourseID.Size = new System.Drawing.Size(283, 27);
            this.txtCourseID.TabIndex = 15;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(617, 153);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(283, 27);
            this.txtEndDate.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "End Date";
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.lbCourseID);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.txtScheduleID);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbAccountID);
            this.Controls.Add(this.lbScheduleID);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSchedule";
            this.Text = "frmSchedule";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbScheduleID;
        private Label lbAccountID;
        private Label lbTime;
        private DataGridView dgvSchedule;
        private Button btnLoad;
        private Button btnNew;
        private Button btnDelete;
        private Button btnExist;
        private TextBox txtScheduleID;
        private TextBox txtAccountID;
        private TextBox txtTime;
        private Label lbCourseID;
        private TextBox txtCourseID;
        private TextBox txtEndDate;
        private Label label1;
    }
}