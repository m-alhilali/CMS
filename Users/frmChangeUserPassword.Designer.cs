namespace CMS.Users
{
    partial class frmChangeUserPassword
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
            this.tbConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iconPictureBox15 = new FontAwesome.Sharp.IconPictureBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonInfoWithFilter1 = new CMS.Controls.ctrlPersonInfoWithFilter();
            this.plDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox15)).BeginInit();
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
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "Change User\'s Password";
            // 
            // plDoctor
            // 
            this.plDoctor.BackColor = System.Drawing.Color.Transparent;
            this.plDoctor.Controls.Add(this.tbConfirmPassword);
            this.plDoctor.Controls.Add(this.label2);
            this.plDoctor.Controls.Add(this.tbCurrentPassword);
            this.plDoctor.Controls.Add(this.label1);
            this.plDoctor.Controls.Add(this.tbNewPassword);
            this.plDoctor.Controls.Add(this.lblUserID);
            this.plDoctor.Controls.Add(this.label4);
            this.plDoctor.Controls.Add(this.label3);
            this.plDoctor.Controls.Add(this.iconPictureBox15);
            this.plDoctor.EdgeWidth = 1;
            this.plDoctor.FillColor = System.Drawing.Color.White;
            this.plDoctor.Location = new System.Drawing.Point(2, 444);
            this.plDoctor.Name = "plDoctor";
            this.plDoctor.Radius = 3;
            this.plDoctor.ShadowColor = System.Drawing.Color.Black;
            this.plDoctor.Size = new System.Drawing.Size(868, 147);
            this.plDoctor.TabIndex = 26;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.BorderColor = System.Drawing.Color.Black;
            this.tbConfirmPassword.BorderRadius = 7;
            this.tbConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConfirmPassword.DefaultText = "";
            this.tbConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbConfirmPassword.ForeColor = System.Drawing.Color.Black;
            this.tbConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmPassword.Location = new System.Drawing.Point(182, 98);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbConfirmPassword.PlaceholderText = "New Password";
            this.tbConfirmPassword.SelectedText = "";
            this.tbConfirmPassword.Size = new System.Drawing.Size(286, 39);
            this.tbConfirmPassword.TabIndex = 49;
            this.tbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPassword_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 24);
            this.label2.TabIndex = 48;
            this.label2.Text = "Confirm Password:";
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.BorderColor = System.Drawing.Color.Black;
            this.tbCurrentPassword.BorderRadius = 7;
            this.tbCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCurrentPassword.DefaultText = "";
            this.tbCurrentPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCurrentPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCurrentPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCurrentPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCurrentPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbCurrentPassword.ForeColor = System.Drawing.Color.Black;
            this.tbCurrentPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCurrentPassword.Location = new System.Drawing.Point(182, 10);
            this.tbCurrentPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.PasswordChar = '*';
            this.tbCurrentPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbCurrentPassword.PlaceholderText = "Current Password";
            this.tbCurrentPassword.SelectedText = "";
            this.tbCurrentPassword.Size = new System.Drawing.Size(286, 39);
            this.tbCurrentPassword.TabIndex = 47;
            this.tbCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbCurrentPassword_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 46;
            this.label1.Text = "Current Password:";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.BorderColor = System.Drawing.Color.Black;
            this.tbNewPassword.BorderRadius = 7;
            this.tbNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNewPassword.DefaultText = "";
            this.tbNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbNewPassword.ForeColor = System.Drawing.Color.Black;
            this.tbNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPassword.Location = new System.Drawing.Point(182, 54);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbNewPassword.PlaceholderText = "New Password";
            this.tbNewPassword.SelectedText = "";
            this.tbNewPassword.Size = new System.Drawing.Size(286, 39);
            this.tbNewPassword.TabIndex = 48;
            this.tbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbNewPassword_Validating);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(603, 10);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(46, 24);
            this.lblUserID.TabIndex = 43;
            this.lblUserID.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 40;
            this.label3.Text = "New Password:";
            // 
            // iconPictureBox15
            // 
            this.iconPictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox15.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox15.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconPictureBox15.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox15.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox15.IconSize = 132;
            this.iconPictureBox15.Location = new System.Drawing.Point(695, 12);
            this.iconPictureBox15.Name = "iconPictureBox15";
            this.iconPictureBox15.Size = new System.Drawing.Size(176, 132);
            this.iconPictureBox15.TabIndex = 89;
            this.iconPictureBox15.TabStop = false;
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
            this.btnCancel.Location = new System.Drawing.Point(519, 597);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 45);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this._MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this._MouseLeave);
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
            this.btnSave.FillColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Location = new System.Drawing.Point(696, 597);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 45);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this._MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this._MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(0, 52);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(873, 398);
            this.ctrlPersonInfoWithFilter1.TabIndex = 24;
            // 
            // frmChangeUserPassword
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(872, 647);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.plDoctor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChangeUserPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChangeUserPassword";
            this.Activated += new System.EventHandler(this.frmChangeUserPassword_Activated);
            this.Load += new System.EventHandler(this.frmChangeUserPassword_Load);
            this.plDoctor.ResumeLayout(false);
            this.plDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ShadowPanel plDoctor;
        private Guna.UI2.WinForms.Guna2TextBox tbCurrentPassword;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbNewPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmPassword;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox15;
    }
}