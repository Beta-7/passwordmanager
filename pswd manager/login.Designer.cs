namespace pswd_manager
{
    partial class loginForm
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
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.continueBtn = new System.Windows.Forms.Button();
            this.newUserCB = new System.Windows.Forms.CheckBox();
            this.confirmPWTB = new System.Windows.Forms.TextBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.showPWCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(12, 12);
            this.usernameTB.MaxLength = 50;
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(100, 20);
            this.usernameTB.TabIndex = 0;
            this.usernameTB.Text = "Enter username";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(140, 12);
            this.passwordTB.MaxLength = 50;
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(100, 20);
            this.passwordTB.TabIndex = 1;
            this.passwordTB.Text = "Enter password";
            // 
            // continueBtn
            // 
            this.continueBtn.Location = new System.Drawing.Point(140, 115);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(100, 35);
            this.continueBtn.TabIndex = 5;
            this.continueBtn.Text = "&Login";
            this.continueBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // newUserCB
            // 
            this.newUserCB.AutoSize = true;
            this.newUserCB.Location = new System.Drawing.Point(12, 41);
            this.newUserCB.Name = "newUserCB";
            this.newUserCB.Size = new System.Drawing.Size(71, 17);
            this.newUserCB.TabIndex = 2;
            this.newUserCB.Text = "&New user";
            this.newUserCB.UseVisualStyleBackColor = true;
            this.newUserCB.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // confirmPWTB
            // 
            this.confirmPWTB.Location = new System.Drawing.Point(140, 38);
            this.confirmPWTB.MaxLength = 50;
            this.confirmPWTB.Name = "confirmPWTB";
            this.confirmPWTB.PasswordChar = '*';
            this.confirmPWTB.Size = new System.Drawing.Size(100, 20);
            this.confirmPWTB.TabIndex = 3;
            this.confirmPWTB.Text = "Confirm password";
            this.confirmPWTB.Visible = false;
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitBtn.Location = new System.Drawing.Point(12, 115);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(100, 35);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "&Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // showPWCB
            // 
            this.showPWCB.AutoSize = true;
            this.showPWCB.Location = new System.Drawing.Point(12, 64);
            this.showPWCB.Name = "showPWCB";
            this.showPWCB.Size = new System.Drawing.Size(107, 17);
            this.showPWCB.TabIndex = 6;
            this.showPWCB.Text = "&Show Passwords";
            this.showPWCB.UseVisualStyleBackColor = true;
            this.showPWCB.CheckedChanged += new System.EventHandler(this.ShowPWCB_CheckedChanged);
            // 
            // loginForm
            // 
            this.AcceptButton = this.continueBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitBtn;
            this.ClientSize = new System.Drawing.Size(256, 162);
            this.Controls.Add(this.showPWCB);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.confirmPWTB);
            this.Controls.Add(this.newUserCB);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login in to Betapass";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.CheckBox newUserCB;
        private System.Windows.Forms.TextBox confirmPWTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.CheckBox showPWCB;
    }
}

