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
    public partial class frmAddUpdatePatient : Form
    {
        private int _PatientID=-1;
        private int _PersonID=-1;
        private clsPatients _Patient;
        public delegate void DataBackPatientID(object sender, int PatientID);
        public event DataBackPatientID DataBack;
        public enum enMode { Add = 1, Update = 2 }
        private enMode Mode = enMode.Add;
        public frmAddUpdatePatient()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }
        public frmAddUpdatePatient(int PatientID)
        {
            InitializeComponent();
            Mode=enMode.Update;
            _PatientID=PatientID;
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
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _ResetDefaultData()
        {
            ctrlPersonInfoWithFilter1.FocusText();
            lblCreateDate.Text = DateTime.Now.ToString("d");
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            if (Mode == enMode.Add)
            {
                _Patient = new clsPatients();
                lblTitle.Text= "Add New Patient";
                btnSave.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update Patient";
                btnSave.Enabled = true;

            }
            this.Text=lblTitle.Text;

        }
        private void _LoadData()
        {
            _Patient = clsPatients.FindByPatientID(_PatientID);
            if (_Patient == null)
            {
                MessageBox.Show("Ops! we could not find a Patient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonInfoWithFilter1.FilterEnable = false;
            ctrlPersonInfoWithFilter1.LoadData(_Patient.PersonID);
            btnSave.Enabled = true;

            lblPatientID.Text = _Patient.PatientID.ToString();
            lblCreateDate.Text = _Patient.CreatedDate.ToString();
            lblUserName.Text = _Patient.UserInfo.UserName;
            cbBloodType.SelectedIndex = cbBloodType.FindString(_Patient.BloodType);
        }
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void frmAddUpdatePatient_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void frmAddUpdatePatient_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FocusText();

        }

        private void ctrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            btnSave.Enabled = false;
            if (ctrlPersonInfoWithFilter1.PersonID == -1)
            {
                return;
            }
            int PatientID = ctrlPersonInfoWithFilter1.PersonSelectedInfo.GetPatientIDByPersonID();
            if (PatientID != -1)
            {
                MessageBox.Show($"This person already have a Patient with Patient ID : {PatientID}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to added", "Notis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            _Patient.BloodType = cbBloodType.Text;
            _Patient.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Patient.CreatedDate=DateTime.Now;
            _Patient.IsActive = false;
            _Patient.PersonID=ctrlPersonInfoWithFilter1.PersonID;
            if(!_Patient.Save())
            {
                MessageBox.Show("Error : Failed Save Patient!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblPatientID.Text = _Patient.PatientID.ToString();
            _PatientID=_Patient.PatientID;
            MessageBox.Show($"Data Saved Successfully the Patient ID = {_PatientID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            Mode = enMode.Update;
        }

        private void cbSpecialization_Validating(object sender, CancelEventArgs e)
        {
            if(cbBloodType.SelectedIndex==-1)
            {
                errorProvider1.SetError(cbBloodType, "Choise a type of blood");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbBloodType, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _PatientID);
            this.Close();
        }
    }
}
