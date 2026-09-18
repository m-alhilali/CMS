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

namespace CMS.Consultations
{
    public partial class frmManageConsultations : Form
    {
        private DataTable _dtConsultations;

        public frmManageConsultations()
        {
            InitializeComponent();
        }
        void _RefereshPeopleData()
        {
            _dtConsultations = clsConsultations.GetAllConsultations();
            dgvConsultations.DataSource = _dtConsultations;
            lblTotalRecord.Text = dgvConsultations.Rows.Count.ToString();
            if (dgvConsultations.Rows.Count > 0)
            {
                dgvConsultations.Columns["AppointmentID"].HeaderText = "App.ID";
                dgvConsultations.Columns["AppointmentID"].Width = 120;
                dgvConsultations.Columns["ConsultationID"].HeaderText = "Con.ID";
                dgvConsultations.Columns["ConsultationID"].Width = 120;
                dgvConsultations.Columns["ConsultationDate"].HeaderText = "Con.Date";
                dgvConsultations.Columns["AppointmentTypeTitle"].HeaderText = "App.Type";
                dgvConsultations.Columns["DoctorName"].Width = 300;
                dgvConsultations.Columns["PatientName"].Width = 300;
                dgvConsultations.Columns["AdditionalFees"].Width = 150;
                dgvConsultations.Columns["AdditionalFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvConsultations.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvConsultations.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void frmManageConsultations_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshPeopleData();
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
                if (_dtConsultations != null && _dtConsultations.Rows.Count > 0)
                {
                    _dtConsultations.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvConsultations.Rows.Count.ToString();
                }
            }

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Doctor Name":
                    Column = "DoctorName";
                    break;
                case "Patient Name":
                    Column = "PatientName";
                    break;
                case "Appointment Type":
                    Column = "AppointmentTypeTitle";
                    break;
                case "Consultation ID":
                    Column = "ConsultationID";
                    break;
                case "Appointmnet ID":
                    Column = "AppointmentID";
                    break;

            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtConsultations.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvConsultations.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "ConsultationID"||Column== "AppointmentID")
                {
                    _dtConsultations.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtConsultations.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtConsultations.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvConsultations.Rows.Count.ToString();
        }

        private void consultationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvConsultations.CurrentRow.Cells[1].Value);
            frmConsultationDetails frm = new frmConsultationDetails(AppointmentID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }

        private void patientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvConsultations.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvConsultations.CurrentRow.Cells[1].Value);
            int PatientID = clsAppointments.FindByAppointmentID(AppointmentID).PatientID;
            frmPatientDetails frm = new frmPatientDetails(PatientID);
            frm.ShowDialog();
            _RefereshPeopleData();

        }

        private void doctorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvConsultations.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvConsultations.CurrentRow.Cells[1].Value);
            int DoctorID = clsAppointments.FindByAppointmentID(AppointmentID).DoctorID;
            frmDoctorDetails frm = new frmDoctorDetails(DoctorID);
            frm.ShowDialog();
            _RefereshPeopleData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
