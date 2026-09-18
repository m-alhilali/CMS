using CMS_Business;
using FontAwesome.Sharp;
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
    public partial class frmAppointmentDetails : Form
    {
        private int _AppointmentID = -1;
        private clsAppointments _Appointment;
        private Color TransparentGreen = Color.FromArgb(70, 192, 255, 192);
        private Color TransparentRed = Color.FromArgb(70, 255, 128, 128);
        public frmAppointmentDetails(int AppointmentID)
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


        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);

        }

        private string GetAppointmentStatus()
        {
            switch (_Appointment.AppointmentStatus)
            {
                case clsAppointments.enAppointmentStatus.Pending:
                    return "Pending";
                case clsAppointments.enAppointmentStatus.Cancelled:
                    return "Cancelled";
                case clsAppointments.enAppointmentStatus.Completed:
                    return "Completed";
                case clsAppointments.enAppointmentStatus.NotAttended:
                    return "Not Attended";
            }
            return "UnKnown";
        }
        private void _LoadDoctorInformation()
        {
            lblDoctorName.Text = _Appointment.DoctorInfo.PersonInfo.FullName;
            lblDoctorPhone.Text = _Appointment.DoctorInfo.PersonInfo.Phone;
            lblSpecialty.Text = _Appointment.DoctorInfo.SpecialtyInfo.SpecialtyName;
        }
        private void _LoadPatientInformation()
        {
            lblPatientName.Text = _Appointment.PatientInfo.PersonInfo.FullName;
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
            lblAppointmentStatus1.Text = GetAppointmentStatus();
            lblAppointmentStatus1.ForeColor = iconStatus.ForeColor;
            lblAppointmentDuration.Text = "30 Minutes";

            lblCreatedBy.Text = _Appointment.UserInfo.UserName;
            lblLastDateUpdated.Text = _Appointment.LastStatusDate.ToString();
            lblCreatedDate.Text = _Appointment.CreatedDate.ToString();
            lblAppointmentStatus2.Text = lblAppointmentStatus1.Text;
            lblAppointmentStatus2.ForeColor = lblAppointmentStatus1.ForeColor;
        }
        private void _LoadData()
        {
            panelStatus.BackColor = _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Pending || _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Completed ? TransparentGreen : TransparentRed;
            iconStatus.ForeColor =_Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Pending || _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Completed ? Color.Green : Color.Red;
            iconStatus.IconChar = _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Pending || _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Completed ?IconChar.CircleCheck: IconChar.CircleXmark;

            _LoadDoctorInformation();
            _LoadPatientInformation();
            _LoadAppointmentformation();
            btnCancelAppointment.Enabled = _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Pending;
            btnEditAppointment.Enabled = _Appointment.AppointmentStatus == clsAppointments.enAppointmentStatus.Pending;

        }

        private void frmAppointmentDetails_Load(object sender, EventArgs e)
        {
            _Appointment = clsAppointments.FindByAppointmentID(_AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show($"Failed: There is no Appointment with ID {_AppointmentID} !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _LoadData();

        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (_Appointment == null)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to cancel this appointment", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            _Appointment.Cancelled();
            frmAppointmentDetails_Load(null, null);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (_Appointment == null)
            {
                return;
            }
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment(_Appointment.AppointmentID);
            frm.ShowDialog();
            frmAppointmentDetails_Load(null, null);
        }
    }
}
