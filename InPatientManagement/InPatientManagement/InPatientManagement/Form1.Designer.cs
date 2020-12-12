namespace InPatientManagement
{
    partial class frmScreen
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
            this.btnDOCTOR = new System.Windows.Forms.Button();
            this.btnNURSE = new System.Windows.Forms.Button();
            this.btnACCOUNTANT = new System.Windows.Forms.Button();
            this.btnADMIN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDOCTOR
            // 
            this.btnDOCTOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDOCTOR.Location = new System.Drawing.Point(164, 253);
            this.btnDOCTOR.Name = "btnDOCTOR";
            this.btnDOCTOR.Size = new System.Drawing.Size(119, 61);
            this.btnDOCTOR.TabIndex = 0;
            this.btnDOCTOR.Text = "DOCTOR";
            this.btnDOCTOR.UseVisualStyleBackColor = true;
            this.btnDOCTOR.Click += new System.EventHandler(this.btnDOCTOR_Click);
            // 
            // btnNURSE
            // 
            this.btnNURSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNURSE.Location = new System.Drawing.Point(308, 253);
            this.btnNURSE.Name = "btnNURSE";
            this.btnNURSE.Size = new System.Drawing.Size(122, 61);
            this.btnNURSE.TabIndex = 1;
            this.btnNURSE.Text = "NURSE";
            this.btnNURSE.UseVisualStyleBackColor = true;
            this.btnNURSE.Click += new System.EventHandler(this.btnNURSE_Click);
            // 
            // btnACCOUNTANT
            // 
            this.btnACCOUNTANT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnACCOUNTANT.Location = new System.Drawing.Point(451, 253);
            this.btnACCOUNTANT.Name = "btnACCOUNTANT";
            this.btnACCOUNTANT.Size = new System.Drawing.Size(122, 61);
            this.btnACCOUNTANT.TabIndex = 2;
            this.btnACCOUNTANT.Text = "ACCOUNTANT";
            this.btnACCOUNTANT.UseVisualStyleBackColor = true;
            // 
            // btnADMIN
            // 
            this.btnADMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnADMIN.Location = new System.Drawing.Point(588, 253);
            this.btnADMIN.Name = "btnADMIN";
            this.btnADMIN.Size = new System.Drawing.Size(122, 61);
            this.btnADMIN.TabIndex = 3;
            this.btnADMIN.Text = "ADMIN";
            this.btnADMIN.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(842, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "WELCOME TO IN-PATIENT MANAGEMENT SYSTEM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::InPatientManagement.Properties.Resources.doctor1;
            this.pictureBox2.Location = new System.Drawing.Point(164, 139);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 105);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Image = global::InPatientManagement.Properties.Resources.admin;
            this.pictureBox4.Location = new System.Drawing.Point(588, 139);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(122, 105);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::InPatientManagement.Properties.Resources.acc;
            this.pictureBox3.Location = new System.Drawing.Point(451, 139);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(122, 105);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::InPatientManagement.Properties.Resources.nurse;
            this.pictureBox1.Location = new System.Drawing.Point(308, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 105);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(913, 368);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnADMIN);
            this.Controls.Add(this.btnACCOUNTANT);
            this.Controls.Add(this.btnNURSE);
            this.Controls.Add(this.btnDOCTOR);
            this.Name = "frmScreen";
            this.Text = "In-Patient Management-Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDOCTOR;
        private System.Windows.Forms.Button btnNURSE;
        private System.Windows.Forms.Button btnACCOUNTANT;
        private System.Windows.Forms.Button btnADMIN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
    }
}

