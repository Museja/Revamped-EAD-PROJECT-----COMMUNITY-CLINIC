namespace CommunityClinic
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmpassword = new System.Windows.Forms.TextBox();
            this.Register = new System.Windows.Forms.Button();
            this.radioPatient = new System.Windows.Forms.RadioButton();
            this.radioAdmin = new System.Windows.Forms.RadioButton();
            this.lblAdminId = new System.Windows.Forms.Label();
            this.txtAdminId = new System.Windows.Forms.TextBox();
            this.radioMedicalstaff = new System.Windows.Forms.RadioButton();
            this.lblMedStaff = new System.Windows.Forms.Label();
            this.txtMedStaff = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Confirm Password";
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(573, 67);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(100, 20);
            this.txtFullname.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(573, 94);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(573, 128);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtConfirmpassword
            // 
            this.txtConfirmpassword.Location = new System.Drawing.Point(573, 162);
            this.txtConfirmpassword.Name = "txtConfirmpassword";
            this.txtConfirmpassword.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmpassword.TabIndex = 8;
            // 
            // Register
            // 
            this.Register.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Register.Location = new System.Drawing.Point(445, 327);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 9;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = false;
            this.Register.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // radioPatient
            // 
            this.radioPatient.AutoSize = true;
            this.radioPatient.Location = new System.Drawing.Point(434, 209);
            this.radioPatient.Name = "radioPatient";
            this.radioPatient.Size = new System.Drawing.Size(58, 17);
            this.radioPatient.TabIndex = 10;
            this.radioPatient.TabStop = true;
            this.radioPatient.Text = "Patient";
            this.radioPatient.UseVisualStyleBackColor = true;
            //this.radioPatient.CheckedChanged += new System.EventHandler(this.radioPatient_CheckedChanged);
            // 
            // radioAdmin
            // 
            this.radioAdmin.AutoSize = true;
            this.radioAdmin.Location = new System.Drawing.Point(552, 209);
            this.radioAdmin.Name = "radioAdmin";
            this.radioAdmin.Size = new System.Drawing.Size(83, 17);
            this.radioAdmin.TabIndex = 11;
            this.radioAdmin.TabStop = true;
            this.radioAdmin.Text = "Admnistrator";
            this.radioAdmin.UseVisualStyleBackColor = true;
            //this.radioAdmin.CheckedChanged += new System.EventHandler(this.radioAdmin_CheckedChanged);
            // 
            // lblAdminId
            // 
            this.lblAdminId.AutoSize = true;
            this.lblAdminId.Location = new System.Drawing.Point(436, 258);
            this.lblAdminId.Name = "lblAdminId";
            this.lblAdminId.Size = new System.Drawing.Size(84, 13);
            this.lblAdminId.TabIndex = 12;
            this.lblAdminId.Text = "Administrator ID:";
            //this.lblAdminId.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtAdminId
            // 
            this.txtAdminId.Location = new System.Drawing.Point(573, 251);
            this.txtAdminId.Name = "txtAdminId";
            this.txtAdminId.Size = new System.Drawing.Size(100, 20);
            this.txtAdminId.TabIndex = 13;
            //this.txtAdminId.TextChanged += new System.EventHandler(this.AdminID_TextChanged);
            // 
            // radioMedicalstaff
            // 
            this.radioMedicalstaff.AutoSize = true;
            this.radioMedicalstaff.Location = new System.Drawing.Point(678, 209);
            this.radioMedicalstaff.Name = "radioMedicalstaff";
            this.radioMedicalstaff.Size = new System.Drawing.Size(87, 17);
            this.radioMedicalstaff.TabIndex = 14;
            this.radioMedicalstaff.TabStop = true;
            this.radioMedicalstaff.Text = "Medical Staff";
            this.radioMedicalstaff.UseVisualStyleBackColor = true;
            //this.radioMedicalstaff.CheckedChanged += new System.EventHandler(this.radioMedicalstaff_CheckedChanged);
            // 
            // lblMedStaff
            // 
            this.lblMedStaff.AutoSize = true;
            this.lblMedStaff.Location = new System.Drawing.Point(436, 286);
            this.lblMedStaff.Name = "lblMedStaff";
            this.lblMedStaff.Size = new System.Drawing.Size(86, 13);
            this.lblMedStaff.TabIndex = 15;
            this.lblMedStaff.Text = "Medical Staff ID:";
            //this.lblMedStaff.Click += new System.EventHandler(this.lblMedStaff_Click);
            // 
            // txtMedStaff
            // 
            this.txtMedStaff.Location = new System.Drawing.Point(573, 286);
            this.txtMedStaff.Name = "txtMedStaff";
            this.txtMedStaff.Size = new System.Drawing.Size(100, 20);
            this.txtMedStaff.TabIndex = 16;
            //this.txtMedStaff.TextChanged += new System.EventHandler(this.txtMedStaff_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Location = new System.Drawing.Point(445, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMedStaff);
            this.Controls.Add(this.lblMedStaff);
            this.Controls.Add(this.radioMedicalstaff);
            this.Controls.Add(this.txtAdminId);
            this.Controls.Add(this.lblAdminId);
            this.Controls.Add(this.radioAdmin);
            this.Controls.Add(this.radioPatient);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.txtConfirmpassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            //this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmpassword;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.RadioButton radioPatient;
        private System.Windows.Forms.RadioButton radioAdmin;
        private System.Windows.Forms.Label lblAdminId;
        private System.Windows.Forms.TextBox txtAdminId;
        private System.Windows.Forms.RadioButton radioMedicalstaff;
        private System.Windows.Forms.Label lblMedStaff;
        private System.Windows.Forms.TextBox txtMedStaff;
        private System.Windows.Forms.Button button1;
    }
}