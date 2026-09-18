using CMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Specialties
{
    public partial class frmSpecialties : Form
    {
        private DataTable _dtSpecilaties;
        private clsSpecialties _Specialties;
        private enum enMode { Add = 1, Update = 2 }
        private enMode Mode = enMode.Add;

        public frmSpecialties()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        void _RefereshSpecialtiesData()
        {

            _dtSpecilaties = clsSpecialties.GetAllSpecialtiestList();
            dgvSpecialties.DataSource = _dtSpecilaties;
            lblTotalRecord.Text = dgvSpecialties.Rows.Count.ToString();
            if (dgvSpecialties.Rows.Count > 0)
            {

                dgvSpecialties.Columns["SpecialtyID"].HeaderText = "ID";
                dgvSpecialties.Columns["SpecialtyID"].Width = 120;
                dgvSpecialties.Columns["SpecialtyName"].HeaderText = "Specialty Name";
                dgvSpecialties.Columns["IsActive"].HeaderText = "Is Active";

                dgvSpecialties.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvSpecialties.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }
        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }
        private void frmSpecialties_Load(object sender, EventArgs e)
        {
            _Specialties = new clsSpecialties();
            this.Location = new Point(315, 150);
            Mode = enMode.Add;
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshSpecialtiesData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSpecialty.Text = "";
            lblSpecialtyID.Text = "N/A";
            chkIsActive.Checked = false;
            _Specialties = new clsSpecialties();
            btnAddOrUpdate.Enabled = true;
            Mode = enMode.Add;
            btnAddOrUpdate.Text = "New";
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSpecialties.CurrentRow == null)
            {
                return;
            }
            int SpecialtyID = Convert.ToInt32(dgvSpecialties.CurrentRow.Cells[0].Value);

            _Specialties = clsSpecialties.Find(SpecialtyID);
            if (_Specialties == null)
            {
                return;
            }
            tbSpecialty.Text = _Specialties.SpecialtyName;
            chkIsActive.Checked = _Specialties.IsActive;
            lblSpecialtyID.Text = _Specialties.SpecialtyID.ToString();
            btnAddOrUpdate.Enabled = false;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSpecialties.CurrentRow == null)
            {
                return;
            }
            int SpecialtyID = Convert.ToInt32(dgvSpecialties.CurrentRow.Cells[0].Value);

            _Specialties = clsSpecialties.Find(SpecialtyID);
            if (_Specialties == null)
            {
                return;
            }
            tbSpecialty.Text = _Specialties.SpecialtyName;
            chkIsActive.Checked = _Specialties.IsActive;
            btnAddOrUpdate.Enabled = _Specialties != null;
            Mode = enMode.Update;
            btnAddOrUpdate.Text = "Update";
        }

        private void tbSpecialty_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSpecialty.Text.Trim()))
            {
                errorProvider1.SetError(tbSpecialty, "this Field is Required");
                e.Cancel = true;
                return;
            }

            if (clsSpecialties.IsSpecialitiesExist(tbSpecialty.Text.Trim()))
            {
                if (Mode == enMode.Add || Mode == enMode.Update && tbSpecialty.Text.Trim() != _Specialties.SpecialtyName)
                {
                    errorProvider1.SetError(tbSpecialty, "this type already exists");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbSpecialty, null);
                }
            }
            else
            {
                errorProvider1.SetError(tbSpecialty, null);
            }
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add | update this Type", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }


            _Specialties.SpecialtyName = tbSpecialty.Text;
            _Specialties.IsActive = chkIsActive.Checked;
            if (!_Specialties.Save())
            {
                MessageBox.Show("Failed: Data didn't save successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblSpecialtyID.Text = _Specialties.SpecialtyID.ToString();
            MessageBox.Show("Data saved successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mode = enMode.Update;
            _RefereshSpecialtiesData();

        }

        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSpecialties.CurrentRow == null)
            {
                return;
            }
            int SpecilatyID = Convert.ToInt32(dgvSpecialties.CurrentRow.Cells[0].Value);
            clsSpecialties.DeActive(SpecilatyID);
            _RefereshSpecialtiesData();
        }
        private void ActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSpecialties.CurrentRow == null)
            {
                return;
            }
            int SpecilatyID = Convert.ToInt32(dgvSpecialties.CurrentRow.Cells[0].Value);
            clsSpecialties.Active(SpecilatyID);
            _RefereshSpecialtiesData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvSpecialties.CurrentRow == null)
            {
                return;
            }
            int SpecialtyID = Convert.ToInt32(dgvSpecialties.CurrentRow.Cells[0].Value);

            _Specialties = clsSpecialties.Find(SpecialtyID);
            if (_dtSpecilaties == null)
            {
                return;
            }

            activeToolStripMenuItem.Enabled = !_Specialties.IsActive;
            inActiveToolStripMenuItem.Enabled = _Specialties.IsActive;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtSpecilaties.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvSpecialties.Rows.Count.ToString();
                return;
            }
            try
            {

                if (cbIsActive.Text == "No")
                {
                    Result = "0";

                }
                else
                {
                    Result = "1";

                }
                _dtSpecilaties.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtSpecilaties.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvSpecialties.Rows.Count.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            iconSearch.Visible = cbFilter.Text != "None" && cbFilter.SelectedIndex != -1;
            tbSearch.Visible = iconSearch.Visible;
            tbSearch.PlaceholderText = cbFilter.Text;
            if (tbSearch.Visible)
            {
                tbSearch.Focus();
            }
            else
            {
                if (_dtSpecilaties != null && _dtSpecilaties.Rows.Count > 0)
                {
                    _dtSpecilaties.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvSpecialties.Rows.Count.ToString();
                }
            }

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Specialty ID":
                    Column = "SpecialtyID";
                    break;
                case "Specialty Name":
                    Column = "SpecialtyName";
                    break;

            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtSpecilaties.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvSpecialties.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "SpecialtyID")
                {
                    _dtSpecilaties.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtSpecilaties.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtSpecilaties.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvSpecialties.Rows.Count.ToString();
        }
    }
}
