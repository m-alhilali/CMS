namespace CMS.Doctors
{
    partial class frmDoctorDetails
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
            this.label5 = new System.Windows.Forms.Label();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentSalary = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.plDoctor = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNewSalary = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlPersonInfo1 = new CMS.Controls.ctrlPersonInfo();
            this.ctrlDoctorSalariesList1 = new CMS.Contols.ctrlDoctorSalariesList();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.plDoctor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(961, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(547, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 24);
            this.label5.TabIndex = 58;
            this.label5.Text = "Current Salary:";
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.AutoSize = true;
            this.lblJoinDate.BackColor = System.Drawing.Color.White;
            this.lblJoinDate.Location = new System.Drawing.Point(688, 13);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(46, 24);
            this.lblJoinDate.TabIndex = 51;
            this.lblJoinDate.Text = "????";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(547, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 50;
            this.label6.Text = "Join Date:";
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.BackColor = System.Drawing.Color.White;
            this.lblDoctorID.Location = new System.Drawing.Point(116, 13);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(46, 24);
            this.lblDoctorID.TabIndex = 55;
            this.lblDoctorID.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 54;
            this.label4.Text = "Doctor ID:";
            // 
            // lblCurrentSalary
            // 
            this.lblCurrentSalary.AutoSize = true;
            this.lblCurrentSalary.BackColor = System.Drawing.Color.White;
            this.lblCurrentSalary.ForeColor = System.Drawing.Color.Green;
            this.lblCurrentSalary.Location = new System.Drawing.Point(688, 40);
            this.lblCurrentSalary.Name = "lblCurrentSalary";
            this.lblCurrentSalary.Size = new System.Drawing.Size(46, 24);
            this.lblCurrentSalary.TabIndex = 60;
            this.lblCurrentSalary.Text = "????";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 24);
            this.label7.TabIndex = 61;
            this.label7.Text = "Specialization:";
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.BackColor = System.Drawing.Color.White;
            this.lblSpecialization.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSpecialization.Location = new System.Drawing.Point(154, 40);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(46, 24);
            this.lblSpecialization.TabIndex = 62;
            this.lblSpecialization.Text = "????";
            // 
            // plDoctor
            // 
            this.plDoctor.BackColor = System.Drawing.Color.Transparent;
            this.plDoctor.Controls.Add(this.lblIsActive);
            this.plDoctor.Controls.Add(this.label3);
            this.plDoctor.Controls.Add(this.label7);
            this.plDoctor.Controls.Add(this.lblCurrentSalary);
            this.plDoctor.Controls.Add(this.lblSpecialization);
            this.plDoctor.Controls.Add(this.label5);
            this.plDoctor.Controls.Add(this.label4);
            this.plDoctor.Controls.Add(this.lblJoinDate);
            this.plDoctor.Controls.Add(this.lblDoctorID);
            this.plDoctor.Controls.Add(this.label6);
            this.plDoctor.EdgeWidth = 1;
            this.plDoctor.FillColor = System.Drawing.Color.White;
            this.plDoctor.Location = new System.Drawing.Point(4, 362);
            this.plDoctor.Name = "plDoctor";
            this.plDoctor.Radius = 3;
            this.plDoctor.ShadowColor = System.Drawing.Color.Black;
            this.plDoctor.ShadowShift = 2;
            this.plDoctor.Size = new System.Drawing.Size(955, 73);
            this.plDoctor.TabIndex = 63;
            this.plDoctor.Paint += new System.Windows.Forms.PaintEventHandler(this.plDoctor_Paint);
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.BackColor = System.Drawing.Color.White;
            this.lblIsActive.Location = new System.Drawing.Point(379, 13);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(46, 24);
            this.lblIsActive.TabIndex = 64;
            this.lblIsActive.Text = "????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(280, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 63;
            this.label3.Text = "Is Active:";
            // 
            // btnNewSalary
            // 
            this.btnNewSalary.BackColor = System.Drawing.Color.DarkGreen;
            this.btnNewSalary.BorderRadius = 4;
            this.btnNewSalary.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnNewSalary.BorderThickness = 1;
            this.btnNewSalary.CausesValidation = false;
            this.btnNewSalary.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewSalary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNewSalary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNewSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNewSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNewSalary.FillColor = System.Drawing.Color.Transparent;
            this.btnNewSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNewSalary.ForeColor = System.Drawing.Color.White;
            this.btnNewSalary.HoverState.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnNewSalary.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNewSalary.ImageSize = new System.Drawing.Size(40, 40);
            this.btnNewSalary.Location = new System.Drawing.Point(8, 687);
            this.btnNewSalary.Name = "btnNewSalary";
            this.btnNewSalary.Size = new System.Drawing.Size(171, 44);
            this.btnNewSalary.TabIndex = 66;
            this.btnNewSalary.Text = "New Salary";
            this.btnNewSalary.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnNewSalary.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Navy;
            this.btnUpdate.BorderRadius = 4;
            this.btnUpdate.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnUpdate.BorderThickness = 1;
            this.btnUpdate.CausesValidation = false;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnUpdate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUpdate.ImageSize = new System.Drawing.Size(40, 40);
            this.btnUpdate.Location = new System.Drawing.Point(185, 687);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(171, 44);
            this.btnUpdate.TabIndex = 67;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(-3, 49);
            this.ctrlPersonInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Padding = new System.Windows.Forms.Padding(5);
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(970, 321);
            this.ctrlPersonInfo1.TabIndex = 0;
            // 
            // ctrlDoctorSalariesList1
            // 
            this.ctrlDoctorSalariesList1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctrlDoctorSalariesList1.Location = new System.Drawing.Point(3, 428);
            this.ctrlDoctorSalariesList1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDoctorSalariesList1.Name = "ctrlDoctorSalariesList1";
            this.ctrlDoctorSalariesList1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ctrlDoctorSalariesList1.Size = new System.Drawing.Size(962, 252);
            this.ctrlDoctorSalariesList1.TabIndex = 65;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.White;
            this.iconButton1.CausesValidation = false;
            this.iconButton1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.iconButton1.ForeColor = System.Drawing.Color.Red;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconButton1.IconColor = System.Drawing.Color.Red;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.Location = new System.Drawing.Point(754, 682);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(195, 50);
            this.iconButton1.TabIndex = 72;
            this.iconButton1.Text = "Exit";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.btnCancel_Click);
            this.iconButton1.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.iconButton1.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // frmDoctorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(961, 737);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNewSalary);
            this.Controls.Add(this.plDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Controls.Add(this.ctrlDoctorSalariesList1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoctorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDoctorDetails";
            this.Load += new System.EventHandler(this.frmDoctorDetails_Load);
            this.plDoctor.ResumeLayout(false);
            this.plDoctor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSpecialization;
        private Guna.UI2.WinForms.Guna2ShadowPanel plDoctor;
        private Contols.ctrlDoctorSalariesList ctrlDoctorSalariesList1;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnNewSalary;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}