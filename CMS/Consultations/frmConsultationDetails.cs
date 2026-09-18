using CMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Consultations
{
    public partial class frmConsultationDetails : Form
    {
        private int _AppointmentID = -1;
        private clsConsultations _Consultation;
        private DataTable _dtPrescriptionItem;
        public frmConsultationDetails(int ConsultationID)
        {
            InitializeComponent();
            _AppointmentID = ConsultationID;
        }

        private void _LoadPrescriptionItem()
        {
            DataTable dt=new DataTable();
            if (_dtPrescriptionItem != null&_dtPrescriptionItem.Rows.Count>0)
            {
                dt = _dtPrescriptionItem.DefaultView.ToTable(false, "MedicineName", "Duration", "DurationUnit", "Dosage", "SpecialInstructions", "PaidFees");
            }
            dgvPrescription.DataSource = dt;
            if (dgvPrescription.Rows.Count > 0)
            {
                dgvPrescription.Columns["PaidFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvPrescription.Columns["PaidFees"].DefaultCellStyle.ForeColor = Color.Green;
                dgvPrescription.Columns["PaidFees"].DefaultCellStyle.SelectionForeColor = Color.White;
                dgvPrescription.Columns["PaidFees"].DefaultCellStyle.SelectionBackColor = Color.Green;
                dgvPrescription.Columns["MedicineName"].Width=300;
                dgvPrescription.Columns["Duration"].Width=100;
                dgvPrescription.Columns["DurationUnit"].Width=120;
                dgvPrescription.Columns["PaidFees"].Width=150;

            }

        }

        private void _LoadPatientInformation()
        {
            lblPatientID.Text = _Consultation.AppointmentsInfo.PatientID.ToString();
            lblPatientName.Text = _Consultation.AppointmentsInfo.PatientInfo.PersonInfo.FullName;
            lblPatientGender.Text = _Consultation.AppointmentsInfo.PatientInfo.PersonInfo.Gender==clsPerson.enGender.Male?"Male":"Female";
            lblPatientPhone.Text = _Consultation.AppointmentsInfo.PatientInfo.PersonInfo.Phone;
            lblPatientAge.Text = (DateTime.Now.Year-_Consultation.AppointmentsInfo.PatientInfo.PersonInfo.DateOfBirth.Year).ToString();
        }
        private void _LoadDoctorInformation()
        {
            lblDoctorID.Text = _Consultation.AppointmentsInfo.DoctorID.ToString();
            lblDoctorName.Text = _Consultation.AppointmentsInfo.DoctorInfo.PersonInfo.FullName;
            lblDoctorSpecialization.Text = _Consultation.AppointmentsInfo.DoctorInfo.SpecialtyInfo.SpecialtyName;
            lblDoctorPhone.Text = _Consultation.AppointmentsInfo.DoctorInfo.PersonInfo.Phone;
        }
        private void _LoadConsultationInformation()
        {
            lblAppointmentID.Text = _Consultation.AppointmentID.ToString();
            lblConsultationID.Text = _Consultation.ConsultationID.ToString();
            lblConsultationDate.Text = _Consultation.ConsultationDate.ToShortDateString();
            lblConsultationTime.Text = _Consultation.ConsultationDate.ToShortTimeString();
            tbAppointmentType.Text = _Consultation.AppointmentsInfo.AppointmentTypeInfo.AppointmentTypeTitle;
            tbDiagnosis.Text = _Consultation?.Diagnosis;
            tbNotes.Text = _Consultation?.Notes;
            if(_dtPrescriptionItem!=null && _dtPrescriptionItem.Rows.Count!=0)
            {
                decimal Fees;
                if (decimal.TryParse(_dtPrescriptionItem.Compute("SUM(PaidFees)", $"ConsultationID='{_Consultation.ConsultationID}'").ToString(), out Fees))
                {
                    lblConsultationFees.Text = "$ "+Fees.ToString("N2");
                }
            }
        }
        private void _LoadData()
        {
            
            _dtPrescriptionItem = clsPrescriptionItems.GetActivePrescriptionItemsByConsultationID(_Consultation.ConsultationID);
            _LoadDoctorInformation();
            _LoadPatientInformation();
            _LoadConsultationInformation();
            _LoadPrescriptionItem();
        }
        private void frmConsultationDetails_Load(object sender, EventArgs e)
        {
            _Consultation = clsConsultations.FindByAppointmentID(_AppointmentID);
            if (_Consultation == null)
            {
                MessageBox.Show($"Error: There No Consultation with Appointment ID {_AppointmentID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _LoadData();
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultationDetails_Activated(object sender, EventArgs e)
        {
            btnExit.Focus();
        }
    }
}
