using CMS.PrescriptionItems;
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
using static CMS_Business.clsAppointments;

namespace CMS.Appointments
{
    public partial class frmAttendingAppointment : Form
    {
        private int _AppointmentID = -1;
        private clsAppointments _Appointment;
        private clsConsultations _Consulations;
        private enum enMode { Add=1,Update=2}
        private enMode Mode = enMode.Add;
        public frmAttendingAppointment(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
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
        private void _LoadPatientInformation()
        {
            lblPatientName2.Text = _Appointment.PatientInfo.PersonInfo.FullName;
            lblNationalNo.Text = _Appointment.PatientInfo.PersonInfo.NationalNo;
            lblPatientPhone.Text = _Appointment.PatientInfo.PersonInfo.Phone;
            lblPatientDateOfBirth.Text = _Appointment.PatientInfo.PersonInfo.DateOfBirth.ToString("d");
            lblGender.Text = _Appointment.PatientInfo.PersonInfo.Gender == clsPerson.enGender.Male ? "Male" : "Female";
            lblBloodType.Text = _Appointment.PatientInfo.BloodType;
        }
        private void _LoadAppointmentformation()
        {
            lblAppointmentDate.Text = _Appointment.AppointmentDate.ToString("MMMM d,yyyy");
            lblAppointmentType.Text = _Appointment.AppointmentTypeInfo.AppointmentTypeTitle;
            lblAppointmentTime.Text = _Appointment.AppointmentDate.Date.ToShortTimeString();
            lblDoctorName.Text = _Appointment.DoctorInfo.PersonInfo.FullName;
            lblPatientName1.Text = _Appointment.PatientInfo.PersonInfo.FullName;
            lblAppointmentID.Text=_Appointment.AppointmentID.ToString();

            if (Mode == enMode.Add)
            {
                lblDateOfConsultation.Text = DateTime.Now.ToString("MMMM d,yyyy  hh:mm tt");
                lblByUser.Text = clsGlobal.CurrentUser.UserName;
            }

        }
        private void _LoadConsultatioinformation()
        {
            if (_Consulations != null)
            {
                lblDateOfConsultation.Text = _Consulations.ConsultationDate.ToString("MMMM d,yyyy  hh:mm tt");
                lblByUser.Text = _Consulations.UserInfo.UserName;
                tbDiagnosis.Text = _Consulations.Diagnosis;
                tbNotes.Text = _Consulations.Notes;
                tbFees.Text = _Consulations?.AdditionalFees.ToString("N2");
            }
        }
        private void _ResetData()
        {
            _Consulations = clsConsultations.FindByAppointmentID(_AppointmentID);
            if (_Appointment.AppointmentStatus ==enAppointmentStatus.Completed)
            {
                if (_Consulations == null)
                {
                    btnAddOrUpdate.Enabled = false;
                    MessageBox.Show($"Failed: There is no Consultation with Appointment ID {_AppointmentID} !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                Mode = enMode.Update;
                lblTitle.Text = "Attendance Update";
                btnAddPrescription.Enabled = _Consulations!=null;
                _LoadConsultatioinformation();
            }
            else
            {
                _Consulations=new clsConsultations();
                lblTitle.Text = "Attend the appointment";
            }
            _LoadAppointmentformation();
            _LoadPatientInformation();
        }
        private void frmAttendingAppointment_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _Appointment = clsAppointments.FindByAppointmentID(_AppointmentID);
            if (_Appointment == null)
            {
                btnAddOrUpdate.Enabled = false;
                MessageBox.Show($"Failed: There is no Appointment with ID {_AppointmentID} !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            bool IsAvailableDate =DateTime.Now >= _Appointment.AppointmentDate && DateTime.Now< _Appointment.AppointmentDate.AddMinutes(30);
            if (_Appointment.AppointmentStatus == enAppointmentStatus.Pending || _Appointment.AppointmentStatus == enAppointmentStatus.Completed)
            {
                if (!IsAvailableDate)
                {
                    bool BiggerTime = _Appointment.AppointmentDate > DateTime.Now;
                    string Message = BiggerTime ? "Your appointment is not yet available?" : "Your appointment Finished?";
                    MessageBox.Show($"Sorry: The date {Message} ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    _ResetData();
                }
            }
            else
            {
                string TypeError = _Appointment.AppointmentStatus == enAppointmentStatus.Cancelled ? "Cancelled" : _Appointment.AppointmentStatus == enAppointmentStatus.NotAttended ? "Not Attended" : _Appointment.AppointmentStatus == enAppointmentStatus.Completed ? "Completed" : "Pending";
                MessageBox.Show($"Failed: This Appointment is {TypeError}!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddOrUpdate.Enabled = false;
                this.Close();
                return;
            }


        }
        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text.Trim()))
            {
                errorProvider1.SetError(tbFees, "This Field is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbFees, null);
            }
        }
        private void tbDiagnosis_Validating(object sender, CancelEventArgs e)
        {

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
        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add | update this Consultation", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }


            _Consulations.ConsultationDate = DateTime.Now;
            _Consulations.Notes = tbNotes.Text.Trim();
            _Consulations.Diagnosis = tbDiagnosis.Text.Trim();
            _Consulations.AdditionalFees = Convert.ToDecimal(tbFees?.Text.Trim());
            _Consulations.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Consulations.AppointmentID = _Appointment.AppointmentID;
            if (!_Consulations.Save())
            {
                MessageBox.Show("Failed: Data didn't save successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblConsultationID.Text = _Consulations.ConsultationID.ToString();
            MessageBox.Show("Data saved successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mode = enMode.Update;
            _Appointment.AppointmentStatus = clsAppointments.enAppointmentStatus.Completed;
            _ResetData();
            btnAddPrescription.Enabled = true;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (_Consulations!=null)
            {
                frmAddUpdatePrescriptionItems frm = new frmAddUpdatePrescriptionItems(_Consulations.ConsultationID);
                frm.ShowDialog();
            }

        }
    }
}