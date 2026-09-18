using CMS.Consultations;
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

namespace CMS.Patients
{
    public partial class frmManagePatients : Form
    {

        private DataTable _dtPatients;

        public frmManagePatients()
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
            _dtPatients = clsPatients.GetAllPatientList();
            dgvPatients.DataSource = _dtPatients;
            lblTotalRecord.Text = dgvPatients.Rows.Count.ToString();
            if (dgvPatients.Rows.Count > 0)
            {
                dgvPatients.Columns["PatientID"].HeaderText = "Patient ID";
                dgvPatients.Columns["PatientID"].Width = 200;
                dgvPatients.Columns["FullName"].HeaderText = "Full Name";
                dgvPatients.Columns["FullName"].Width = 500;
                dgvPatients.Columns["BloodType"].HeaderText = "Blood Type";
                dgvPatients.Columns["Gender"].Width = 200;
                dgvPatients.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvPatients.Columns["IsActive"].HeaderText = "Is Active";
                dgvPatients.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvPatients.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }
        private void frmManagePatients_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _RefereshPeopleData(); 
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm=new frmAddUpdatePatient();
            frm.ShowDialog();
            frmManagePatients_Load(null, null);
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
                if (_dtPatients != null && _dtPatients.Rows.Count > 0)
                {
                    _dtPatients.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvPatients.Rows.Count.ToString();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Patient ID":
                    Column = "PatientID";
                    break;
                case "Blood Type":
                    Column = "BloodType";
                    break;
                case "Full Name":
                    Column = "FullName";
                    break;
                
            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtPatients.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvPatients.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "PatientID")
                {
                    _dtPatients.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtPatients.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtPatients.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = _dtPatients.Rows.Count.ToString();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtPatients.DefaultView.RowFilter = "";
                lblTotalRecord.Text = _dtPatients.Rows.Count.ToString();
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
                _dtPatients.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtPatients.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPatients.Rows.Count.ToString();
        }

        private void cbGenderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbGenderFilter.Text;
            string Column = "Gender";
            if (Result == "All")
            {
                Result = "";
            }
            try
            {
                _dtPatients.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, Result);
            }
            catch
            {
                _dtPatients.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPatients.Rows.Count.ToString();
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                return;
            }
            int PatintID = Convert.ToInt32(dgvPatients.CurrentRow.Cells[0].Value);
            frmAddUpdatePatient frm = new frmAddUpdatePatient(PatintID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }

        private void consultationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                return;
            }
            int PatintID = Convert.ToInt32(dgvPatients.CurrentRow.Cells[0].Value);
            clsAppointments a = clsAppointments.FindByPatientID(PatintID);
            if (a == null)
            {
                return;
            }
            frmConsultationDetails frm = new frmConsultationDetails(a.AppointmentID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                return;
            }
            int PatintID = Convert.ToInt32(dgvPatients.CurrentRow.Cells[0].Value);
            frmPatientDetails frm = new frmPatientDetails(PatintID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }
    }
}
