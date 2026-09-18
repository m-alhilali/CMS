using CMS.Consultations;
using CMS.Doctors;
using CMS.Patients;
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

namespace CMS.PrescriptionItems
{
    public partial class frmManagePrescriptionItems : Form
    {
        private DataTable _dtPrescriptionItems;
        public frmManagePrescriptionItems()
        {
            InitializeComponent();
        }
        void _RefereshPeopleData()
        {
            _dtPrescriptionItems = clsPrescriptionItems.GetAllPrescriptionItems();
            dgvPrescriptionItems.DataSource = _dtPrescriptionItems;
            lblTotalRecord.Text = dgvPrescriptionItems.Rows.Count.ToString();
            if (dgvPrescriptionItems.Rows.Count > 0)
            {

                dgvPrescriptionItems.Columns["PrescriptionItemID"].HeaderText = "Pre.ID";
                dgvPrescriptionItems.Columns["PrescriptionItemID"].Width = 120;
                dgvPrescriptionItems.Columns["ConsultationID"].HeaderText = "Consul.ID";
                dgvPrescriptionItems.Columns["ConsultationID"].Width = 120;
                dgvPrescriptionItems.Columns["MedicineName"].HeaderText = "Medicine Name";
                dgvPrescriptionItems.Columns["MedicineName"].Width = 200;
                dgvPrescriptionItems.Columns["Duration"].Width = 100;
                dgvPrescriptionItems.Columns["DurationUnit"].Width = 130;
                dgvPrescriptionItems.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvPrescriptionItems.Columns["PaidFees"].Width = 120;
                dgvPrescriptionItems.Columns["PaidFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvPrescriptionItems.Columns["IsActive"].HeaderText = "Is Active";
                dgvPrescriptionItems.Columns["IsActive"].Width = 150;
                dgvPrescriptionItems.Columns["SpecialInstructions"].HeaderText = "Special Instructions";
                dgvPrescriptionItems.Columns["SpecialInstructions"].Width = 300;
                dgvPrescriptionItems.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvPrescriptionItems.Columns["CreatedDate"].Width = 150;
                dgvPrescriptionItems.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                //dgvPrescriptionItems.RowsDefaultCellStyle.ForeColor = Color.Black;
                dgvPrescriptionItems.Columns["PaidFees"].DefaultCellStyle.SelectionForeColor = Color.Green;
                dgvPrescriptionItems.Columns["PaidFees"].DefaultCellStyle.ForeColor = Color.Green;
            }
        }

        private void frmManagePrescriptionItems_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _RefereshPeopleData();
        }

        private void consultationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionItems.CurrentRow == null)
            {
                return;
            }
            int ConsultationID = Convert.ToInt32(dgvPrescriptionItems.CurrentRow.Cells[1].Value);
            int AppointmentID=clsConsultations.FindByConsultationID(ConsultationID).AppointmentID;
            frmConsultationDetails frm = new frmConsultationDetails(AppointmentID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtPrescriptionItems.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvPrescriptionItems.Rows.Count.ToString();
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
                _dtPrescriptionItems.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtPrescriptionItems.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPrescriptionItems.Rows.Count.ToString();
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
                if (_dtPrescriptionItems != null && _dtPrescriptionItems.Rows.Count > 0)
                {
                    _dtPrescriptionItems.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvPrescriptionItems.Rows.Count.ToString();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "PrescriptionItem ID":
                    Column = "PrescriptionItemID";
                    break;
                case "Consultation ID":
                    Column = "ConsultationID";
                    break;
                case "Medicine Name":
                    Column = "MedicineName";
                    break;
                case "Duration":
                    Column = "Duration";
                    break;
                case "Duration Unit":
                    Column = "DurationUnit";
                    break;

            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtPrescriptionItems.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvPrescriptionItems.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "ConsultationID" || Column == "PrescriptionItemID"||Column=="Duration")
                {
                    _dtPrescriptionItems.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtPrescriptionItems.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtPrescriptionItems.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPrescriptionItems.Rows.Count.ToString();

        }

        private void doctordetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionItems.CurrentRow == null)
            {
                return;
            }
            int ConsultationID = Convert.ToInt32(dgvPrescriptionItems.CurrentRow.Cells[1].Value);
            int DoctorID=clsConsultations.FindByConsultationID(ConsultationID).AppointmentsInfo.DoctorID;
            frmDoctorDetails frm = new frmDoctorDetails(DoctorID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }

        private void patientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionItems.CurrentRow == null)
            {
                return;
            }
            int ConsultationID = Convert.ToInt32(dgvPrescriptionItems.CurrentRow.Cells[1].Value);
            int PatientID = clsConsultations.FindByConsultationID(ConsultationID).AppointmentsInfo.PatientID;
            frmPatientDetails frm = new frmPatientDetails(PatientID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }
    }
}
