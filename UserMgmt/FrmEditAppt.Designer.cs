namespace UserMgmt
{
    partial class FrmEditAppt
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
            this.radioYes = new System.Windows.Forms.RadioButton();
            this.radioNo = new System.Windows.Forms.RadioButton();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.pnlNewPatient = new System.Windows.Forms.Panel();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.cmbDocName = new System.Windows.Forms.ComboBox();
            this.dtpApptDate = new System.Windows.Forms.DateTimePicker();
            this.lblDocName = new System.Windows.Forms.Label();
            this.lblApptDate = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.lblApptTime = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmbApptType = new System.Windows.Forms.ComboBox();
            this.lblApptType = new System.Windows.Forms.Label();
            this.lblNewPatient = new System.Windows.Forms.Label();
            this.cmbParish = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lblParish = new System.Windows.Forms.Label();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblLastN = new System.Windows.Forms.Label();
            this.lblFirstN = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblCell = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHeadingEditAppt = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlNewPatient.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioYes
            // 
            this.radioYes.AutoSize = true;
            this.radioYes.Location = new System.Drawing.Point(0, 10);
            this.radioYes.Name = "radioYes";
            this.radioYes.Size = new System.Drawing.Size(43, 17);
            this.radioYes.TabIndex = 14;
            this.radioYes.TabStop = true;
            this.radioYes.Text = "Yes";
            this.radioYes.UseVisualStyleBackColor = true;
            // 
            // radioNo
            // 
            this.radioNo.AutoSize = true;
            this.radioNo.Location = new System.Drawing.Point(76, 10);
            this.radioNo.Name = "radioNo";
            this.radioNo.Size = new System.Drawing.Size(39, 17);
            this.radioNo.TabIndex = 15;
            this.radioNo.TabStop = true;
            this.radioNo.Text = "No";
            this.radioNo.UseVisualStyleBackColor = true;
            // 
            // dtpDob
            // 
            this.dtpDob.Location = new System.Drawing.Point(195, 301);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(200, 20);
            this.dtpDob.TabIndex = 78;
            // 
            // pnlNewPatient
            // 
            this.pnlNewPatient.Controls.Add(this.radioYes);
            this.pnlNewPatient.Controls.Add(this.radioNo);
            this.pnlNewPatient.Location = new System.Drawing.Point(196, 405);
            this.pnlNewPatient.Name = "pnlNewPatient";
            this.pnlNewPatient.Size = new System.Drawing.Size(178, 32);
            this.pnlNewPatient.TabIndex = 82;
            // 
            // pnlGender
            // 
            this.pnlGender.Controls.Add(this.radioFemale);
            this.pnlGender.Controls.Add(this.radioMale);
            this.pnlGender.Location = new System.Drawing.Point(196, 253);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(178, 32);
            this.pnlGender.TabIndex = 77;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(76, 11);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(59, 17);
            this.radioFemale.TabIndex = 9;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(0, 11);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(48, 17);
            this.radioMale.TabIndex = 8;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // cmbDocName
            // 
            this.cmbDocName.FormattingEnabled = true;
            this.cmbDocName.Location = new System.Drawing.Point(196, 527);
            this.cmbDocName.Name = "cmbDocName";
            this.cmbDocName.Size = new System.Drawing.Size(182, 21);
            this.cmbDocName.TabIndex = 85;
            // 
            // dtpApptDate
            // 
            this.dtpApptDate.Location = new System.Drawing.Point(196, 449);
            this.dtpApptDate.Name = "dtpApptDate";
            this.dtpApptDate.Size = new System.Drawing.Size(200, 20);
            this.dtpApptDate.TabIndex = 83;
            // 
            // lblDocName
            // 
            this.lblDocName.AutoSize = true;
            this.lblDocName.Location = new System.Drawing.Point(52, 530);
            this.lblDocName.Name = "lblDocName";
            this.lblDocName.Size = new System.Drawing.Size(39, 13);
            this.lblDocName.TabIndex = 107;
            this.lblDocName.Text = "Doctor";
            // 
            // lblApptDate
            // 
            this.lblApptDate.AutoSize = true;
            this.lblApptDate.Location = new System.Drawing.Point(50, 457);
            this.lblApptDate.Name = "lblApptDate";
            this.lblApptDate.Size = new System.Drawing.Size(92, 13);
            this.lblApptDate.TabIndex = 106;
            this.lblApptDate.Text = "Appointment Date";
            // 
            // cmbTime
            // 
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(195, 487);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(121, 21);
            this.cmbTime.TabIndex = 84;
            // 
            // lblApptTime
            // 
            this.lblApptTime.AutoSize = true;
            this.lblApptTime.Location = new System.Drawing.Point(50, 495);
            this.lblApptTime.Name = "lblApptTime";
            this.lblApptTime.Size = new System.Drawing.Size(92, 13);
            this.lblApptTime.TabIndex = 105;
            this.lblApptTime.Text = "Appointment Time";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(195, 571);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(374, 200);
            this.txtNotes.TabIndex = 86;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(54, 571);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 104;
            this.lblNotes.Text = "Notes";
            // 
            // cmbApptType
            // 
            this.cmbApptType.FormattingEnabled = true;
            this.cmbApptType.Location = new System.Drawing.Point(196, 104);
            this.cmbApptType.Name = "cmbApptType";
            this.cmbApptType.Size = new System.Drawing.Size(182, 21);
            this.cmbApptType.TabIndex = 71;
            // 
            // lblApptType
            // 
            this.lblApptType.AutoSize = true;
            this.lblApptType.Location = new System.Drawing.Point(50, 112);
            this.lblApptType.Name = "lblApptType";
            this.lblApptType.Size = new System.Drawing.Size(93, 13);
            this.lblApptType.TabIndex = 103;
            this.lblApptType.Text = "Appointment Type";
            // 
            // lblNewPatient
            // 
            this.lblNewPatient.AutoSize = true;
            this.lblNewPatient.Location = new System.Drawing.Point(50, 417);
            this.lblNewPatient.Name = "lblNewPatient";
            this.lblNewPatient.Size = new System.Drawing.Size(110, 13);
            this.lblNewPatient.TabIndex = 102;
            this.lblNewPatient.Text = "Are you a new patient";
            // 
            // cmbParish
            // 
            this.cmbParish.FormattingEnabled = true;
            this.cmbParish.Location = new System.Drawing.Point(388, 379);
            this.cmbParish.Name = "cmbParish";
            this.cmbParish.Size = new System.Drawing.Size(182, 21);
            this.cmbParish.TabIndex = 81;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(462, 801);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(108, 23);
            this.btnSaveChanges.TabIndex = 101;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // lblParish
            // 
            this.lblParish.AutoSize = true;
            this.lblParish.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParish.Location = new System.Drawing.Point(392, 366);
            this.lblParish.Name = "lblParish";
            this.lblParish.Size = new System.Drawing.Size(32, 14);
            this.lblParish.TabIndex = 99;
            this.lblParish.Text = "Parish";
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.Location = new System.Drawing.Point(200, 366);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(29, 14);
            this.lblTown.TabIndex = 98;
            this.lblTown.Text = "Town";
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(196, 379);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(182, 20);
            this.txtTown.TabIndex = 80;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(196, 338);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(374, 20);
            this.txtAddress.TabIndex = 79;
            // 
            // lblLastN
            // 
            this.lblLastN.AutoSize = true;
            this.lblLastN.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastN.Location = new System.Drawing.Point(392, 142);
            this.lblLastN.Name = "lblLastN";
            this.lblLastN.Size = new System.Drawing.Size(24, 14);
            this.lblLastN.TabIndex = 97;
            this.lblLastN.Text = "Last";
            // 
            // lblFirstN
            // 
            this.lblFirstN.AutoSize = true;
            this.lblFirstN.Font = new System.Drawing.Font("Segoe Print", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstN.Location = new System.Drawing.Point(200, 142);
            this.lblFirstN.Name = "lblFirstN";
            this.lblFirstN.Size = new System.Drawing.Size(25, 14);
            this.lblFirstN.TabIndex = 96;
            this.lblFirstN.Text = "First";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(196, 227);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(229, 20);
            this.txtEmail.TabIndex = 76;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(389, 195);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(41, 13);
            this.lblMobile.TabIndex = 95;
            this.lblMobile.Text = "Mobile:";
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(193, 195);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(27, 13);
            this.lblCell.TabIndex = 94;
            this.lblCell.Text = "Cell:";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(432, 191);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(124, 20);
            this.txtMobile.TabIndex = 75;
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(223, 191);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(124, 20);
            this.txtCell.TabIndex = 74;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(388, 155);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(182, 20);
            this.txtLastName.TabIndex = 73;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(196, 155);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(182, 20);
            this.txtFirstName.TabIndex = 72;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(50, 345);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 93;
            this.lblAddress.Text = "Address";
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(50, 306);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(66, 13);
            this.lblDob.TabIndex = 92;
            this.lblDob.Text = "Date of Birth";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(50, 269);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 91;
            this.lblGender.Text = "Gender";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(50, 198);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 89;
            this.lblPhone.Text = "Phone";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 155);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 88;
            this.lblName.Text = "Name";
            // 
            // lblHeadingEditAppt
            // 
            this.lblHeadingEditAppt.AutoSize = true;
            this.lblHeadingEditAppt.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingEditAppt.Location = new System.Drawing.Point(44, 25);
            this.lblHeadingEditAppt.Name = "lblHeadingEditAppt";
            this.lblHeadingEditAppt.Size = new System.Drawing.Size(373, 56);
            this.lblHeadingEditAppt.TabIndex = 87;
            this.lblHeadingEditAppt.Text = "Edit an Appointment";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 234);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 90;
            this.lblEmail.Text = "Email";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(350, 801);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 100;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // FrmEditAppt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 866);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.pnlNewPatient);
            this.Controls.Add(this.pnlGender);
            this.Controls.Add(this.cmbDocName);
            this.Controls.Add(this.dtpApptDate);
            this.Controls.Add(this.lblDocName);
            this.Controls.Add(this.lblApptDate);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.lblApptTime);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cmbApptType);
            this.Controls.Add(this.lblApptType);
            this.Controls.Add(this.lblNewPatient);
            this.Controls.Add(this.cmbParish);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblParish);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblLastN);
            this.Controls.Add(this.lblFirstN);
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
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHeadingEditAppt);
            this.Controls.Add(this.lblEmail);
            this.Name = "FrmEditAppt";
            this.Text = "Edit Appointments";
            this.Load += new System.EventHandler(this.FrmEditAppt_Load);
            this.pnlNewPatient.ResumeLayout(false);
            this.pnlNewPatient.PerformLayout();
            this.pnlGender.ResumeLayout(false);
            this.pnlGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioYes;
        private System.Windows.Forms.RadioButton radioNo;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Panel pnlNewPatient;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.ComboBox cmbDocName;
        private System.Windows.Forms.DateTimePicker dtpApptDate;
        private System.Windows.Forms.Label lblDocName;
        private System.Windows.Forms.Label lblApptDate;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Label lblApptTime;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cmbApptType;
        private System.Windows.Forms.Label lblApptType;
        private System.Windows.Forms.Label lblNewPatient;
        private System.Windows.Forms.ComboBox cmbParish;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label lblParish;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblLastN;
        private System.Windows.Forms.Label lblFirstN;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblCell;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHeadingEditAppt;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnClear;
    }
}