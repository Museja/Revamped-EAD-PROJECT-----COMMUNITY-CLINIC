namespace UserMgmt
{
    partial class FrmPortal
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnEditUsers = new System.Windows.Forms.Button();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.btnNewAppt = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblCell = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.lblFirstN = new System.Windows.Forms.Label();
            this.lblLastN = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.lblParish = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.cmbParish = new System.Windows.Forms.ComboBox();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(102, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(432, 56);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "User Management Portal";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlLeft.Controls.Add(this.btnEditUsers);
            this.pnlLeft.Controls.Add(this.btnViewUsers);
            this.pnlLeft.Controls.Add(this.btnNewAppt);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(126, 450);
            this.pnlLeft.TabIndex = 1;
            // 
            // btnEditUsers(btnViewAppt)
            // 
            this.btnEditUsers.Location = new System.Drawing.Point(12, 215);
            this.btnEditUsers.Name = "btnViewAppt";
            this.btnEditUsers.Size = new System.Drawing.Size(93, 38);
            this.btnEditUsers.TabIndex = 2;
            this.btnEditUsers.Text = "View Appointments";
            this.btnEditUsers.UseVisualStyleBackColor = true;
            this.btnEditUsers.Click += new System.EventHandler(this.btnViewAppt_Click);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Location = new System.Drawing.Point(12, 155);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(93, 38);
            this.btnViewUsers.TabIndex = 1;
            this.btnViewUsers.Text = "View Users";
            this.btnViewUsers.UseVisualStyleBackColor = true;
            this.btnViewUsers.Click += new System.EventHandler(this.btnViewUsers_Click);
            // 
            // btnNewAppt
            // 
            this.btnNewAppt.Location = new System.Drawing.Point(12, 97);
            this.btnNewAppt.Name = "btnNewAppt";
            this.btnNewAppt.Size = new System.Drawing.Size(93, 38);
            this.btnNewAppt.TabIndex = 0;
            this.btnNewAppt.Text = "Create New Appointment";
            this.btnNewAppt.UseVisualStyleBackColor = true;
            this.btnNewAppt.Click += new System.EventHandler(this.btnNewAppt_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(213, 104);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(213, 147);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(213, 183);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(213, 218);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender";
            this.lblGender.Click += new System.EventHandler(this.lblGender_Click);
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(213, 255);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(66, 13);
            this.lblDob.TabIndex = 6;
            this.lblDob.Text = "Date of Birth";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(213, 294);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(359, 104);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(182, 20);
            this.txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(551, 104);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(182, 20);
            this.txtLastName.TabIndex = 9;
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(386, 140);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(124, 20);
            this.txtCell.TabIndex = 10;
            this.txtCell.Enter += new System.EventHandler(this.txtCell_Enter);
            this.txtCell.Leave += new System.EventHandler(this.txtCell_Leave);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(595, 140);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(124, 20);
            this.txtMobile.TabIndex = 11;
            this.txtMobile.Enter += new System.EventHandler(this.txtMobile_Enter);
            this.txtMobile.Leave += new System.EventHandler(this.txtMobile_Leave);
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(356, 144);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(27, 13);
            this.lblCell.TabIndex = 12;
            this.lblCell.Text = "Cell:";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(552, 144);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(41, 13);
            this.lblMobile.TabIndex = 13;
            this.lblMobile.Text = "Mobile:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(359, 176);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(229, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(359, 214);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(48, 17);
            this.radioMale.TabIndex = 15;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(435, 214);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(59, 17);
            this.radioFemale.TabIndex = 16;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // dtpDob
            // 
            this.dtpDob.Location = new System.Drawing.Point(359, 249);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(200, 20);
            this.dtpDob.TabIndex = 17;
            // 
            // lblFirstN
            // 
            this.lblFirstN.AutoSize = true;
            this.lblFirstN.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstN.Location = new System.Drawing.Point(362, 91);
            this.lblFirstN.Name = "lblFirstN";
            this.lblFirstN.Size = new System.Drawing.Size(25, 14);
            this.lblFirstN.TabIndex = 18;
            this.lblFirstN.Text = "First";
            // 
            // lblLastN
            // 
            this.lblLastN.AutoSize = true;
            this.lblLastN.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastN.Location = new System.Drawing.Point(555, 91);
            this.lblLastN.Name = "lblLastN";
            this.lblLastN.Size = new System.Drawing.Size(24, 14);
            this.lblLastN.TabIndex = 19;
            this.lblLastN.Text = "Last";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(359, 287);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(374, 20);
            this.txtAddress.TabIndex = 20;
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(359, 328);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(182, 20);
            this.txtTown.TabIndex = 21;
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.Location = new System.Drawing.Point(363, 315);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(29, 14);
            this.lblTown.TabIndex = 22;
            this.lblTown.Text = "Town";
            // 
            // lblParish
            // 
            this.lblParish.AutoSize = true;
            this.lblParish.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParish.Location = new System.Drawing.Point(555, 315);
            this.lblParish.Name = "lblParish";
            this.lblParish.Size = new System.Drawing.Size(32, 14);
            this.lblParish.TabIndex = 24;
            this.lblParish.Text = "Parish";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(547, 386);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(654, 386);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(75, 23);
            this.btnNewUser.TabIndex = 26;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // cmbParish
            // 
            this.cmbParish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParish.FormattingEnabled = true;
            this.cmbParish.Items.AddRange(new object[] {
            "Clarendon",
            "Hanover",
            "Kingston",
            "Manchester",
            "Portland",
            "St. Andrew",
            "St. Ann",
            "St. Catherine",
            "St. Elizabeth",
            "St. James",
            "St. Mary",
            "St. Thomas",
            "Trelawny",
            "Westmoreland "});
            this.cmbParish.Location = new System.Drawing.Point(551, 328);
            this.cmbParish.Name = "cmbParish";
            this.cmbParish.Size = new System.Drawing.Size(182, 21);
            this.cmbParish.TabIndex = 22;
            // 
            // FrmPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbParish);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblParish);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblLastN);
            this.Controls.Add(this.lblFirstN);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.radioFemale);
            this.Controls.Add(this.radioMale);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.lblCell);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtCell);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblDob);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmPortal";
            this.Text = "User Management Portal";
            this.Load += new System.EventHandler(this.FrmPortal_Load);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnViewUsers;
        private System.Windows.Forms.Button btnNewAppt;
        private System.Windows.Forms.Button btnEditUsers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblCell;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lblFirstN;
        private System.Windows.Forms.Label lblLastN;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.Label lblParish;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.ComboBox cmbParish;
    }
}

