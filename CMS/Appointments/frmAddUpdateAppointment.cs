using CMS.Patients;
using CMS_Business;
using Guna.UI2.WinForms;
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
    public partial class frmAddUpdateAppointment : Form
    {
        private clsAppointments _Appointment;
        private clsAppointmentTypes _Type;
        private int _AppointmentID=-1;
        private enum enMode { Add=1, Update=2};
        private enMode Mode= enMode.Add;
        private DataTable _dtActiveDoctorAppointment;
        public frmAddUpdateAppointment()
        {
            InitializeComponent();
            Mode= enMode.Add;
        }
        public frmAddUpdateAppointment(int AppointmentID)
        {
            InitializeComponent();
            Mode= enMode.Update;
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
        private void _FillComboboxAppointmentTypes()
        {
            DataTable dt = clsAppointmentTypes.GetAllAppointmentTypesList();
            if (dt != null)
            {
                cbAppointmentType.DataSource= dt;
                cbAppointmentType.DisplayMember = "AppointmentTypeTitle";
                cbAppointmentType.ValueMember = "AppointmentTypeID";
               
            }
        }
        private void _FillComboboxDoctors()
        {
            DataTable dt = clsDoctors.GetAllDoctorsList();
            if (dt != null)
            {
                cbDoctor.DataSource = dt;
                cbDoctor.DisplayMember = "FullName";
                cbDoctor.ValueMember = "DoctorID";
                cbDoctor_SelectedIndexChanged(null, null);
            }
        }
        private void _FillComboboxPatients()
        {
            DataTable dt = clsPatients.GetAllPatientList();
            if (dt != null)
            {
                cbPatient.DataSource = dt;
                cbPatient.DisplayMember = "FullName";
                cbPatient.ValueMember = "PatientID";
            }
        }
        private void _ResetDefaultData()
        {
            if (Mode == enMode.Add)
            {
                _Appointment = new clsAppointments();
                lblTitle.Text = "Reserve a new appointment";
            }
            else
            {
                lblTitle.Text = "Update your reservation";
            }
            this.Text = lblTitle.Text;

            dtpDate.MinDate = DateTime.Now;
            dtpDate.MaxDate = DateTime.Now.AddMonths(1);
            _FillComboboxAppointmentTypes();
            _FillComboboxDoctors();
            _FillComboboxPatients();
            lblDateChoised.Text = dtpDate.SelectionStart.ToString("MMMM d,yyyy");
            lblAppointmentDate.Text = lblDateChoised.Text;
            lblFees.Text = clsAppointmentTypes.Find(Convert.ToInt32(cbAppointmentType.SelectedValue))?.AppointmentTypeFees.ToString("N2");
            lblAppointmentType.Text = cbAppointmentType.Text; ;
        }
        private void btnToCheck()
        {
            string Time = _Appointment.AppointmentDate.TimeOfDay.ToString();

            RadioButton[] timebutton = new RadioButton[] { btn09 , btn0930, btn10, btn1030,
                                                           btn11, btn1130, btn12, btn1230, btn01,
                                                           btn0130, btn02, btn0230, btn03, btn0330,
                                                           btn04, btn0430, btn05, btn0530 };
            foreach (var btn in timebutton)
            {
                btn.Checked=btn.Tag.ToString() == Time;
            }
        }
        private void _LoadDate()
        {
            _Appointment = clsAppointments.FindByAppointmentID(_AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show($"Appointment with ID {_AppointmentID} is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _dtActiveDoctorAppointment = clsAppointments.GetActiveAppointmentsByDoctorID(_Appointment.DoctorID);
            lblAppointmentID.Text = _Appointment.AppointmentID.ToString();
            if(_Appointment.AppointmentDate< dtpDate.SelectionStart)
            {
                dtpDate.SelectionStart = dtpDate.MinDate;
            }
            else
                dtpDate.SelectionStart = _Appointment.AppointmentDate;

            lblFees.Text =_Appointment.AppointmentFees.ToString("N2");
            cbAppointmentType.SelectedIndex = cbAppointmentType.FindString(_Appointment.AppointmentTypeInfo.AppointmentTypeTitle);
            cbDoctor.SelectedIndex = cbDoctor.FindString(_Appointment.DoctorInfo.PersonInfo.FirstName);
            cbPatient.SelectedIndex = cbPatient.FindString(_Appointment.PatientInfo.PersonInfo.FirstName);
            lblDateChoised.Text = dtpDate.SelectionStart.ToString("MMMM d,yyyy");
            lblAppointmentDate.Text = lblDateChoised.Text;
            lblDoctorName.Text = cbDoctor.Text;
            lblPatientName.Text = cbPatient.Text;
            lblAppointmentType.Text = cbAppointmentType.Text;
            lblSummaryTime.Text = _Appointment.AppointmentDate.ToShortTimeString();
            btnToCheck();
            cbPatient.Enabled = false;
            btnReserve.Enabled = true;
        }
        private void frmAddUpdateAppointment_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _ResetDefaultData();
            if(Mode==enMode.Update)
            {
                _LoadDate();
            }
        }
        private void btn09_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            lblSummaryTime.Text = ctrl.Text;
            lblSummaryTime.Tag = ctrl.Tag;
        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);

        }
        private void BataBack(object sender, int PatientID)
        {
            _FillComboboxPatients();
            string PatientName = clsPatients.FindByPatientID(PatientID)?.PersonInfo.FullName;
            cbPatient.SelectedIndex=cbPatient.FindString(PatientName);
        }
        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm = new frmAddUpdatePatient();
            frm.DataBack += BataBack;
            frm.ShowDialog();
        }
        private void cbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPatientName.Text=cbPatient.Text;
        }
        private void cbAppointmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int AppointmentID = -1;
                if (cbDoctor.SelectedValue == null || !int.TryParse(cbAppointmentType.SelectedValue.ToString(), out AppointmentID))
                {
                    return;
                }
                _Type=clsAppointmentTypes.Find(AppointmentID);
                lblAppointmentType.Text = _Type.AppointmentTypeTitle;
                lblFees.Text = _Type.AppointmentTypeFees.ToString("N2");
                if (!_Type.IsActive)
                {
                    MessageBox.Show("Appointment Type is not available now!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch { }
        }
        private void cbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DoctorID = -1;
            if (cbDoctor.SelectedValue==null||!int.TryParse(cbDoctor.SelectedValue.ToString(), out DoctorID))
            {
                return;
            }

            lblDoctorName.Text = cbDoctor.Text;

            RadioButton[] timebutton = new RadioButton[] { btn09 , btn0930, btn10, btn1030,
                                                           btn11, btn1130, btn12, btn1230, btn01,
                                                           btn0130, btn02, btn0230, btn03, btn0330,
                                                           btn04, btn0430, btn05, btn0530 };
            foreach (var btn in timebutton)
            {
                btn.Enabled = true;
            }


            if(DoctorID != _Appointment?.DoctorID)
            {
                _dtActiveDoctorAppointment = clsAppointments.GetActiveAppointmentsByDoctorID(DoctorID);
            }

            if(_dtActiveDoctorAppointment==null||_dtActiveDoctorAppointment.Rows.Count<=0)
            {
                return;
            }

            List<DateTime>SchedulAppointments = new List <DateTime>();
            DateTime dt = DateTime.MinValue;
            foreach (DataRow row in _dtActiveDoctorAppointment.Rows)
            {
                dt = Convert.ToDateTime(row["AppointmentDate"]);
                SchedulAppointments.Add(dt);
            }


            foreach (var btn in timebutton)
            {

                if (TimeSpan.TryParse(btn.Tag.ToString().Trim(), out TimeSpan TimeOnly))
                {
                    DateTime btnDateTime = dtpDate.SelectionStart.Date.Add(TimeOnly);
                    if (SchedulAppointments.Contains(btnDateTime))
                    {
                        if (Mode == enMode.Add)
                            btn.Enabled = false;
                        else
                        {
                            if (cbPatient.SelectedValue == null || cbDoctor.SelectedValue == null)
                                return;
                            else
                            {
                                int PatientID=-1;
                                PatientID = Convert.ToInt32(cbPatient.SelectedValue);
                                btn.Enabled = (Mode == enMode.Update && PatientID == _Appointment.PatientID && DoctorID == _Appointment.DoctorID);
                            }
                        }
                    }
                }
            }


        }
        private void dtpDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            cbDoctor_SelectedIndexChanged(null, null);
            lblDateChoised.Text = dtpDate.SelectionStart.ToString("MMMM d,yyyy");
            lblAppointmentDate.Text = lblDateChoised.Text;
        }
        private void btnCloase_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReserve_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add | update this appointment", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.No)
            {
                return;
            }

            if (!TimeSpan.TryParse(lblSummaryTime.Tag?.ToString().Trim(), out TimeSpan TimeOnly))
            {
                MessageBox.Show("Failed: Invalid Date Format in Tag !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime NewTime = dtpDate.SelectionStart.Date.Add(TimeOnly);
            bool IsHaseActiveAppointment = clsAppointments.IsHaveAnActiveAppointmentInThisTime(Convert.ToInt32(cbDoctor.SelectedValue),NewTime);
            if (IsHaseActiveAppointment && Mode==enMode.Add||IsHaseActiveAppointment&&Mode==enMode.Update && _Appointment.AppointmentDate!= NewTime)
            {
                MessageBox.Show("Sorry: Patient already have appointment in this time!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Appointment.AppointmentDate =NewTime;
            _Appointment.AppointmentFees = Convert.ToDecimal(lblFees.Text);
            _Appointment.AppointmentStatus = clsAppointments.enAppointmentStatus.Pending;
            _Appointment.AppointmentTypeID =Convert.ToInt32(cbAppointmentType.SelectedValue);
            _Appointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Appointment.LastStatusDate=DateTime.Now;
            _Appointment.CreatedDate=DateTime.Now;
            _Appointment.PatientID = Convert.ToInt32(cbPatient.SelectedValue);
            _Appointment.DoctorID = Convert.ToInt32(cbDoctor.SelectedValue);
            if(!_Appointment.Save())
            {
                MessageBox.Show("Failed: Data didn't save successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAppointmentID.Text = _Appointment.AppointmentID.ToString();
            MessageBox.Show("Data saved successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblTitle.Text = "Update your reservation";
            Mode = enMode.Update;


        }
        private void lblSummaryTime_Validating(object sender, CancelEventArgs e)
        {
            if (!DateTime.TryParse(lblSummaryTime.Text.Trim(), out DateTime TimeOnly))
            {
                errorProvider1.SetError(lblSummaryTime, "Enter Available Time");
                btnReserve.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(lblSummaryTime,null);
                btnReserve.Enabled = true;
            }
        }
        private void cbAppointmentType_Validating(object sender, CancelEventArgs e)
        {
            if (cbAppointmentType.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbAppointmentType, "You have to choice a Type of Appointment");
                e.Cancel = true;
                return;
            }

            int TypeID = Convert.ToInt32(cbAppointmentType.SelectedValue);
            bool IsActive = clsAppointmentTypes.Find(TypeID).IsActive;
            btnReserve.Enabled = IsActive;

            if (!IsActive)
            {
                errorProvider1.SetError(cbAppointmentType, "Appointment is not available now!");
                e.Cancel= true;
            }
            else
            {
                errorProvider1.SetError(cbAppointmentType, null);
            }
        }
        private void cbDoctor_Validating(object sender, CancelEventArgs e)
        {
            if (cbDoctor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbDoctor, "You have to choice a Doctor");
                e.Cancel = true;
                return;
            }


            int.TryParse(cbDoctor.SelectedValue.ToString(), out int DoctorID);
            bool IsActive = clsDoctors.FindByDoctorID(DoctorID).IsActive;
            btnReserve.Enabled = IsActive;
            if (!IsActive)
            {
                errorProvider1.SetError(cbDoctor, "Doctor is not available now!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbDoctor, null);
            }

        }
        private void cbPatient_Validating(object sender, CancelEventArgs e)
        {
            if (cbPatient.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbPatient, "You have to choice a patient");
                e.Cancel = true;
                return;
            }
            if(cbDoctor.SelectedIndex==-1)
            {
                return;
            }
            int Doctor_PersonID = clsDoctors.FindByDoctorID(Convert.ToInt32(cbDoctor.SelectedValue)).PersonID;
            int Patient_PersonID = clsPatients.FindByPatientID(Convert.ToInt32(cbPatient.SelectedValue)).PersonID;
            if (Doctor_PersonID == Patient_PersonID)
            {
                errorProvider1.SetError(cbPatient, "Ops! The Patient already is a Doctor");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbPatient, null);
            }
        }
    }
}
