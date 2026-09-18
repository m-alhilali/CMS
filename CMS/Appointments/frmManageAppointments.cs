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
using static CMS_Business.clsAppointments;

namespace CMS.Appointments
{
    public partial class frmManageAppointments : Form
    {
        private DataTable _dtAppointment;
        private clsAppointments _Appointment;
        public frmManageAppointments()
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
        void _RefereshAppointmentsData()
        {
            clsAppointments.CheckIsExpiredAnyAppointment();
            _dtAppointment = clsAppointments.GetAllAppointments();
            dgvAppointments.DataSource = _dtAppointment;
            lblTotalRecord.Text = dgvAppointments.Rows.Count.ToString();
            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns["AppointmentID"].HeaderText = "App.ID";
                dgvAppointments.Columns["AppointmentID"].Width = 120;
                dgvAppointments.Columns["AppointmentTypeFees"].HeaderText = "App.Fees";
                dgvAppointments.Columns["AppointmentTypeFees"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvAppointments.Columns["AppointmentTypeTitle"].HeaderText = "App.Type";
                dgvAppointments.Columns["AppointmentID"].HeaderText = "App.ID";

                dgvAppointments.Columns["AppointmentTypeFees"].DefaultCellStyle.ForeColor = Color.Green;
                dgvAppointments.Columns["AppointmentTypeFees"].DefaultCellStyle.SelectionForeColor = Color.Green;
                dgvAppointments.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvAppointments.RowsDefaultCellStyle.ForeColor = Color.Black;

                
            }
        }


        private void frmManageAppointments_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _RefereshAppointmentsData();

        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);

        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment();
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);

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
                if (_dtAppointment != null && _dtAppointment.Rows.Count > 0)
                {
                    _dtAppointment.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvAppointments.Rows.Count.ToString();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Appointment ID":
                    Column = "AppointmentID";
                    break;
                case "Doctor Name":
                    Column = "DoctorName";
                    break;
                case "Patient Name":
                    Column = "PatientName";
                    break;
                case "Status":
                    Column = "Status";
                    break;

            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtAppointment.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvAppointments.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "AppointmentID")
                {
                    _dtAppointment.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtAppointment.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtAppointment.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvAppointments.Rows.Count.ToString();
        }

        private void btnReferesh_Click(object sender, EventArgs e)
        {
            frmManageAppointments_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
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
            consultationDetailsToolStripMenuItem.Enabled = appointmentStatus == enAppointmentStatus.Completed;

            bool IsAvailableDate = _Appointment.AppointmentDate <= DateTime.Now && _Appointment.AppointmentDate.AddMinutes(30) > DateTime.Now;
            attendingAppointmentToolStripMenuItem.Enabled = appointmentStatus == enAppointmentStatus.Pending || appointmentStatus == enAppointmentStatus.Completed && IsAvailableDate;
        }
        private void AppointmentTyps_Click(object sender, EventArgs e)
        {
            frmAppointmentTypes frm = new frmAppointmentTypes();
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(dgvAppointments.CurrentRow==null)
            {
                return;
            }
            int AppointmentID=Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment(AppointmentID);
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);
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
            frmManageAppointments_Load(null, null);

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
            frmManageAppointments_Load(null, null);
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
            frmManageAppointments_Load(null, null);
        }

        private void consultationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                return;
            }
            int AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            frmConsultationDetails frm = new frmConsultationDetails(AppointmentID);
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);
        }
    }
}
