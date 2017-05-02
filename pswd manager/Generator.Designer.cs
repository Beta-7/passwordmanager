namespace pswd_manager
{
    partial class GeneratePWForm
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
            this.passwordLenSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cifri = new System.Windows.Forms.CheckBox();
            this.specijalni = new System.Windows.Forms.CheckBox();
            this.mali = new System.Windows.Forms.CheckBox();
            this.golemi = new System.Windows.Forms.CheckBox();
            this.textbox1 = new System.Windows.Forms.TextBox();
            this.genPasswordBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.passwordLenLB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLenSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordLenSlider
            // 
            this.passwordLenSlider.Location = new System.Drawing.Point(12, 136);
            this.passwordLenSlider.Maximum = 50;
            this.passwordLenSlider.Minimum = 4;
            this.passwordLenSlider.Name = "passwordLenSlider";
            this.passwordLenSlider.Size = new System.Drawing.Size(260, 45);
            this.passwordLenSlider.TabIndex = 9;
            this.passwordLenSlider.Value = 4;
            this.passwordLenSlider.Scroll += new System.EventHandler(this.TrackBar1_Scroll_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Numbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Special characters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "!Capital letters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Capital letters";
            // 
            // cifri
            // 
            this.cifri.AutoSize = true;
            this.cifri.Location = new System.Drawing.Point(192, 81);
            this.cifri.Name = "cifri";
            this.cifri.Size = new System.Drawing.Size(15, 14);
            this.cifri.TabIndex = 7;
            this.cifri.UseVisualStyleBackColor = true;
            // 
            // specijalni
            // 
            this.specijalni.AutoSize = true;
            this.specijalni.Location = new System.Drawing.Point(192, 58);
            this.specijalni.Name = "specijalni";
            this.specijalni.Size = new System.Drawing.Size(15, 14);
            this.specijalni.TabIndex = 5;
            this.specijalni.UseVisualStyleBackColor = true;
            // 
            // mali
            // 
            this.mali.AutoSize = true;
            this.mali.Checked = true;
            this.mali.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mali.Location = new System.Drawing.Point(192, 35);
            this.mali.Name = "mali";
            this.mali.Size = new System.Drawing.Size(15, 14);
            this.mali.TabIndex = 3;
            this.mali.UseVisualStyleBackColor = true;
            // 
            // golemi
            // 
            this.golemi.AutoSize = true;
            this.golemi.Checked = true;
            this.golemi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.golemi.Location = new System.Drawing.Point(192, 12);
            this.golemi.Name = "golemi";
            this.golemi.Size = new System.Drawing.Size(15, 14);
            this.golemi.TabIndex = 1;
            this.golemi.UseVisualStyleBackColor = true;
            // 
            // textbox1
            // 
            this.textbox1.Location = new System.Drawing.Point(12, 187);
            this.textbox1.MaxLength = 50;
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(260, 20);
            this.textbox1.TabIndex = 10;
            // 
            // genPasswordBtn
            // 
            this.genPasswordBtn.Location = new System.Drawing.Point(168, 213);
            this.genPasswordBtn.Name = "genPasswordBtn";
            this.genPasswordBtn.Size = new System.Drawing.Size(80, 36);
            this.genPasswordBtn.TabIndex = 12;
            this.genPasswordBtn.Text = "&Generate";
            this.genPasswordBtn.UseVisualStyleBackColor = true;
            this.genPasswordBtn.Click += new System.EventHandler(this.GenerirajPassword_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(38, 213);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(78, 36);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // passwordLenLB
            // 
            this.passwordLenLB.AutoSize = true;
            this.passwordLenLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLenLB.ForeColor = System.Drawing.Color.Red;
            this.passwordLenLB.Location = new System.Drawing.Point(44, 117);
            this.passwordLenLB.Name = "passwordLenLB";
            this.passwordLenLB.Size = new System.Drawing.Size(186, 16);
            this.passwordLenLB.TabIndex = 8;
            this.passwordLenLB.Text = "Selected password length is 4";
            // 
            // GeneratePWForm
            // 
            this.AcceptButton = this.genPasswordBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.passwordLenLB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.passwordLenSlider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cifri);
            this.Controls.Add(this.specijalni);
            this.Controls.Add(this.mali);
            this.Controls.Add(this.golemi);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.genPasswordBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GeneratePWForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate password";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GeneratePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.passwordLenSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar passwordLenSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cifri;
        private System.Windows.Forms.CheckBox specijalni;
        private System.Windows.Forms.CheckBox mali;
        private System.Windows.Forms.CheckBox golemi;
        private System.Windows.Forms.TextBox textbox1;
        private System.Windows.Forms.Button genPasswordBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label passwordLenLB;
    }
}