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

namespace CMS.Doctors
{
    public partial class frmAddUpdateDoctor : Form
    {
        private int _DoctorID;
        private clsDoctors _Doctor;
        public enum enMode { Add = 1, Update = 2 }
        private enMode Mode = enMode.Add;
        public frmAddUpdateDoctor()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }
        public frmAddUpdateDoctor(int DoctorID)
        {
            InitializeComponent();
            _DoctorID=DoctorID;
            Mode = enMode.Update;
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
        private void _FillcbSpecialization()
        {
            DataTable dt=clsSpecialties.GetAllSpecialtiestList();
            if (dt != null)
            {
                try
                {
                    cbSpecialization.DataSource = dt;
                    cbSpecialization.DisplayMember = "SpecialtyName";
                    cbSpecialization.ValueMember = "SpecialtyID";
                }
                catch { }
            }
        }
        private void _ResetDefaultData()
        {
            _FillcbSpecialization();
            lblJoinDate.Text = DateTime.Now.ToString("d");
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            ctrlPersonInfoWithFilter1.FocusText();
            if (Mode == enMode.Add)
            {
                _Doctor = new clsDoctors();
                lblTitle.Text = "Add New Doctor";
                
            }
            else
            {
                lblTitle.Text = "Update Doctor";

            }
            this.Text = lblTitle.Text;

        }
        private void _LoadData()
        {
            _Doctor=clsDoctors.FindByDoctorID(_DoctorID);
            if (_Doctor==null)
            {
                MessageBox.Show("Ops! we could not find a doctor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            ctrlPersonInfoWithFilter1.FilterEnable = false;
            ctrlPersonInfoWithFilter1.LoadData(_Doctor.PersonID);
            btnSave.Enabled = true;

            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            lblJoinDate.Text = _Doctor.CreatedDate.ToString();
            lblPersonID.Text = _Doctor.PersonID.ToString();
            lblUserName.Text = _Doctor.UserInfo.UserName;
            tbSalary.Text = _Doctor.Salary.ToString("N2");
            cbSpecialization.SelectedIndex = cbSpecialization.FindString(_Doctor.SpecialtyInfo.SpecialtyName);
        }
        private void frmAddUpdateDoctor_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
        }


        private void frmAddUpdateDoctor_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FocusText();
        }

        private void ctrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            _DoctorID=obj;
            btnSave.Enabled = false;
            if(ctrlPersonInfoWithFilter1.PersonID==-1)
            {
                lblPersonID.Text = "????";
                return;
            }
            lblPersonID.Text = _DoctorID.ToString();
            int DoctorID = ctrlPersonInfoWithFilter1.PersonSelectedInfo.GetDoctorIDByPersonID();
            if (DoctorID != -1)
            {
                MessageBox.Show($"This person already have a doctor with Doctor ID : {DoctorID}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnSave.Enabled = true;
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                return;
            }
            if(MessageBox.Show("Are you sure you want to Add | Update Doctor?","Add|Update Doctor",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.No)
            {
                return;
            }
            if(Mode==enMode.Update)
            {
                _Doctor.IsActive =_Doctor.IsActive? true:false;
            }
            else
            {
                _Doctor.IsActive =  true;

            }
            _Doctor.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Doctor.CreatedDate = DateTime.Now;
            _Doctor.SpecialtyID =Convert.ToInt32(cbSpecialization.SelectedValue);
            _Doctor.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            if(!_Doctor.Save())
            {
                MessageBox.Show($"Error: Failed Save Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (Mode)
            {
                case enMode.Add:
                    SaveSalary(_Doctor.DoctorID, _Doctor.CreatedByUserID, Convert.ToDecimal(tbSalary.Text));
                    break;
                case enMode.Update:
                    if (_Doctor.Salary != Convert.ToDecimal(tbSalary.Text))
                    {
                        SaveSalary(_Doctor.DoctorID, _Doctor.CreatedByUserID, Convert.ToDecimal(tbSalary.Text));
                    }
                    break;
            }
            

            btnSave.Enabled=false;
            _DoctorID = _Doctor.DoctorID;
            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            MessageBox.Show($"Data Saved Successfully the Doctor ID = {_DoctorID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private bool SaveSalary(int DoctorID, int CreatedByUserID, decimal Salary)
        {
            clsDoctorSalaries salaries = new clsDoctorSalaries();
            salaries.StartDate = DateTime.Now;
            salaries.CreatedDate = DateTime.Now;
            salaries.CreatedByUserID = CreatedByUserID;
            salaries.DoctorID = DoctorID;
            salaries.Salary = Salary;
            return salaries.Save();
        }
        private void cbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbSpecialization_Validating(object sender, CancelEventArgs e)
        {
            int SpecialtyID = Convert.ToInt32(cbSpecialization.SelectedValue);
            if (!clsSpecialties.IsSpecialitiesActive(SpecialtyID))
            {
                errorProvider1.SetError(cbSpecialization, "Choice a Specializtion");
                e.Cancel=true;
            }
            else
            {
                errorProvider1.SetError(cbSpecialization, null);
            }
        }

        private void tbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }

        private void tbSalary_Validating(object sender, CancelEventArgs e)
        {
            if(tbSalary.Text.Trim()=="")
            {
                errorProvider1.SetError(tbSalary,"Type Salary");
                e.Cancel=true;
                return;
            }
            else
            {
                errorProvider1.SetError(tbSalary, null);
            }
        }
    }
}
