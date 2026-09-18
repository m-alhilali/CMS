namespace CMS.Consultations
{
    partial class frmManageConsultations
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
            this.consultationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.patientDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvConsultations = new Guna.UI2.WinForms.Guna2DataGridView();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox9 = new FontAwesome.Sharp.IconPictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // consultationDetailsToolStripMenuItem
            // 
            this.consultationDetailsToolStripMenuItem.Name = "consultationDetailsToolStripMenuItem";
            this.consultationDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 32);
            this.consultationDetailsToolStripMenuItem.Text = "Consultation Details";
            this.consultationDetailsToolStripMenuItem.Click += new System.EventHandler(this.consultationDetailsToolStripMenuItem_Click);
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTotalRecord.Location = new System.Drawing.Point(1374, 190);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(26, 29);
            this.lblTotalRecord.TabIndex = 101;
            this.lblTotalRecord.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultationDetailsToolStripMenuItem,
            this.patientDetailsToolStripMenuItem,
            this.doctorDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(243, 133);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // patientDetailsToolStripMenuItem
            // 
            this.patientDetailsToolStripMenuItem.Name = "patientDetailsToolStripMenuItem";
            this.patientDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 32);
            this.patientDetailsToolStripMenuItem.Text = "Patient Details";
            this.patientDetailsToolStripMenuItem.Click += new System.EventHandler(this.patientDetailsToolStripMenuItem_Click);
            // 
            // doctorDetailsToolStripMenuItem
            // 
            this.doctorDetailsToolStripMenuItem.Name = "doctorDetailsToolStripMenuItem";
            this.doctorDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 32);
            this.doctorDetailsToolStripMenuItem.Text = "Doctor Details";
            this.doctorDetailsToolStripMenuItem.Click += new System.EventHandler(this.doctorDetailsToolStripMenuItem_Click);
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
            "Consultation ID",
            "Appointmnet ID",
            "Doctor Name",
            "Patient Name",
            "Appointment Type"});
            this.cbFilter.Location = new System.Drawing.Point(884, 13);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(231, 39);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbFilter.TabIndex = 107;
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
            this.tbSearch.Location = new System.Drawing.Point(529, 13);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(322, 39);
            this.tbSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbSearch.TabIndex = 105;
            this.tbSearch.TextOffset = new System.Drawing.Point(35, 0);
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(5, -5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(510, 53);
            this.label2.TabIndex = 104;
            this.label2.Text = "Manage Consultations";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1285, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 100;
            this.label1.Text = "Record:";
            // 
            // dgvConsultations
            // 
            this.dgvConsultations.AllowUserToAddRows = false;
            this.dgvConsultations.AllowUserToDeleteRows = false;
            this.dgvConsultations.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvConsultations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsultations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsultations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsultations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsultations.ColumnHeadersHeight = 35;
            this.dgvConsultations.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvConsultations.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsultations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsultations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvConsultations.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvConsultations.Location = new System.Drawing.Point(0, 226);
            this.dgvConsultations.MultiSelect = false;
            this.dgvConsultations.Name = "dgvConsultations";
            this.dgvConsultations.ReadOnly = true;
            this.dgvConsultations.RowHeadersVisible = false;
            this.dgvConsultations.RowHeadersWidth = 62;
            this.dgvConsultations.RowTemplate.Height = 29;
            this.dgvConsultations.Size = new System.Drawing.Size(1528, 462);
            this.dgvConsultations.TabIndex = 99;
            this.dgvConsultations.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvConsultations.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.dgvConsultations.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvConsultations.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvConsultations.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvConsultations.ThemeStyle.ReadOnly = true;
            this.dgvConsultations.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvConsultations.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvConsultations.ThemeStyle.RowsStyle.Height = 29;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.Location = new System.Drawing.Point(536, 17);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(32, 32);
            this.iconSearch.TabIndex = 106;
            this.iconSearch.TabStop = false;
            this.iconSearch.Visible = false;
            // 
            // iconPictureBox9
            // 
            this.iconPictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox9.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox9.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.iconPictureBox9.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox9.IconSize = 196;
            this.iconPictureBox9.Location = new System.Drawing.Point(14, 47);
            this.iconPictureBox9.Name = "iconPictureBox9";
            this.iconPictureBox9.Size = new System.Drawing.Size(197, 196);
            this.iconPictureBox9.TabIndex = 108;
            this.iconPictureBox9.TabStop = false;
            // 
            // frmManageConsultations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1528, 688);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.iconSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvConsultations);
            this.Controls.Add(this.iconPictureBox9);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageConsultations";
            this.Text = "frmManageConsultations";
            this.Load += new System.EventHandler(this.frmManageConsultations_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem consultationDetailsToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvConsultations;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox9;
        private System.Windows.Forms.ToolStripMenuItem patientDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorDetailsToolStripMenuItem;
    }
}