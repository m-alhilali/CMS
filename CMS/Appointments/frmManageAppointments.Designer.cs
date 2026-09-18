namespace CMS.Appointments
{
    partial class frmManageAppointments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAppointments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.attendingAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.btnAppointmentTypes = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox11 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnReferesh = new FontAwesome.Sharp.IconButton();
            this.btnNewAppointment = new FontAwesome.Sharp.IconButton();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox9 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox12 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.Black;
            this.cbFilter.BorderRadius = 8;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FillColor = System.Drawing.SystemColors.Control;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.ItemHeight = 33;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Appointment ID",
            "Doctor Name",
            "Patient Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(883, 13);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(216, 39);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbFilter.TabIndex = 46;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.Color.Black;
            this.tbSearch.BorderRadius = 8;
            this.tbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearch.DefaultText = "";
            this.tbSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.FillColor = System.Drawing.SystemColors.Control;
            this.tbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbSearch.ForeColor = System.Drawing.Color.Black;
            this.tbSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Location = new System.Drawing.Point(528, 13);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(322, 39);
            this.tbSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbSearch.TabIndex = 44;
            this.tbSearch.TextOffset = new System.Drawing.Point(35, 0);
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(-28, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 62);
            this.label2.TabIndex = 43;
            this.label2.Text = "Appointments";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 39;
            this.label1.Text = "Record:";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAppointments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointments.ColumnHeadersHeight = 35;
            this.dgvAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointments.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAppointments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAppointments.Location = new System.Drawing.Point(0, 226);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.RowHeadersWidth = 62;
            this.dgvAppointments.RowTemplate.Height = 29;
            this.dgvAppointments.Size = new System.Drawing.Size(1528, 462);
            this.dgvAppointments.TabIndex = 38;
            this.dgvAppointments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAppointments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.dgvAppointments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvAppointments.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAppointments.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvAppointments.ThemeStyle.ReadOnly = true;
            this.dgvAppointments.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvAppointments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvAppointments.ThemeStyle.RowsStyle.Height = 29;
            this.dgvAppointments.DoubleClick += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.toolStripSeparator2,
            this.cancelToolStripMenuItem,
            this.toolStripSeparator3,
            this.attendingAppointmentToolStripMenuItem,
            this.consultationDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(295, 226);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.detailsToolStripMenuItem.Text = "Details ";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(291, 6);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(294, 34);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(291, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // attendingAppointmentToolStripMenuItem
            // 
            this.attendingAppointmentToolStripMenuItem.Name = "attendingAppointmentToolStripMenuItem";
            this.attendingAppointmentToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.attendingAppointmentToolStripMenuItem.Text = "Attending Appointment";
            this.attendingAppointmentToolStripMenuItem.Click += new System.EventHandler(this.attendingAppointmentToolStripMenuItem_Click);
            // 
            // consultationDetailsToolStripMenuItem
            // 
            this.consultationDetailsToolStripMenuItem.Name = "consultationDetailsToolStripMenuItem";
            this.consultationDetailsToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.consultationDetailsToolStripMenuItem.Text = "Consultation Details";
            this.consultationDetailsToolStripMenuItem.Click += new System.EventHandler(this.consultationDetailsToolStripMenuItem_Click);
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTotalRecord.Location = new System.Drawing.Point(89, 184);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(26, 29);
            this.lblTotalRecord.TabIndex = 40;
            this.lblTotalRecord.Text = "0";
            // 
            // btnAppointmentTypes
            // 
            this.btnAppointmentTypes.CausesValidation = false;
            this.btnAppointmentTypes.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnAppointmentTypes.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAppointmentTypes.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.btnAppointmentTypes.IconColor = System.Drawing.Color.DarkBlue;
            this.btnAppointmentTypes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAppointmentTypes.IconSize = 40;
            this.btnAppointmentTypes.Location = new System.Drawing.Point(1266, 69);
            this.btnAppointmentTypes.Name = "btnAppointmentTypes";
            this.btnAppointmentTypes.Size = new System.Drawing.Size(250, 53);
            this.btnAppointmentTypes.TabIndex = 92;
            this.btnAppointmentTypes.Text = "Appointment Types";
            this.btnAppointmentTypes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAppointmentTypes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAppointmentTypes.UseVisualStyleBackColor = false;
            this.btnAppointmentTypes.Click += new System.EventHandler(this.AppointmentTyps_Click);
            this.btnAppointmentTypes.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAppointmentTypes.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // iconPictureBox11
            // 
            this.iconPictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox11.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox11.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.iconPictureBox11.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox11.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox11.IconSize = 36;
            this.iconPictureBox11.Location = new System.Drawing.Point(783, 70);
            this.iconPictureBox11.Name = "iconPictureBox11";
            this.iconPictureBox11.Size = new System.Drawing.Size(38, 36);
            this.iconPictureBox11.TabIndex = 91;
            this.iconPictureBox11.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.BriefcaseMedical;
            this.iconPictureBox1.IconColor = System.Drawing.Color.DarkBlue;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 46;
            this.iconPictureBox1.Location = new System.Drawing.Point(700, 96);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(46, 46);
            this.iconPictureBox1.TabIndex = 89;
            this.iconPictureBox1.TabStop = false;
            // 
            // btnReferesh
            // 
            this.btnReferesh.CausesValidation = false;
            this.btnReferesh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnReferesh.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnReferesh.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnReferesh.IconColor = System.Drawing.Color.DarkBlue;
            this.btnReferesh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReferesh.IconSize = 40;
            this.btnReferesh.Location = new System.Drawing.Point(1266, 165);
            this.btnReferesh.Name = "btnReferesh";
            this.btnReferesh.Size = new System.Drawing.Size(250, 53);
            this.btnReferesh.TabIndex = 86;
            this.btnReferesh.Text = "Referesh";
            this.btnReferesh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReferesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReferesh.UseVisualStyleBackColor = false;
            this.btnReferesh.Click += new System.EventHandler(this.btnReferesh_Click);
            this.btnReferesh.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnReferesh.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnNewAppointment
            // 
            this.btnNewAppointment.CausesValidation = false;
            this.btnNewAppointment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnNewAppointment.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNewAppointment.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnNewAppointment.IconColor = System.Drawing.Color.DarkBlue;
            this.btnNewAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewAppointment.IconSize = 40;
            this.btnNewAppointment.Location = new System.Drawing.Point(1266, 10);
            this.btnNewAppointment.Name = "btnNewAppointment";
            this.btnNewAppointment.Size = new System.Drawing.Size(250, 53);
            this.btnNewAppointment.TabIndex = 85;
            this.btnNewAppointment.Text = "New Appointment";
            this.btnNewAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewAppointment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewAppointment.UseVisualStyleBackColor = false;
            this.btnNewAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            this.btnNewAppointment.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnNewAppointment.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.Location = new System.Drawing.Point(535, 17);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(32, 32);
            this.iconSearch.TabIndex = 45;
            this.iconSearch.TabStop = false;
            this.iconSearch.Visible = false;
            // 
            // iconPictureBox9
            // 
            this.iconPictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox9.ForeColor = System.Drawing.Color.DarkBlue;
            this.iconPictureBox9.IconChar = FontAwesome.Sharp.IconChar.BriefcaseMedical;
            this.iconPictureBox9.IconColor = System.Drawing.Color.DarkBlue;
            this.iconPictureBox9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox9.IconSize = 144;
            this.iconPictureBox9.Location = new System.Drawing.Point(5, 53);
            this.iconPictureBox9.Name = "iconPictureBox9";
            this.iconPictureBox9.Size = new System.Drawing.Size(150, 144);
            this.iconPictureBox9.TabIndex = 88;
            this.iconPictureBox9.TabStop = false;
            // 
            // iconPictureBox12
            // 
            this.iconPictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox12.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox12.IconChar = FontAwesome.Sharp.IconChar.Stethoscope;
            this.iconPictureBox12.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox12.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox12.IconSize = 208;
            this.iconPictureBox12.Location = new System.Drawing.Point(649, 53);
            this.iconPictureBox12.Name = "iconPictureBox12";
            this.iconPictureBox12.Size = new System.Drawing.Size(213, 208);
            this.iconPictureBox12.TabIndex = 90;
            this.iconPictureBox12.TabStop = false;
            // 
            // frmManageAppointments
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1528, 688);
            this.Controls.Add(this.btnAppointmentTypes);
            this.Controls.Add(this.iconPictureBox11);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.btnReferesh);
            this.Controls.Add(this.btnNewAppointment);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.iconSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.iconPictureBox9);
            this.Controls.Add(this.iconPictureBox12);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageAppointments";
            this.Text = "Manage Appointments";
            this.Load += new System.EventHandler(this.frmManageAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAppointments;
        private System.Windows.Forms.Label lblTotalRecord;
        private FontAwesome.Sharp.IconButton btnNewAppointment;
        private FontAwesome.Sharp.IconButton btnReferesh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendingAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox12;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox11;
        private FontAwesome.Sharp.IconButton btnAppointmentTypes;
        private System.Windows.Forms.ToolStripMenuItem consultationDetailsToolStripMenuItem;
    }
}