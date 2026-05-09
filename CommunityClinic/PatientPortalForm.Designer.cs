namespace CommunityClinic
{
    partial class PatientPortalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.btnLoadProfile = new System.Windows.Forms.Button();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpAppointment = new System.Windows.Forms.DateTimePicker();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReschedule = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefreshAppointments = new System.Windows.Forms.Button();
            this.btnBookAppointment = new System.Windows.Forms.Button();
            this.dgvappointments1 = new System.Windows.Forms.DataGridView();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.btnLoadHistory = new System.Windows.Forms.Button();
            this.dgvHistory1 = new System.Windows.Forms.DataGridView();
            this.Logout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvappointments1)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Controls.Add(this.tabAppointments);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Controls.Add(this.label4);
            this.tabProfile.Controls.Add(this.label5);
            this.tabProfile.Controls.Add(this.txtFullName);
            this.tabProfile.Controls.Add(this.txtPhone);
            this.tabProfile.Controls.Add(this.txtEmail);
            this.tabProfile.Controls.Add(this.txtAddress);
            this.tabProfile.Controls.Add(this.dtDOB);
            this.tabProfile.Controls.Add(this.btnLoadProfile);
            this.tabProfile.Controls.Add(this.btnUpdateProfile);
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(952, 474);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phone";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date of Birth";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(150, 20);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(250, 20);
            this.txtFullName.TabIndex = 5;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(150, 60);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(150, 140);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 20);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // dtDOB
            // 
            this.dtDOB.Location = new System.Drawing.Point(150, 180);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(250, 20);
            this.dtDOB.TabIndex = 9;
            this.dtDOB.ValueChanged += new System.EventHandler(this.dtDOB_ValueChanged);
            // 
            // btnLoadProfile
            // 
            this.btnLoadProfile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLoadProfile.Location = new System.Drawing.Point(20, 240);
            this.btnLoadProfile.Name = "btnLoadProfile";
            this.btnLoadProfile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadProfile.TabIndex = 10;
            this.btnLoadProfile.Text = "Load Profile";
            this.btnLoadProfile.UseVisualStyleBackColor = false;
            this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUpdateProfile.Location = new System.Drawing.Point(160, 240);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateProfile.TabIndex = 11;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // tabAppointments
            // 
            this.tabAppointments.Controls.Add(this.txtDocName);
            this.tabAppointments.Controls.Add(this.label8);
            this.tabAppointments.Controls.Add(this.dtpAppointment);
            this.tabAppointments.Controls.Add(this.txtReason);
            this.tabAppointments.Controls.Add(this.label7);
            this.tabAppointments.Controls.Add(this.label6);
            this.tabAppointments.Controls.Add(this.btnReschedule);
            this.tabAppointments.Controls.Add(this.btnCancel);
            this.tabAppointments.Controls.Add(this.btnRefreshAppointments);
            this.tabAppointments.Controls.Add(this.btnBookAppointment);
            this.tabAppointments.Controls.Add(this.dgvappointments1);
            this.tabAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Size = new System.Drawing.Size(952, 474);
            this.tabAppointments.TabIndex = 1;
            this.tabAppointments.Text = "Appointments";
            // 
            // txtDocName
            // 
            this.txtDocName.Location = new System.Drawing.Point(103, 299);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(290, 20);
            this.txtDocName.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Doctor\'s Name";
            // 
            // dtpAppointment
            // 
            this.dtpAppointment.Location = new System.Drawing.Point(70, 338);
            this.dtpAppointment.Name = "dtpAppointment";
            this.dtpAppointment.Size = new System.Drawing.Size(200, 20);
            this.dtpAppointment.TabIndex = 8;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(70, 261);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(323, 20);
            this.txtReason.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Reason";
            // 
            // btnReschedule
            // 
            this.btnReschedule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnReschedule.Location = new System.Drawing.Point(368, 18);
            this.btnReschedule.Name = "btnReschedule";
            this.btnReschedule.Size = new System.Drawing.Size(75, 23);
            this.btnReschedule.TabIndex = 4;
            this.btnReschedule.Text = "Reschedule";
            this.btnReschedule.UseVisualStyleBackColor = false;
            this.btnReschedule.Click += new System.EventHandler(this.btnReschedule_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCancel.Location = new System.Drawing.Point(256, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefreshAppointments
            // 
            this.btnRefreshAppointments.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRefreshAppointments.Location = new System.Drawing.Point(20, 20);
            this.btnRefreshAppointments.Name = "btnRefreshAppointments";
            this.btnRefreshAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshAppointments.TabIndex = 0;
            this.btnRefreshAppointments.Text = "Refresh";
            this.btnRefreshAppointments.UseVisualStyleBackColor = false;
            this.btnRefreshAppointments.Click += new System.EventHandler(this.btnRefreshAppointments_Click);
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBookAppointment.Location = new System.Drawing.Point(140, 20);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnBookAppointment.TabIndex = 1;
            this.btnBookAppointment.Text = "Book Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = false;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);
            // 
            // dgvappointments1
            // 
            this.dgvappointments1.Location = new System.Drawing.Point(20, 60);
            this.dgvappointments1.Name = "dgvappointments1";
            this.dgvappointments1.Size = new System.Drawing.Size(880, 181);
            this.dgvappointments1.TabIndex = 2;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.btnLoadHistory);
            this.tabHistory.Controls.Add(this.dgvHistory1);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(952, 474);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "Medical History";
            // 
            // btnLoadHistory
            // 
            this.btnLoadHistory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLoadHistory.Location = new System.Drawing.Point(20, 20);
            this.btnLoadHistory.Name = "btnLoadHistory";
            this.btnLoadHistory.Size = new System.Drawing.Size(75, 23);
            this.btnLoadHistory.TabIndex = 0;
            this.btnLoadHistory.Text = "Load History";
            this.btnLoadHistory.UseVisualStyleBackColor = false;
            this.btnLoadHistory.Click += new System.EventHandler(this.btnLoadHistory_Click);
            // 
            // dgvHistory1
            // 
            this.dgvHistory1.Location = new System.Drawing.Point(20, 60);
            this.dgvHistory1.Name = "dgvHistory1";
            this.dgvHistory1.Size = new System.Drawing.Size(880, 320);
            this.dgvHistory1.TabIndex = 1;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Logout.Location = new System.Drawing.Point(820, 530);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 2;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Location = new System.Drawing.Point(700, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button3.Location = new System.Drawing.Point(902, 530);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnExit.Location = new System.Drawing.Point(619, 530);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PatientPortalForm
            // 
            this.BackgroundImage = global::CommunityClinic.Properties.Resources.image0;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Logout);
            this.Name = "PatientPortalForm";
            this.Text = "Patient Portal";
            this.Load += new System.EventHandler(this.PatientPortalForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabAppointments.ResumeLayout(false);
            this.tabAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvappointments1)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;

        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.TabPage tabHistory;

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.DateTimePicker dtDOB;

        private System.Windows.Forms.Button btnLoadProfile;
        private System.Windows.Forms.Button btnUpdateProfile;

        private System.Windows.Forms.DataGridView dgvappointments1;
        private System.Windows.Forms.DataGridView dgvHistory1;

        private System.Windows.Forms.Button btnRefreshAppointments;
        private System.Windows.Forms.Button btnBookAppointment;
        private System.Windows.Forms.Button btnLoadHistory;

        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReschedule;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAppointment;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Label label8;
    }
}