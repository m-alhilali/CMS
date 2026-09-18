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

namespace CMS.Doctors
{
    public partial class frmManageDoctors : Form
    {
        private DataTable _dtDoctors;
        public frmManageDoctors()
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
        void _RefereshPeopleData()
        {
            _dtDoctors = clsDoctors.GetAllDoctorsList();
            dgvPeople.DataSource = _dtDoctors;
            lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
            if (dgvPeople.Rows.Count > 0)
            {
              
                dgvPeople.Columns["DoctorID"].HeaderText = "Doctor ID";
                dgvPeople.Columns["DoctorID"].Width = 120;
                dgvPeople.Columns["FullName"].HeaderText = "Full Name";
                dgvPeople.Columns["FullName"].Width = 550;
                dgvPeople.Columns["Gender"].HeaderText = "Gender";
                dgvPeople.Columns["Gender"].Width = 150;
                dgvPeople.Columns["SpecialtyName"].HeaderText = "Specialty Name";
                dgvPeople.Columns["SpecialtyName"].Width = 300;
                dgvPeople.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvPeople.Columns["CreatedDate"].Width =250 ;
                dgvPeople.Columns["IsActive"].HeaderText = "Is Active";
                dgvPeople.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvPeople.RowsDefaultCellStyle.ForeColor = Color.Black;
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
                if (_dtDoctors != null && _dtDoctors.Rows.Count > 0)
                {
                    _dtDoctors.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
                }
            }
        
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbGenderFilter.Text;
            string Column = "Gender";
            if (Result == "All")
            {
                Result = "";
            }
            try
            {
                _dtDoctors.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, Result);
            }
            catch
            {
                _dtDoctors.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Doctor ID":
                    Column = "DoctorID";
                    break;
                case "Specialty Name":
                    Column = "SpecialtyName";
                    break;
                case "Full Name":
                    Column = "FullName";
                    break;
             
            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtDoctors.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "DoctorID")
                {
                    _dtDoctors.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtDoctors.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtDoctors.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
        }

        private void frmManageDoctors_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshPeopleData();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor frmAddUpdateDoctor = new frmAddUpdateDoctor();
            frmAddUpdateDoctor.ShowDialog();
            _RefereshPeopleData();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtDoctors.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
                return;
            }
            try
            {

                if(cbIsActive.Text=="No")
                {
                    Result = "0";

                }
                else
                {
                    Result = "1";

                }
                _dtDoctors.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtDoctors.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
        }

        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int DoctorID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            clsDoctors.InActive(DoctorID);
            _RefereshPeopleData();
        }
        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int DoctorID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            clsDoctors.Active(DoctorID);
            _RefereshPeopleData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int DoctorID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmAddUpdateDoctor frmAddUpdateDoctor = new frmAddUpdateDoctor(DoctorID);
            frmAddUpdateDoctor.ShowDialog();
            _RefereshPeopleData();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int DoctorID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            clsDoctors _Doctor = clsDoctors.FindByDoctorID(DoctorID);
            activeToolStripMenuItem.Enabled = !_Doctor.IsActive;
            inActiveToolStripMenuItem.Enabled = _Doctor.IsActive;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int DoctorID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmDoctorDetails frmAddUpdateDoctor = new frmDoctorDetails(DoctorID);
            frmAddUpdateDoctor.ShowDialog();
            _RefereshPeopleData();
        }

       
    }
}
