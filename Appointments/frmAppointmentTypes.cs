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

namespace CMS.Appointments
{
    public partial class frmAppointmentTypes : Form
    {
        private DataTable _dtAppointmentType;
        private clsAppointmentTypes _AppointmentType;
        private enum enMode { Add=1,Update=2 }
        private enMode Mode= enMode.Add;

        public frmAppointmentTypes()
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
        void _RefereshAppointmentTypeData()
        {
            
            _dtAppointmentType = clsAppointmentTypes.GetAllAppointmentTypesList();
            dgvAppointmentType.DataSource = _dtAppointmentType;
            lblTotalRecord.Text = dgvAppointmentType.Rows.Count.ToString();
            if (dgvAppointmentType.Rows.Count > 0)
            {

                dgvAppointmentType.Columns["AppointmentTypeID"].HeaderText = "ID";
                dgvAppointmentType.Columns["AppointmentTypeID"].Width = 120;
                dgvAppointmentType.Columns["AppointmentTypeFees"].HeaderText = "Fees";
                dgvAppointmentType.Columns["AppointmentTypeFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvAppointmentType.Columns["AppointmentTypeTitle"].HeaderText = "Title";
                dgvAppointmentType.Columns["AppointmentTypeTitle"].Width = 600;
                dgvAppointmentType.Columns["IsActive"].HeaderText = "Is Active";
                
                dgvAppointmentType.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvAppointmentType.RowsDefaultCellStyle.ForeColor = Color.Black;
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
        private void frmAppointmentTypes_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);

            _AppointmentType = new clsAppointmentTypes();
            Mode = enMode.Add;
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshAppointmentTypeData();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtAppointmentType.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvAppointmentType.Rows.Count.ToString();
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
                _dtAppointmentType.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtAppointmentType.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvAppointmentType.Rows.Count.ToString();
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
                if (_dtAppointmentType != null && _dtAppointmentType.Rows.Count > 0)
                {
                    _dtAppointmentType.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvAppointmentType.Rows.Count.ToString();
                }
            }

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Appointment Type ID":
                    Column = "AppointmentTypeID";
                    break;
                case "Appointment Type Title":
                    Column = "AppointmentTypeTitle";
                    break;

            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtAppointmentType.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvAppointmentType.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "AppointmentTypeID")
                {
                    _dtAppointmentType.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtAppointmentType.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtAppointmentType.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvAppointmentType.Rows.Count.ToString();
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentType.CurrentRow == null)
            {
                return;
            }
            int AppointmentTypeID = Convert.ToInt32(dgvAppointmentType.CurrentRow.Cells[0].Value);
            clsAppointmentTypes.Active(AppointmentTypeID);
            _RefereshAppointmentTypeData();
        }
        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentType.CurrentRow == null)
            {
                return;
            }
            int AppointmentTypeID = Convert.ToInt32(dgvAppointmentType.CurrentRow.Cells[0].Value);
            clsAppointmentTypes.InActive(AppointmentTypeID);
            _RefereshAppointmentTypeData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAppointmentType.CurrentRow == null)
            {
                return;
            }
            int AppointmentTypeID = Convert.ToInt32(dgvAppointmentType.CurrentRow.Cells[0].Value);

            _AppointmentType = clsAppointmentTypes.Find(AppointmentTypeID);
            if(_AppointmentType == null)
            {
                return;
            }

            activeToolStripMenuItem.Enabled = !_AppointmentType.IsActive;
            inActiveToolStripMenuItem.Enabled = _AppointmentType.IsActive;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentType.CurrentRow == null)
            {
                return;
            }
            int AppointmentTypeID = Convert.ToInt32(dgvAppointmentType.CurrentRow.Cells[0].Value);

            _AppointmentType = clsAppointmentTypes.Find(AppointmentTypeID);
            if (_AppointmentType == null)
            {
                return;
            }
            tbAppointmentType.Text = _AppointmentType.AppointmentTypeTitle;
            tbFees.Text = _AppointmentType.AppointmentTypeFees.ToString("N2");
            chkbxIsActive.Checked = _AppointmentType.IsActive;
            btnAddOrUpdate.Enabled = _AppointmentType!=null;
            Mode = enMode.Update;
            btnAddOrUpdate.Text = "Update";


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbAppointmentType.Text = "";
            lblAppointmentTypeID.Text = "N/A";
            tbFees.Text = "";
            chkbxIsActive.Checked = false;
            _AppointmentType=new clsAppointmentTypes();
            btnAddOrUpdate.Enabled = true;
            Mode = enMode.Add;
            btnAddOrUpdate.Text = "New";


        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add | update this Type", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }


            _AppointmentType.AppointmentTypeTitle= tbAppointmentType.Text;
            _AppointmentType.AppointmentTypeFees=Convert.ToDecimal(tbFees.Text);
            _AppointmentType.IsActive=chkbxIsActive.Checked;
            if(!_AppointmentType.Save())
            {
                MessageBox.Show("Failed: Data didn't save successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblAppointmentTypeID.Text = _AppointmentType.AppointmentTypeID.ToString();
            MessageBox.Show("Data saved successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mode = enMode.Update;
            _RefereshAppointmentTypeData();

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentType.CurrentRow == null)
            {
                return;
            }
            int AppointmentTypeID = Convert.ToInt32(dgvAppointmentType.CurrentRow.Cells[0].Value);

            _AppointmentType = clsAppointmentTypes.Find(AppointmentTypeID);
            if (_AppointmentType == null)
            {
                return;
            }
            tbAppointmentType.Text = _AppointmentType.AppointmentTypeTitle;
            tbFees.Text = _AppointmentType.AppointmentTypeFees.ToString("N2");
            chkbxIsActive.Checked = _AppointmentType.IsActive;
            lblAppointmentTypeID.Text= _AppointmentType.AppointmentTypeID.ToString();
            btnAddOrUpdate.Enabled = false;
        }

        private void tbAppointmentType_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbAppointmentType.Text.Trim()))
            {
                errorProvider1.SetError(tbAppointmentType, "this Field is Required");
                e.Cancel = true;
                return;
            }

            if (clsAppointmentTypes.IsAppointmentTypeExist(tbAppointmentType.Text.Trim()))
            {
                if (Mode == enMode.Add||Mode == enMode.Update&&tbAppointmentType.Text.Trim()!=_AppointmentType.AppointmentTypeTitle)
                {
                    errorProvider1.SetError(tbAppointmentType, "this type already exists");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbAppointmentType, null);
                }
            }
            else
            {
                errorProvider1.SetError(tbAppointmentType, null);
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
    }
}
