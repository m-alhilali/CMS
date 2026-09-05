using CMS.Consultations;
using CMS.Doctors;
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
    public partial class frmPatientDetails : Form
    {
        private clsPatients _Patient;
        private DataTable _dtConsultations;
        private DataTable _dtConsultationsPatient;
        private int _PatientID;

        public frmPatientDetails(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
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
            lblCreatedByUser.Text=_Patient.UserInfo.UserName;
            lblCreatedDate.Text = _Patient.CreatedDate.ToString("MMM dd, yyyy");
            ctrlPersonInfo1.Loadinfo(_Patient.PersonID);
            _dtConsultations = clsConsultations.GetAllConsultations();
            _dtConsultationsPatient = _dtConsultations.DefaultView.ToTable(false, "ConsultationID", "AppointmentID", "DoctorName", "AppointmentTypeTitle", "ConsultationDate", "AdditionalFees");
            dgvConsultations.DataSource = _dtConsultationsPatient;
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
                //dgvConsultations.Columns["PatientName"].Width = 300;
                dgvConsultations.Columns["AdditionalFees"].Width = 150;
                dgvConsultations.Columns["AdditionalFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvConsultations.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvConsultations.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void frmPatientDetails_Load(object sender, EventArgs e)
        {
            _Patient = clsPatients.FindByPatientID(_PatientID);
            if (_Patient == null)
            {
                MessageBox.Show($"Error: There is no patient with ID {_PatientID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _RefereshPeopleData();

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

        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
