using CMS.Appointments;
using CMS.Consultations;
using CMS.Doctors;
using CMS.Medicines;
using CMS.Patients;
using CMS.People;
using CMS.Users;
using CMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static CMS_Business.clsAppointments;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CMS.DashBoard
{
    public partial class frmDashboard : Form
    {
        private static DateTime Today = DateTime.Today;
        private static DateTime Tomorrow = Today.AddDays(1);

        private DataTable _Patients;
        private DataTable _Doctors;
        private DataTable _AllConsultations;
        private DataTable _TodayConsultations;
        private DataTable _AllAppointments;
        private DataTable _TodayAppointments;
        private clsAppointments _Appointment;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void _LoadPatientsData()
        {
            _Patients = clsPatients.GetAllPatientList();
            lblTotalPatients.Text = _Patients?.Rows.Count.ToString();
            lblIncreasedPatientAtLastMonth.Text = "+ " + _Patients?.Compute("COUNT(PatientID)", $"CreatedDate >= '{DateTime.Now.Date.AddMonths(-1)}'").ToString() + " This Month";

        }
        private void _LoadDoctorsData()
        {
            _Doctors = clsDoctors.GetAllDoctorsList();
            lblTotalDoctors.Text = _Doctors?.Rows.Count.ToString();
            lblIncreasedDoctorsAtLastMonth.Text = "+ " + _Doctors?.Compute("COUNT(DoctorID)", $"CreatedDate >= '{DateTime.Now.Date.AddMonths(-1)}'").ToString() + " This Month";

        }
        private void _LoadConsultationsData()
        {
            

            _AllConsultations = clsConsultations.GetAllConsultations();
            lblTotalConsultations.Text = _AllConsultations?.Rows.Count.ToString();
            lblIncreasedConsultationsAtLastMonth.Text = "+ " + _AllConsultations?.Compute("COUNT(ConsultationID)", $"ConsultationDate >= '{Today:yyyy-MM-dd}' And ConsultationDate <'{Tomorrow:yyyy-MM-dd}'") + " This Month";
            if (_AllConsultations != null)
            {
               
                _TodayConsultations = _AllConsultations.DefaultView.ToTable(false, "ConsultationID", "AppointmentID", "PatientName", "DoctorName", "ConsultationDate","AdditionalFees");
                dgvConsultations.DataSource = _TodayConsultations;
                if (dgvConsultations.Rows.Count > 0)
                {
                    dgvConsultations.Columns["ConsultationID"].HeaderText = "Con.ID";
                    dgvConsultations.Columns["ConsultationID"].Width = 80;
                    dgvConsultations.Columns["AppointmentID"].HeaderText = "App.ID";
                    dgvConsultations.Columns["AppointmentID"].Width = 80;
                    dgvConsultations.Columns["ConsultationDate"].HeaderText = "Date & Time";
                    dgvConsultations.Columns["ConsultationDate"].Width = 200;
                    dgvConsultations.Columns["AdditionalFees"].HeaderText = "Fees";
                    dgvConsultations.Columns["AdditionalFees"].DefaultCellStyle.Format = "$ #,##0.00";
                    dgvConsultations.Columns["AdditionalFees"].Width = 100;
                    dgvConsultations.Columns["PatientName"].HeaderText = "Patient";
                    dgvConsultations.Columns["DoctorName"].HeaderText = "Doctor";
                    dgvConsultations.DefaultCellStyle.ForeColor = Color.Black;
                    dgvConsultations.DefaultCellStyle.SelectionForeColor = Color.Black;

                    try
                    {
                        DateTime Today = DateTime.Today;
                        DateTime Tomorrow = Today.AddDays(1);

                        _TodayConsultations.DefaultView.RowFilter = $"ConsultationDate >= '{Today:yyyy-MM-dd}' And ConsultationDate <'{Tomorrow:yyyy-MM-dd}'";
                    }
                    catch
                    {
                        _TodayConsultations.DefaultView.RowFilter = "";
                    }
                    lblTotalRecordConsultaions.Text = dgvConsultations?.Rows.Count.ToString();
                }

            }
        }
        private void _LoadAppointmentData()
        {
            _AllAppointments = clsAppointments.GetAllAppointments();
            lblTotalAppointments.Text = _AllAppointments?.Rows.Count.ToString();
            lblIncreasedAppointmentsAtLastMonth.Text = $"+ {_AllAppointments?.Compute("COUNT(AppointmentID)", $"CreatedDate >= '{DateTime.Now.Date}'").ToString()} Today";
            if (_AllAppointments != null)
            {
                _TodayAppointments = _AllAppointments.DefaultView.ToTable(false, "AppointmentID", "AppointmentDate", "PatientName", "DoctorName","Status");
                dgvAppointments.DataSource = _TodayAppointments;
                if (dgvAppointments.Rows.Count > 0)
                {
                    dgvAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "hh:mm tt";
                    dgvAppointments.Columns["AppointmentID"].HeaderText = "App.ID";
                    dgvAppointments.Columns["AppointmentID"].Width = 80;
                    dgvAppointments.Columns["AppointmentDate"].HeaderText = "Time";
                    dgvAppointments.Columns["AppointmentDate"].Width = 100;
                    dgvAppointments.Columns["Status"].Width = 120;
                    dgvAppointments.Columns["PatientName"].HeaderText = "Patient";
                    dgvAppointments.Columns["DoctorName"].HeaderText = "Doctor";
                    dgvAppointments.DefaultCellStyle.ForeColor = Color.Black;
                    dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;

                    try
                    {
                        _TodayAppointments.DefaultView.RowFilter = $"AppointmentDate >= '{Today:yyyy-MM-dd}' And AppointmentDate <'{Tomorrow:yyyy-MM-dd}'";
                    }
                    catch
                    {
                        _TodayAppointments.DefaultView.RowFilter = "";
                    }

                }
                lblTotalRecordAppointments.Text = dgvAppointments?.Rows.Count.ToString();

            }
            //Fill Chart
            bool isPending = int.TryParse(_TodayAppointments?.Compute("COUNT(AppointmentID)", $"Status = 'Pending' and AppointmentDate >= '{Today:yyyy-MM-dd}' And AppointmentDate <'{Tomorrow:yyyy-MM-dd}'").ToString(), out int Pending);
            bool isCancelled = int.TryParse(_TodayAppointments?.Compute("COUNT(AppointmentID)", $"Status = 'Cancelled' and AppointmentDate >= '{Today:yyyy-MM-dd}' And AppointmentDate <'{Tomorrow:yyyy-MM-dd}'").ToString(), out int Cancelled);
            bool isCompleted = int.TryParse(_TodayAppointments?.Compute("COUNT(AppointmentID)", $"Status = 'Completed' and AppointmentDate >= '{Today:yyyy-MM-dd}' And AppointmentDate <'{Tomorrow:yyyy-MM-dd}'").ToString(), out int Completed);
            bool isNotAttended = int.TryParse(_TodayAppointments?.Compute("COUNT(AppointmentID)", $"Status = 'Not Attended' and AppointmentDate >= '{Today:yyyy-MM-dd}' And AppointmentDate <'{Tomorrow:yyyy-MM-dd}'").ToString(), out int NotAttended);

            UpdatedashboardStatus(Pending, Completed, Cancelled, NotAttended);
        }
        private void UpdatedashboardStatus(int Pending,int Completed,int Cancelled,int NotAttended)
        {

            int total = Pending + Completed + Cancelled + NotAttended;
            if (total == 0)
            {
                pbCancelled.Value = 0;
                pbPending.Value = 0;
                pbCompleted.Value = 0;
                pbNotAttended.Value = 0;

                lblCompletedCount.Text = "0%";
                lblConcelledCount.Text = "0%";
                lblPendingCount.Text = "0%";
                lblNotAttendedCount.Text = "0%";
                return;
            }
            int PendingPec = (Pending * 100) / total;
            int CompletedPec = (Completed * 100) / total;
            int CancelledPec = (Cancelled * 100) / total;
            int NotAttendedPec = (NotAttended * 100) / total;

            pbCancelled.Value = CancelledPec;
            pbPending.Value = PendingPec;
            pbCompleted.Value = CompletedPec;
            pbNotAttended.Value = NotAttendedPec;

            lblPendingCount.Text = $"{PendingPec}%";
            lblConcelledCount.Text = $"{CancelledPec}%";
            lblCompletedCount.Text = $"{CompletedPec}%";
            lblNotAttendedCount.Text = $"{NotAttendedPec}%";
        }
        private void _LoadAllData()
        {
            btnCurrentUser.Text = clsGlobal.CurrentUser.UserName;

            //Patients
            _LoadPatientsData();
            //Doctors
            _LoadDoctorsData();
            //Appointments
            _LoadAppointmentData();
            //Consultations
            _LoadConsultationsData();
            
        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.Location = new Point(285, 110);
            _LoadAllData();

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

        private void ManagePatients(object sender, EventArgs e)
        {
            frmManagePatients frmDoctors = new frmManagePatients();
            frmDoctors.ShowDialog();
        }
        private void ManageDoctors(object sender, EventArgs e)
        {
            frmManageDoctors frmDoctors = new frmManageDoctors();
            frmDoctors.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm=new frmAddUpdatePatient();
            frm.ShowDialog();
            _LoadAllData();
        }

        private void btnViewAllConsultations_Click(object sender, EventArgs e)
        {
            frmManageConsultations frm = new frmManageConsultations();
            frm.ShowDialog();
        }

        private void btnViewAllAppointments_Click(object sender, EventArgs e)
        {

            frmManageAppointments frm = new frmManageAppointments();
            frm.ShowDialog();
            _LoadAllData();

        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment();
            frm.ShowDialog();
            _LoadAllData();
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _LoadAllData();
        }

        private void btnNewUsers_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsers frm = new frmAddUpdateUsers();
            frm.ShowDialog();
            _LoadAllData();
        }

        private void btnNewDoctors_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor frm = new frmAddUpdateDoctor();
            frm.ShowDialog();
            _LoadAllData();
        }

        private void msAppointments_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            _Appointment = clsAppointments.FindByAppointmentID(AppointmentID);
            if (_Appointment == null)
                return;
            enAppointmentStatus appointmentStatus = _Appointment.AppointmentStatus;
            editToolStripMenuItem1.Enabled = appointmentStatus == enAppointmentStatus.Pending;
            cancelToolStripMenuItem.Enabled = appointmentStatus == enAppointmentStatus.Pending;

            bool IsAvailableDate = _Appointment.AppointmentDate <= DateTime.Now && _Appointment.AppointmentDate.AddMinutes(30) > DateTime.Now;
            attendingAppointmentToolStripMenuItem.Enabled = appointmentStatus == enAppointmentStatus.Pending || appointmentStatus == enAppointmentStatus.Completed && IsAvailableDate;

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment(AppointmentID);
            frm.ShowDialog();
            _LoadAllData();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to cancel this appointment", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            clsAppointments.Cancelled(AppointmentID);
            _LoadAllData();

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);

            frmAppointmentDetails frmAppointmentDetails = new frmAppointmentDetails(AppointmentID);
            frmAppointmentDetails.ShowDialog();
        }

        private void attendingAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            frmAttendingAppointment frmAppointmentDetails = new frmAttendingAppointment(AppointmentID);
            frmAppointmentDetails.ShowDialog();
            _LoadAllData();
        }

        private void consultationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvConsultations.CurrentRow.Cells[1].Value);
            frmConsultationDetails frm = new frmConsultationDetails(AppointmentID);
            frm.ShowDialog();
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
           _LoadAllData();
        }

        private void btnCurrentUserInformation_Click(object sender, EventArgs e)
        {
            msManageCurrentUser_Opening(null, null);
        }
        private void msManageCurrentUser_Opening(object sender, CancelEventArgs e)
        {
            Point p = btnCurrentUser.PointToScreen(new Point(0, 0));
            msManageCurrentUser.Show(p.X, p.Y + msManageCurrentUser.PreferredSize.Height);

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUserDetails frm=new frmUserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void btnCurrentUser_Click(object sender, EventArgs e)
        {
            msManageCurrentUser_Opening(null, null);
        }

        private void btnNewMedicine_Click(object sender, EventArgs e)
        {
            frmMedicines frm = new frmMedicines();
            frm.ShowDialog();
        }
    }
}
