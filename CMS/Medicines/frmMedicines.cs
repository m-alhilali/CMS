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

namespace CMS.Medicines
{
    public partial class frmMedicines : Form
    {
        private DataTable _dtMedicines;
        private clsMedicines _Medicine;
        private enum enMode { Add = 1, Update = 2 }
        private enMode Mode = enMode.Add;
        public frmMedicines()
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

        void _RefereshMedicineData()
        {
            _dtMedicines = clsMedicines.GetAllMedicinesList();
            dgvMedicines.DataSource = _dtMedicines;
            lblTotalRecord.Text = dgvMedicines.Rows.Count.ToString();
            if (dgvMedicines.Rows.Count > 0)
            {

                dgvMedicines.Columns["MedicineName"].HeaderText = "Meicine Name";
                dgvMedicines.Columns["MedicineID"].HeaderText = "Medicine ID";
                dgvMedicines.Columns["MedicineID"].Width = 120;
                dgvMedicines.Columns["MedicineFees"].HeaderText = "Medicine Fees";
                dgvMedicines.Columns["MedicineFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvMedicines.Columns["IsActive"].HeaderText = "Is Active";
                dgvMedicines.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvMedicines.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
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
                if (_dtMedicines != null && _dtMedicines.Rows.Count > 0)
                {
                    _dtMedicines.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvMedicines.Rows.Count.ToString();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Medicine ID":
                    Column = "MedicineID";
                    break;
                case "Medicine Name":
                    Column = "MedicineName";
                    break;

            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtMedicines.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvMedicines.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "MedicineID")
                {
                    _dtMedicines.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtMedicines.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtMedicines.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvMedicines.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtMedicines.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvMedicines.Rows.Count.ToString();
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
                _dtMedicines.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtMedicines.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvMedicines.Rows.Count.ToString();
        }

        private void frmMedicines_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _Medicine = new clsMedicines();
            Mode = enMode.Add;
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshMedicineData();
        }

        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                return;
            }
            int MedicineID = Convert.ToInt32(dgvMedicines.CurrentRow.Cells[0].Value);
            clsMedicines.Deactive(MedicineID);
            _RefereshMedicineData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                return;
            }
            int MedicineID = Convert.ToInt32(dgvMedicines.CurrentRow.Cells[0].Value);

            _Medicine = clsMedicines.Find(MedicineID);
            if (_Medicine == null)
            {
                return;
            }

            activeToolStripMenuItem.Enabled = !_Medicine.IsActive;
            inActiveToolStripMenuItem.Enabled = _Medicine.IsActive;

        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                return;
            }
            int MedicineID = Convert.ToInt32(dgvMedicines.CurrentRow.Cells[0].Value);
            clsMedicines.Active(MedicineID);
            _RefereshMedicineData();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                return;
            }
            int MedicineID = Convert.ToInt32(dgvMedicines.CurrentRow.Cells[0].Value);

            _Medicine = clsMedicines.Find(MedicineID);
            if (_Medicine == null)
            {
                return;
            }
            tbMedicineName.Text = _Medicine.MedicineName;
            tbFees.Text = _Medicine.MedicineFees.ToString("N2");
            chkbxIsActive.Checked = _Medicine.IsActive;
            lblMedicineID.Text = _Medicine.MedicineID.ToString();
            btnAddOrUpdate.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbMedicineName.Text = "";
            lblMedicineID.Text = "N/A";
            tbFees.Text = "";
            chkbxIsActive.Checked = false;
            _Medicine = new clsMedicines();
            btnAddOrUpdate.Enabled = true;
            Mode = enMode.Add;
            btnAddOrUpdate.Text = "New";

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


            _Medicine.MedicineName = tbMedicineName.Text;
            _Medicine.MedicineFees = Convert.ToDecimal(tbFees.Text);
            _Medicine.IsActive = chkbxIsActive.Checked;
            if (!_Medicine.Save())
            {
                MessageBox.Show("Failed: Data didn't save successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblMedicineID.Text = _Medicine.MedicineID.ToString();
            MessageBox.Show("Data saved successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mode = enMode.Update;
            _RefereshMedicineData();

        }
        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void tbMedicine_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMedicineName.Text.Trim()))
            {
                errorProvider1.SetError(tbMedicineName, "this Field is Required");
                e.Cancel = true;
                return;
            }

            if (clsMedicines.IsMedicineExist(tbMedicineName.Text.Trim()))
            {
                if (Mode == enMode.Add|| Mode == enMode.Update && tbMedicineName.Text.Trim()!=_Medicine.MedicineName)
                {
                    errorProvider1.SetError(tbMedicineName, "this Medicine already exists");
                    e.Cancel = true;
                }
                else if (Mode == enMode.Update)
                {
                    errorProvider1.SetError(tbMedicineName, null);
                }
            }
            else
            {
                errorProvider1.SetError(tbMedicineName, null);
            }

        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text.Trim()))
            {
                errorProvider1.SetError(tbFees, "this Field is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbFees, null);
            }
        }
        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                return;
            }
            int MedicineID = Convert.ToInt32(dgvMedicines.CurrentRow.Cells[0].Value);

            _Medicine = clsMedicines.Find(MedicineID);
            if (_Medicine == null)
            {
                return;
            }
            tbMedicineName.Text = _Medicine.MedicineName;
            tbFees.Text = _Medicine.MedicineFees.ToString("N2");
            chkbxIsActive.Checked = _Medicine.IsActive;
            btnAddOrUpdate.Enabled = _Medicine != null;
            Mode = enMode.Update;
            btnAddOrUpdate.Text = "Update";

        }
    }
}
