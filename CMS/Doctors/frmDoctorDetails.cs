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
    public partial class frmDoctorDetails : Form
    {
        private int _DoctorID=-1;
        //private int _PersonID=-1;
        private clsDoctors _Doctor;
        public frmDoctorDetails(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
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
        private void RefereshData()
        {
            ctrlPersonInfo1.Loadinfo(_Doctor.PersonID);
            ctrlDoctorSalariesList1.LoadData(_DoctorID);
            if(ctrlPersonInfo1.PersonID<=0)
            {
                return;
            }
            lblCurrentSalary.Text = "$"+_Doctor.Salary.ToString("N2");
            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            lblJoinDate.Text=_Doctor.CreatedDate.ToString("d");
            lblSpecialization.Text = _Doctor.SpecialtyInfo.SpecialtyName;
            lblIsActive.Text = _Doctor.IsActive?"Yes":"No";
            lblIsActive.ForeColor = _Doctor.IsActive ? Color.Green:Color.Red;

        }
        private void frmDoctorDetails_Load(object sender, EventArgs e)
        {
            _Doctor = clsDoctors.FindByDoctorID(_DoctorID);
            if (_Doctor != null)
            {
                RefereshData();
            }
            else
            {
                btnUpdate.Enabled = false;
                btnNewSalary.Enabled = false;
                MessageBox.Show($"Ops! The Doctor with ID {_DoctorID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void plDoctor_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor frm= new frmAddUpdateDoctor(_DoctorID);
            frm.ShowDialog();
            frmDoctorDetails_Load(null, null);
        }
    }
}
