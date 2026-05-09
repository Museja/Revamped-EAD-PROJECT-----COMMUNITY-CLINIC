namespace CommunityClinic
{
    partial class HomeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Register = new System.Windows.Forms.Button();
            this.PatientLogin = new System.Windows.Forms.Button();
            this.StaffLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(551, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOME";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Register
            // 
            this.Register.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Register.Location = new System.Drawing.Point(558, 145);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(115, 32);
            this.Register.TabIndex = 1;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = false;
            this.Register.Click += new System.EventHandler(this.button1_Click);
            // 
            // PatientLogin
            // 
            this.PatientLogin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PatientLogin.Location = new System.Drawing.Point(558, 204);
            this.PatientLogin.Name = "PatientLogin";
            this.PatientLogin.Size = new System.Drawing.Size(115, 27);
            this.PatientLogin.TabIndex = 2;
            this.PatientLogin.Text = "Patient Login";
            this.PatientLogin.UseVisualStyleBackColor = false;
            this.PatientLogin.Click += new System.EventHandler(this.PatientLogin_Click);
            // 
            // StaffLogin
            // 
            this.StaffLogin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StaffLogin.Location = new System.Drawing.Point(558, 257);
            this.StaffLogin.Name = "StaffLogin";
            this.StaffLogin.Size = new System.Drawing.Size(115, 31);
            this.StaffLogin.TabIndex = 3;
            this.StaffLogin.Text = "Staff Login";
            this.StaffLogin.UseVisualStyleBackColor = false;
            this.StaffLogin.Click += new System.EventHandler(this.StaffLogin_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::CommunityClinic.Properties.Resources.image0;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.StaffLogin);
            this.Controls.Add(this.PatientLogin);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.label1);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Button PatientLogin;
        private System.Windows.Forms.Button StaffLogin;
    }
}