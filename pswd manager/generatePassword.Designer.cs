namespace pswd_manager
{
    partial class generatePassword
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
            this.izbranaGolemina = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cifri = new System.Windows.Forms.CheckBox();
            this.specijalni = new System.Windows.Forms.CheckBox();
            this.mali = new System.Windows.Forms.CheckBox();
            this.golemi = new System.Windows.Forms.CheckBox();
            this.generiranPassword = new System.Windows.Forms.TextBox();
            this.generirajPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // izbranaGolemina
            // 
            this.izbranaGolemina.Location = new System.Drawing.Point(12, 195);
            this.izbranaGolemina.Name = "izbranaGolemina";
            this.izbranaGolemina.ReadOnly = true;
            this.izbranaGolemina.Size = new System.Drawing.Size(29, 20);
            this.izbranaGolemina.TabIndex = 25;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 144);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(260, 45);
            this.trackBar1.TabIndex = 24;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Numbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Special characters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "!Capital letters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Capital letters";
            // 
            // cifri
            // 
            this.cifri.AutoSize = true;
            this.cifri.Location = new System.Drawing.Point(192, 81);
            this.cifri.Name = "cifri";
            this.cifri.Size = new System.Drawing.Size(15, 14);
            this.cifri.TabIndex = 19;
            this.cifri.UseVisualStyleBackColor = true;
            // 
            // specijalni
            // 
            this.specijalni.AutoSize = true;
            this.specijalni.Location = new System.Drawing.Point(192, 58);
            this.specijalni.Name = "specijalni";
            this.specijalni.Size = new System.Drawing.Size(15, 14);
            this.specijalni.TabIndex = 18;
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
            this.mali.TabIndex = 17;
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
            this.golemi.TabIndex = 16;
            this.golemi.UseVisualStyleBackColor = true;
            // 
            // generiranPassword
            // 
            this.generiranPassword.Location = new System.Drawing.Point(12, 228);
            this.generiranPassword.Name = "generiranPassword";
            this.generiranPassword.Size = new System.Drawing.Size(100, 20);
            this.generiranPassword.TabIndex = 15;
            // 
            // generirajPassword
            // 
            this.generirajPassword.Location = new System.Drawing.Point(197, 226);
            this.generirajPassword.Name = "generirajPassword";
            this.generirajPassword.Size = new System.Drawing.Size(75, 23);
            this.generirajPassword.TabIndex = 14;
            this.generirajPassword.Text = "Generate";
            this.generirajPassword.UseVisualStyleBackColor = true;
            this.generirajPassword.Click += new System.EventHandler(this.generirajPassword_Click);
            // 
            // generatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.izbranaGolemina);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cifri);
            this.Controls.Add(this.specijalni);
            this.Controls.Add(this.mali);
            this.Controls.Add(this.golemi);
            this.Controls.Add(this.generiranPassword);
            this.Controls.Add(this.generirajPassword);
            this.Name = "generatePassword";
            this.Text = "generatePassword";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox izbranaGolemina;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cifri;
        private System.Windows.Forms.CheckBox specijalni;
        private System.Windows.Forms.CheckBox mali;
        private System.Windows.Forms.CheckBox golemi;
        private System.Windows.Forms.TextBox generiranPassword;
        private System.Windows.Forms.Button generirajPassword;
    }
}