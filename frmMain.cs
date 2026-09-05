using CMS.Appointments;
using CMS.Consultations;
using CMS.DashBoard;
using CMS.Doctors;
using CMS.Medicines;
using CMS.Patients;
using CMS.People;
using CMS.PrescriptionItems;
using CMS.Specialties;
using CMS.Users;
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

namespace CMS
{
    public partial class frmMain : Form
    {
        public frmMain()
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
        private void Form1_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text=clsGlobal.CurrentUser.UserName;

           // btndashboard.PerformClick();

        }


        private void GoToManagePeopleScreen()
        {
            frmManagmentPeople frmManagmentPeople = new frmManagmentPeople();
            frmManagmentPeople.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManagePrescriptionScreen()
        {
            frmManagePrescriptionItems frmManagmentItems = new frmManagePrescriptionItems();
            frmManagmentItems.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageDoctorsScreen()
        {
            frmManageDoctors frmDoctors = new frmManageDoctors();
            frmDoctors.ShowDialog();
            btndashboard.PerformClick();

        }
        private void GoToManagePatientScreen()
        {
            frmManagePatients frmDoctors = new frmManagePatients();
            frmDoctors.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageMedicinesScreen()
        {
            frmMedicines frmMedicine = new frmMedicines();
            frmMedicine.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageAppointmentScreen()
        {
            frmManageAppointments frm = new frmManageAppointments();
            frm.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageAppointmentTypesScreen()
        {
            frmAppointmentTypes frm = new frmAppointmentTypes();
            frm.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageUsersScreen()
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageConsultationScreen()
        {
            frmManageConsultations frm = new frmManageConsultations();
            frm.ShowDialog();
            btndashboard.PerformClick();
        }
        private void GoToManageSpecialtiesScreen()
        {
            frmSpecialties frm = new frmSpecialties();
            frm.ShowDialog();
            btndashboard.PerformClick();
        }
        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            GoToManagePeopleScreen();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            GoToManageDoctorsScreen();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            GoToManagePatientScreen();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            GoToManageAppointmentScreen();

        }

        private void AppointmentTypes_Click(object sender, EventArgs e)
        {
            GoToManageAppointmentTypesScreen();

        }

        private void btnConsultations_Click(object sender, EventArgs e)
        {
            GoToManageConsultationScreen();

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;

            clsAppointments.CheckIsExpiredAnyAppointment();
            frmDashboard frm =new frmDashboard();
            frm.ShowDialog();
            btnEmpty.PerformClick();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            GoToManagePrescriptionScreen();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            GoToManageMedicinesScreen();
        }

        private void btnSpecialties_Click(object sender, EventArgs e)
        {
            GoToManageSpecialtiesScreen();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            GoToManageUsersScreen();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm=new frmChangeUserPassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
            clsGlobal.CurrentUser = clsUsers.FindByUserID(clsGlobal.CurrentUser.UserID);
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser=null;
            this.Close();
        }

        private void btnCurrentUserInformation_Click(object sender, EventArgs e)
        {
            msManageCurrentUser_Opening(null, null);
        }

        private void msManageCurrentUser_Opening(object sender, CancelEventArgs e)
        {
            Point p = lblCurrentUser.PointToScreen(new Point(0, 0));
            msManageCurrentUser.Show(p.X, p.Y - msManageCurrentUser.PreferredSize.Height);

        }
    }
}
