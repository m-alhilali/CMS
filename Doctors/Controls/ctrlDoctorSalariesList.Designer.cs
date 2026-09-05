namespace CMS.Contols
{
    partial class ctrlDoctorSalariesList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plDoctorSalaries = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSalaries = new Guna.UI2.WinForms.Guna2DataGridView();
            this.plDoctorSalaries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).BeginInit();
            this.SuspendLayout();
            // 
            // plDoctorSalaries
            // 
            this.plDoctorSalaries.BackColor = System.Drawing.Color.Transparent;
            this.plDoctorSalaries.Controls.Add(this.lblTotalRecord);
            this.plDoctorSalaries.Controls.Add(this.label1);
            this.plDoctorSalaries.Controls.Add(this.dgvSalaries);
            this.plDoctorSalaries.EdgeWidth = 1;
            this.plDoctorSalaries.FillColor = System.Drawing.Color.White;
            this.plDoctorSalaries.Location = new System.Drawing.Point(2, 3);
            this.plDoctorSalaries.Margin = new System.Windows.Forms.Padding(4);
            this.plDoctorSalaries.Name = "plDoctorSalaries";
            this.plDoctorSalaries.Padding = new System.Windows.Forms.Padding(5);
            this.plDoctorSalaries.Radius = 3;
            this.plDoctorSalaries.ShadowColor = System.Drawing.Color.Black;
            this.plDoctorSalaries.Size = new System.Drawing.Size(957, 248);
            this.plDoctorSalaries.TabIndex = 4;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTotalRecord.Location = new System.Drawing.Point(5, 41);
            this.lblTotalRecord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(947, 33);
            this.lblTotalRecord.TabIndex = 4;
            this.lblTotalRecord.Text = "Record : 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salary Record";
            // 
            // dgvSalaries
            // 
            this.dgvSalaries.AllowUserToAddRows = false;
            this.dgvSalaries.AllowUserToDeleteRows = false;
            this.dgvSalaries.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvSalaries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSalaries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalaries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSalaries.ColumnHeadersHeight = 35;
            this.dgvSalaries.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalaries.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSalaries.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalaries.Location = new System.Drawing.Point(9, 76);
            this.dgvSalaries.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSalaries.MultiSelect = false;
            this.dgvSalaries.Name = "dgvSalaries";
            this.dgvSalaries.ReadOnly = true;
            this.dgvSalaries.RowHeadersVisible = false;
            this.dgvSalaries.RowHeadersWidth = 62;
            this.dgvSalaries.RowTemplate.Height = 29;
            this.dgvSalaries.Size = new System.Drawing.Size(936, 160);
            this.dgvSalaries.TabIndex = 1;
            this.dgvSalaries.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalaries.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.dgvSalaries.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvSalaries.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalaries.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvSalaries.ThemeStyle.ReadOnly = true;
            this.dgvSalaries.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvSalaries.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvSalaries.ThemeStyle.RowsStyle.Height = 29;
            // 
            // ctrlDoctorSalariesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plDoctorSalaries);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlDoctorSalariesList";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Size = new System.Drawing.Size(962, 252);
            this.plDoctorSalaries.ResumeLayout(false);
            this.plDoctorSalaries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel plDoctorSalaries;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSalaries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRecord;
    }
}
