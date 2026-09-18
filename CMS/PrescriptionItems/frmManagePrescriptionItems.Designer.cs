namespace CMS.PrescriptionItems
{
    partial class frmManagePrescriptionItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPrescriptionItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.doctordetailstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPictureBox9 = new FontAwesome.Sharp.IconPictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.patientDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionItems)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrescriptionItems
            // 
            this.dgvPrescriptionItems.AllowUserToAddRows = false;
            this.dgvPrescriptionItems.AllowUserToDeleteRows = false;
            this.dgvPrescriptionItems.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPrescriptionItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrescriptionItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPrescriptionItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrescriptionItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrescriptionItems.ColumnHeadersHeight = 35;
            this.dgvPrescriptionItems.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPrescriptionItems.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrescriptionItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPrescriptionItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPrescriptionItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPrescriptionItems.Location = new System.Drawing.Point(0, 226);
            this.dgvPrescriptionItems.MultiSelect = false;
            this.dgvPrescriptionItems.Name = "dgvPrescriptionItems";
            this.dgvPrescriptionItems.ReadOnly = true;
            this.dgvPrescriptionItems.RowHeadersVisible = false;
            this.dgvPrescriptionItems.RowHeadersWidth = 62;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvPrescriptionItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPrescriptionItems.RowTemplate.Height = 29;
            this.dgvPrescriptionItems.Size = new System.Drawing.Size(1528, 462);
            this.dgvPrescriptionItems.TabIndex = 19;
            this.dgvPrescriptionItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrescriptionItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.dgvPrescriptionItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvPrescriptionItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPrescriptionItems.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvPrescriptionItems.ThemeStyle.ReadOnly = true;
            this.dgvPrescriptionItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvPrescriptionItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvPrescriptionItems.ThemeStyle.RowsStyle.Height = 29;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctordetailstoolStripMenuItem1,
            this.patientDetailsToolStripMenuItem,
            this.consultationDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(243, 133);
            // 
            // doctordetailstoolStripMenuItem1
            // 
            this.doctordetailstoolStripMenuItem1.Name = "doctordetailstoolStripMenuItem1";
            this.doctordetailstoolStripMenuItem1.Size = new System.Drawing.Size(242, 32);
            this.doctordetailstoolStripMenuItem1.Text = "Doctor Details";
            this.doctordetailstoolStripMenuItem1.Click += new System.EventHandler(this.doctordetailstoolStripMenuItem1_Click);
            // 
            // consultationDetailsToolStripMenuItem
            // 
            this.consultationDetailsToolStripMenuItem.Name = "consultationDetailsToolStripMenuItem";
            this.consultationDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 32);
            this.consultationDetailsToolStripMenuItem.Text = "Consultation Details";
            this.consultationDetailsToolStripMenuItem.Click += new System.EventHandler(this.consultationDetailsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1319, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Record:";
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTotalRecord.Location = new System.Drawing.Point(1408, 191);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(26, 29);
            this.lblTotalRecord.TabIndex = 22;
            this.lblTotalRecord.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(4, -5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(618, 53);
            this.label2.TabIndex = 24;
            this.label2.Text = "Manage Prescription Items";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // iconPictureBox9
            // 
            this.iconPictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox9.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox9.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.iconPictureBox9.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox9.IconSize = 196;
            this.iconPictureBox9.Location = new System.Drawing.Point(0, 51);
            this.iconPictureBox9.Name = "iconPictureBox9";
            this.iconPictureBox9.Size = new System.Drawing.Size(197, 196);
            this.iconPictureBox9.TabIndex = 109;
            this.iconPictureBox9.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(198, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 29);
            this.label4.TabIndex = 111;
            this.label4.Text = "IsActive:";
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
            this.cbIsActive.Location = new System.Drawing.Point(302, 181);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(216, 39);
            this.cbIsActive.StartIndex = 0;
            this.cbIsActive.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbIsActive.TabIndex = 110;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
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
            "PrescriptionItem ID",
            "Medicine Name",
            "Duration",
            "Duration Unit"});
            this.cbFilter.Location = new System.Drawing.Point(1043, 15);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(231, 39);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbFilter.TabIndex = 114;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.Location = new System.Drawing.Point(695, 19);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(32, 32);
            this.iconSearch.TabIndex = 113;
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
            this.tbSearch.Location = new System.Drawing.Point(688, 15);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(322, 39);
            this.tbSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbSearch.TabIndex = 112;
            this.tbSearch.TextOffset = new System.Drawing.Point(35, 0);
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // patientDetailsToolStripMenuItem
            // 
            this.patientDetailsToolStripMenuItem.Name = "patientDetailsToolStripMenuItem";
            this.patientDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 32);
            this.patientDetailsToolStripMenuItem.Text = "Patient Details";
            this.patientDetailsToolStripMenuItem.Click += new System.EventHandler(this.patientDetailsToolStripMenuItem_Click);
            // 
            // frmManagePrescriptionItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 688);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.iconSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.dgvPrescriptionItems);
            this.Controls.Add(this.iconPictureBox9);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManagePrescriptionItems";
            this.Text = "frmManagePrescriptionItems";
            this.Load += new System.EventHandler(this.frmManagePrescriptionItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionItems)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvPrescriptionItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultationDetailsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox9;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.ToolStripMenuItem doctordetailstoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem patientDetailsToolStripMenuItem;
    }
}