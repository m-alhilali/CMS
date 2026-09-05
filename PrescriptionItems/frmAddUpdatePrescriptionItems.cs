using CMS.Appointments;
using CMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CMS_Business.clsAppointments;

namespace CMS.PrescriptionItems
{
    public partial class frmAddUpdatePrescriptionItems : Form
    {
        private object[] Dayduration = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        private object[] WeeksAndMonthsduration = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private int _ConsulationID = -1;
        private clsPrescriptionItems _PrescriptionItem;
        private clsConsultations _Consulations;
        private DataTable _dtPrescription;
        private enum enMode { Add = 1, Update = 2 }
        private enMode Mode = enMode.Add;
        public frmAddUpdatePrescriptionItems(int Consulation)
        {
            InitializeComponent();
            _ConsulationID = Consulation;
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

        private void _LoadPrescriptionData()
        {
            if (_PrescriptionItem == null)
                return;
            tbFees.Text = _PrescriptionItem.PaidFees.ToString("N2");
            tbDosage.Text = _PrescriptionItem.Dosage;
            cbMedicine.SelectedIndex = cbMedicine.FindString(_PrescriptionItem.MedicinesInfo.MedicineName);
            tbSpecialInstructions.Text = _PrescriptionItem.SpecialInstructions;
            cbDuration.SelectedIndex = cbDuration.FindString(_PrescriptionItem.Duration?.ToString());
            lblPrescriptionID.Text = _PrescriptionItem.PrescriptionItemID.ToString();
        }
        private void _LoadConsultationInformation()
        {
            lblConsultationDate.Text = _Consulations.ConsultationDate.ToString("MMMM d,yyyy");
            lblConsultationTime.Text = _Consulations.ConsultationDate.Date.ToShortTimeString();
            lblDoctorName.Text = _Consulations.AppointmentsInfo.DoctorInfo.PersonInfo.FullName;
            lblPatientName1.Text = _Consulations.AppointmentsInfo.PatientInfo.PersonInfo.FullName;
            lblConsultationID.Text = _Consulations.ConsultationID.ToString();

        }
        private void _LoadPrescriptionItemsList()
        {
            _dtPrescription = clsPrescriptionItems.GetAllPrescriptionItemsByConsultationID(_ConsulationID);
            dgvPrescription.DataSource= _dtPrescription;
            lblTotalRecord.Text = dgvPrescription.Rows.Count.ToString();
            if (dgvPrescription.Rows.Count>0)
            {
                dgvPrescription.Columns["PrescriptionItemID"].HeaderText = "Pre.ItemID";
                dgvPrescription.Columns["PrescriptionItemID"].Width = 120;
                dgvPrescription.Columns["ConsultationID"].HeaderText = "Con.ID";
                dgvPrescription.Columns["ConsultationID"].Width = 100;
                dgvPrescription.Columns["Duration"].Width = 100;

            }
        }
        private void _LoadMedicinedata()
        {
            DataTable dt = clsMedicines.GetAllMedicinesList();
            if (dt != null)
            {
                cbMedicine.DataSource=dt;
                cbMedicine.DisplayMember = "MedicineName";
                cbMedicine.ValueMember = "MedicineID";
                cbMedicine_SelectedIndexChanged(null, null);
            }
        }
        private void _ResetData()
        {

           lblTitle.Text = "Add Prescription Item";
           _PrescriptionItem = new clsPrescriptionItems();
            tbDosage.Text = null;
            tbSpecialInstructions.Text = null;
            lblPrescriptionID.Text = "N/A";
           _LoadConsultationInformation();
           _LoadMedicinedata();
           _LoadPrescriptionItemsList();

        }
        private void frmAddUpdatePrescriptionItems_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            _Consulations = clsConsultations.FindByConsultationID(_ConsulationID);
            if (_Consulations == null)
            {
                MessageBox.Show($"Failed: There is no Consultation with ID {_ConsulationID} !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _ResetData();

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

        private void ChangeDuration_Click(object sender, EventArgs e)
        {
            cbDuration.Items.Clear();
            if (rbtnNone.Checked)
            {
                cbDuration.SelectedIndex = -1;
                return;
            }
            if (rbtnDays.Checked)
            {
                cbDuration.Items.AddRange(Dayduration);
                cbDuration.SelectedIndex = 0;
            }
            else 
            {
                cbDuration.Items.AddRange(WeeksAndMonthsduration);
                cbDuration.SelectedIndex = 0;

            }


        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar)&& ! char.IsControl(e.KeyChar);
        }

        private void cbMedicine_Validating(object sender, CancelEventArgs e)
        {
            if(cbMedicine.SelectedIndex==-1)
            {
                errorProvider1.SetError(cbMedicine, "This Field is Required");
                e.Cancel = true;
            }
            int MedicineID;
            if (!int.TryParse(cbMedicine.SelectedValue?.ToString(), out MedicineID))
            {
                return;
            }
            bool IsActive = clsMedicines.Find(MedicineID).IsActive;
            if (!IsActive)
            {
                errorProvider1.SetError(cbMedicine, "Sorry this medicine finished!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbMedicine, null);

            }
        }

        private void cbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedicine.SelectedIndex == -1) {
                return;
            }
            int MedicineID;
            if(!int.TryParse(cbMedicine.SelectedValue?.ToString(),out MedicineID))
            {
                return;
            }
            decimal MedicineFees = clsMedicines.Find(MedicineID).MedicineFees;
            tbFees.Text = MedicineFees.ToString("N2");
            

        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to add | update this Prescription", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            if (cbDuration.SelectedIndex == -1)
                _PrescriptionItem.Duration = null;
            else
                _PrescriptionItem.Duration =Convert.ToByte(cbDuration.Text);

            _PrescriptionItem.ConsultationID = _ConsulationID;
            _PrescriptionItem.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _PrescriptionItem.CreatedDate=DateTime.Now;
            _PrescriptionItem.Dosage = tbDosage.Text.Trim();
            _PrescriptionItem.SpecialInstructions = tbSpecialInstructions.Text.Trim();
            _PrescriptionItem.PaidFees = Convert.ToDecimal(tbFees.Text);
            _PrescriptionItem.MedicineID = Convert.ToInt32(cbMedicine.SelectedValue);
            _PrescriptionItem.DurationUnit = !string.IsNullOrEmpty(_PrescriptionItem.Dosage)? (rbtnDays.Checked ? "Day(s)" : rbtnWeeks.Checked ? "Week(s)" : rbtnMonths.Checked ? "Month(s)" : null):null ;

            if(!_PrescriptionItem.Save())
            {
                MessageBox.Show("Failed: Data didn't save successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblPrescriptionID.Text = _PrescriptionItem.PrescriptionItemID.ToString();
            _ResetData();
            MessageBox.Show("Data saved successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void deactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrescription.CurrentRow == null)
            {
                return;
            }
            int PrescriptionID = Convert.ToInt32(dgvPrescription.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("If you Deactivate this Prescription you cann't Activate again ", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            clsPrescriptionItems.Deactive(PrescriptionID);
            _ResetData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrescription.CurrentRow == null)
            {
                return;
            }
            int PrescriptionID = Convert.ToInt32(dgvPrescription.CurrentRow.Cells[0].Value);
           _PrescriptionItem=clsPrescriptionItems.FindByPrescriptionItemID(PrescriptionID); 
            if (_PrescriptionItem == null)
            {
                return;
            }
            if (_PrescriptionItem.IsActive)
            {
                lblTitle.Text = "Update Prescription Item";
                _LoadPrescriptionData();
            }
           

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPrescription.CurrentRow == null)
            {
                return;
            }
            int PrescriptionID = Convert.ToInt32(dgvPrescription.CurrentRow.Cells[0].Value);
            _PrescriptionItem = clsPrescriptionItems.FindByPrescriptionItemID(PrescriptionID);
            if (_PrescriptionItem == null)
            {
                return;
            }
            deactiveToolStripMenuItem.Enabled = _PrescriptionItem.IsActive;
            updateToolStripMenuItem.Enabled= _PrescriptionItem.IsActive;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbIsActive.Text;
            string Column = "IsActive";
            if (Result == "All")
            {
                _dtPrescription.DefaultView.RowFilter = "";
                lblTotalRecord.Text = _dtPrescription.Rows.Count.ToString();
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
                _dtPrescription.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, Result);
            }
            catch
            {
                _dtPrescription.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPrescription.Rows.Count.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _ResetData();
        }
    }
}
