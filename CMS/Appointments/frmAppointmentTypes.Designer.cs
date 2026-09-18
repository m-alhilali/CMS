namespace CMS.Appointments
{
    partial class frmAppointmentTypes
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAppointmentType = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAppointmentTypeID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnAddOrUpdate = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.chkbxIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.tbFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAppointmentType = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iconPictureBox15 = new FontAwesome.Sharp.IconPictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentType)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(708, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 29);
            this.label4.TabIndex = 41;
            this.label4.Text = "IsActive:";
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
            "Appointment Type ID",
            "Appointment Type Title"});
            this.cbFilter.Location = new System.Drawing.Point(883, 14);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(279, 39);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbFilter.TabIndex = 38;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.Location = new System.Drawing.Point(535, 18);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(32, 32);
            this.iconSearch.TabIndex = 37;
            this.iconSearch.TabStop = false;
            this.iconSearch.Visible = false;
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
            this.tbSearch.Location = new System.Drawing.Point(528, 14);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(322, 39);
            this.tbSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbSearch.TabIndex = 36;
            this.tbSearch.TextOffset = new System.Drawing.Point(35, 0);
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(4, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 53);
            this.label2.TabIndex = 35;
            this.label2.Text = "Appointment Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTotalRecord.Location = new System.Drawing.Point(100, 43);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(26, 29);
            this.lblTotalRecord.TabIndex = 32;
            this.lblTotalRecord.Text = "0";
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // inActiveToolStripMenuItem
            // 
            this.inActiveToolStripMenuItem.Name = "inActiveToolStripMenuItem";
            this.inActiveToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.inActiveToolStripMenuItem.Text = "DeActive";
            this.inActiveToolStripMenuItem.Click += new System.EventHandler(this.inActiveToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.inActiveToolStripMenuItem,
            this.activeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 165);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cbIsActive.BorderColor = System.Drawing.Color.Black;
            this.cbIsActive.BorderRadius = 8;
            this.cbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FillColor = System.Drawing.SystemColors.Control;
            this.cbIsActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbIsActive.ForeColor = System.Drawing.Color.Black;
            this.cbIsActive.ItemHeight = 33;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(812, 33);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(216, 39);
            this.cbIsActive.StartIndex = 0;
            this.cbIsActive.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbIsActive.TabIndex = 40;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 31;
            this.label1.Text = "Record:";
            // 
            // dgvAppointmentType
            // 
            this.dgvAppointmentType.AllowUserToAddRows = false;
            this.dgvAppointmentType.AllowUserToDeleteRows = false;
            this.dgvAppointmentType.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAppointmentType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointmentType.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAppointmentType.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAppointmentType.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointmentType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointmentType.ColumnHeadersHeight = 35;
            this.dgvAppointmentType.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointmentType.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointmentType.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAppointmentType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAppointmentType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAppointmentType.Location = new System.Drawing.Point(3, 84);
            this.dgvAppointmentType.MultiSelect = false;
            this.dgvAppointmentType.Name = "dgvAppointmentType";
            this.dgvAppointmentType.ReadOnly = true;
            this.dgvAppointmentType.RowHeadersVisible = false;
            this.dgvAppointmentType.RowHeadersWidth = 62;
            this.dgvAppointmentType.RowTemplate.Height = 29;
            this.dgvAppointmentType.Size = new System.Drawing.Size(1028, 462);
            this.dgvAppointmentType.TabIndex = 30;
            this.dgvAppointmentType.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAppointmentType.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAppointmentType.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.dgvAppointmentType.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvAppointmentType.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAppointmentType.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvAppointmentType.ThemeStyle.ReadOnly = true;
            this.dgvAppointmentType.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvAppointmentType.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvAppointmentType.ThemeStyle.RowsStyle.Height = 29;
            this.dgvAppointmentType.DoubleClick += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.guna2Panel1.BorderRadius = 2;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.dgvAppointmentType);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.cbIsActive);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.lblTotalRecord);
            this.guna2Panel1.Location = new System.Drawing.Point(5, 138);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.guna2Panel1.Size = new System.Drawing.Size(1034, 549);
            this.guna2Panel1.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(10, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 31);
            this.label3.TabIndex = 64;
            this.label3.Text = "Appointment Types List";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.guna2Panel2.BorderRadius = 2;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblAppointmentTypeID);
            this.guna2Panel2.Controls.Add(this.label9);
            this.guna2Panel2.Controls.Add(this.btnClear);
            this.guna2Panel2.Controls.Add(this.btnExit);
            this.guna2Panel2.Controls.Add(this.btnAddOrUpdate);
            this.guna2Panel2.Controls.Add(this.label8);
            this.guna2Panel2.Controls.Add(this.chkbxIsActive);
            this.guna2Panel2.Controls.Add(this.iconPictureBox1);
            this.guna2Panel2.Controls.Add(this.tbFees);
            this.guna2Panel2.Controls.Add(this.label7);
            this.guna2Panel2.Controls.Add(this.label6);
            this.guna2Panel2.Controls.Add(this.tbAppointmentType);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.iconPictureBox15);
            this.guna2Panel2.Location = new System.Drawing.Point(1042, 138);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.guna2Panel2.Size = new System.Drawing.Size(485, 549);
            this.guna2Panel2.TabIndex = 63;
            // 
            // lblAppointmentTypeID
            // 
            this.lblAppointmentTypeID.AutoSize = true;
            this.lblAppointmentTypeID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAppointmentTypeID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAppointmentTypeID.Location = new System.Drawing.Point(223, 38);
            this.lblAppointmentTypeID.Name = "lblAppointmentTypeID";
            this.lblAppointmentTypeID.Size = new System.Drawing.Size(43, 24);
            this.lblAppointmentTypeID.TabIndex = 93;
            this.lblAppointmentTypeID.Text = "N/A";
            this.lblAppointmentTypeID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(9, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 24);
            this.label9.TabIndex = 92;
            this.label9.Text = "Appointment Type ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnClear.IconColor = System.Drawing.SystemColors.WindowText;
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.IconSize = 40;
            this.btnClear.Location = new System.Drawing.Point(163, 486);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 57);
            this.btnClear.TabIndex = 91;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this._MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this._MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.CausesValidation = false;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnExit.IconColor = System.Drawing.Color.Red;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 40;
            this.btnExit.Location = new System.Drawing.Point(6, 486);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 57);
            this.btnExit.TabIndex = 90;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this._MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this._MouseLeave);
            // 
            // btnAddOrUpdate
            // 
            this.btnAddOrUpdate.BackColor = System.Drawing.Color.Green;
            this.btnAddOrUpdate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddOrUpdate.ForeColor = System.Drawing.Color.White;
            this.btnAddOrUpdate.IconChar = FontAwesome.Sharp.IconChar.FileMedical;
            this.btnAddOrUpdate.IconColor = System.Drawing.Color.White;
            this.btnAddOrUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddOrUpdate.IconSize = 40;
            this.btnAddOrUpdate.Location = new System.Drawing.Point(319, 486);
            this.btnAddOrUpdate.Name = "btnAddOrUpdate";
            this.btnAddOrUpdate.Size = new System.Drawing.Size(160, 57);
            this.btnAddOrUpdate.TabIndex = 89;
            this.btnAddOrUpdate.Text = "New";
            this.btnAddOrUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddOrUpdate.UseVisualStyleBackColor = false;
            this.btnAddOrUpdate.Click += new System.EventHandler(this.btnAddOrUpdate_Click);
            this.btnAddOrUpdate.MouseEnter += new System.EventHandler(this._MouseEnter);
            this.btnAddOrUpdate.MouseLeave += new System.EventHandler(this._MouseLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(9, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 24);
            this.label8.TabIndex = 71;
            this.label8.Text = "Status:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkbxIsActive
            // 
            this.chkbxIsActive.AutoSize = true;
            this.chkbxIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkbxIsActive.CheckedState.BorderRadius = 0;
            this.chkbxIsActive.CheckedState.BorderThickness = 0;
            this.chkbxIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkbxIsActive.Location = new System.Drawing.Point(13, 306);
            this.chkbxIsActive.Name = "chkbxIsActive";
            this.chkbxIsActive.Size = new System.Drawing.Size(112, 28);
            this.chkbxIsActive.TabIndex = 70;
            this.chkbxIsActive.Text = "Is Active";
            this.chkbxIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkbxIsActive.UncheckedState.BorderRadius = 0;
            this.chkbxIsActive.UncheckedState.BorderThickness = 0;
            this.chkbxIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 42;
            this.iconPictureBox1.Location = new System.Drawing.Point(9, 206);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(42, 42);
            this.iconPictureBox1.TabIndex = 69;
            this.iconPictureBox1.TabStop = false;
            // 
            // tbFees
            // 
            this.tbFees.BorderColor = System.Drawing.Color.Black;
            this.tbFees.BorderRadius = 8;
            this.tbFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFees.DefaultText = "";
            this.tbFees.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFees.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbFees.ForeColor = System.Drawing.Color.Black;
            this.tbFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFees.Location = new System.Drawing.Point(5, 197);
            this.tbFees.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbFees.Name = "tbFees";
            this.tbFees.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbFees.PlaceholderText = "Enter Fees";
            this.tbFees.SelectedText = "";
            this.tbFees.Size = new System.Drawing.Size(452, 57);
            this.tbFees.TabIndex = 68;
            this.tbFees.TextOffset = new System.Drawing.Point(38, 0);
            this.tbFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFees_KeyPress);
            this.tbFees.Validating += new System.ComponentModel.CancelEventHandler(this.tbFees_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(8, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 67;
            this.label7.Text = "Fees:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(8, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 24);
            this.label6.TabIndex = 66;
            this.label6.Text = "Name type of appointment:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbAppointmentType
            // 
            this.tbAppointmentType.BorderColor = System.Drawing.Color.Black;
            this.tbAppointmentType.BorderRadius = 8;
            this.tbAppointmentType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAppointmentType.DefaultText = "";
            this.tbAppointmentType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAppointmentType.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAppointmentType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAppointmentType.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAppointmentType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAppointmentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbAppointmentType.ForeColor = System.Drawing.Color.Black;
            this.tbAppointmentType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAppointmentType.Location = new System.Drawing.Point(5, 100);
            this.tbAppointmentType.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbAppointmentType.Name = "tbAppointmentType";
            this.tbAppointmentType.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbAppointmentType.PlaceholderText = "Enter the name of the appointment type";
            this.tbAppointmentType.SelectedText = "";
            this.tbAppointmentType.Size = new System.Drawing.Size(452, 57);
            this.tbAppointmentType.TabIndex = 64;
            this.tbAppointmentType.Validating += new System.ComponentModel.CancelEventHandler(this.tbAppointmentType_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(8, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 29);
            this.label5.TabIndex = 65;
            this.label5.Text = "Appointment Type Details";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // iconPictureBox15
            // 
            this.iconPictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox15.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox15.IconChar = FontAwesome.Sharp.IconChar.Stethoscope;
            this.iconPictureBox15.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox15.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox15.IconSize = 201;
            this.iconPictureBox15.Location = new System.Drawing.Point(191, 279);
            this.iconPictureBox15.Name = "iconPictureBox15";
            this.iconPictureBox15.Size = new System.Drawing.Size(238, 201);
            this.iconPictureBox15.TabIndex = 88;
            this.iconPictureBox15.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAppointmentTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1528, 688);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.iconSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAppointmentTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAppointmentTypes";
            this.Load += new System.EventHandler(this.frmAppointmentTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentType)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAppointmentType;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox tbAppointmentType;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox tbFees;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2CheckBox chkbxIsActive;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox15;
        private FontAwesome.Sharp.IconButton btnAddOrUpdate;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblAppointmentTypeID;
        private System.Windows.Forms.Label label9;
    }
}