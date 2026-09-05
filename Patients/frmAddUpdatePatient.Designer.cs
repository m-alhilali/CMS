namespace CMS.Patients
{
    partial class frmAddUpdatePatient
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.plDoctor = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBloodType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlPersonInfoWithFilter1 = new CMS.Controls.ctrlPersonInfoWithFilter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.plDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(872, 48);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Add New Patient";
            // 
            // plDoctor
            // 
            this.plDoctor.BackColor = System.Drawing.Color.Transparent;
            this.plDoctor.Controls.Add(this.lblPatientID);
            this.plDoctor.Controls.Add(this.label4);
            this.plDoctor.Controls.Add(this.lblUserName);
            this.plDoctor.Controls.Add(this.label3);
            this.plDoctor.Controls.Add(this.lblCreateDate);
            this.plDoctor.Controls.Add(this.label6);
            this.plDoctor.Controls.Add(this.cbBloodType);
            this.plDoctor.Controls.Add(this.label7);
            this.plDoctor.EdgeWidth = 1;
            this.plDoctor.FillColor = System.Drawing.Color.White;
            this.plDoctor.Location = new System.Drawing.Point(2, 438);
            this.plDoctor.Name = "plDoctor";
            this.plDoctor.Radius = 3;
            this.plDoctor.ShadowColor = System.Drawing.Color.Black;
            this.plDoctor.Size = new System.Drawing.Size(868, 99);
            this.plDoctor.TabIndex = 3;
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Location = new System.Drawing.Point(140, 20);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(46, 24);
            this.lblPatientID.TabIndex = 43;
            this.lblPatientID.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "Patient ID:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(140, 57);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(46, 24);
            this.lblUserName.TabIndex = 41;
            this.lblUserName.Text = "????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 40;
            this.label3.Text = "User Name:";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(562, 20);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(46, 24);
            this.lblCreateDate.TabIndex = 39;
            this.lblCreateDate.Text = "????";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 24);
            this.label6.TabIndex = 38;
            this.label6.Text = "Created Date:";
            // 
            // cbBloodType
            // 
            this.cbBloodType.BackColor = System.Drawing.Color.Transparent;
            this.cbBloodType.BorderColor = System.Drawing.Color.Black;
            this.cbBloodType.BorderRadius = 5;
            this.cbBloodType.BorderThickness = 2;
            this.cbBloodType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBloodType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBloodType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBloodType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBloodType.ForeColor = System.Drawing.Color.Black;
            this.cbBloodType.ItemHeight = 33;
            this.cbBloodType.Items.AddRange(new object[] {
            "+O",
            "+A",
            "+B",
            "+AB",
            "-O",
            "-A",
            "-B",
            "-AB"});
            this.cbBloodType.Location = new System.Drawing.Point(566, 46);
            this.cbBloodType.Name = "cbBloodType";
            this.cbBloodType.Size = new System.Drawing.Size(292, 39);
            this.cbBloodType.StartIndex = 0;
            this.cbBloodType.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbBloodType.TabIndex = 36;
            this.cbBloodType.Validating += new System.ComponentModel.CancelEventHandler(this.cbSpecialization_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 24);
            this.label7.TabIndex = 37;
            this.label7.Text = "BloodType:";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 4;
            this.btnCancel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.Location = new System.Drawing.Point(521, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 45);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Location = new System.Drawing.Point(698, 544);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 45);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(0, 46);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(873, 398);
            this.ctrlPersonInfoWithFilter1.TabIndex = 1;
            this.ctrlPersonInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnPersonSelected);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdatePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(872, 595);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.plDoctor);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddUpdatePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddUpdatePatient";
            this.Activated += new System.EventHandler(this.frmAddUpdatePatient_Activated);
            this.Load += new System.EventHandler(this.frmAddUpdatePatient_Load);
            this.plDoctor.ResumeLayout(false);
            this.plDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ShadowPanel plDoctor;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbBloodType;
        private System.Windows.Forms.Label label7;
        private Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}