using CMS.Global;
using CMS_Business;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Users
{
    public partial class frmAddUpdateUsers : Form
    {
        private int _PersonID;
        private int _UserID;
        private clsUsers _User;

        private enum enMode { Add=1,Update=2 }
        private enMode Mode=enMode.Add;
        public frmAddUpdateUsers()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }
        public frmAddUpdateUsers(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode=enMode.Update;
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
        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void ctrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID=obj;
            btnSave.Enabled = _PersonID>0;
            if(_PersonID<=0)
            {
                return;
            }
            int? UserID = clsUsers.FindByPersonID(_PersonID)?.UserID;
            if (UserID != null && Mode != enMode.Update)
            {
                btnSave.Enabled = false;
                MessageBox.Show($"This Person already have a user with ID {_User.UserID}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnSave.Enabled = true;
        }

        private void _ResetDefaultData()
        {
            lblCreateDate.Text = DateTime.Now.ToShortDateString();
            lblUserID.Text = "????";
            chkIsActive.Checked = false;
            tbPassword.Text = "";
            tbUserName.Text = "";
            if (Mode == enMode.Update)
            {
                lblTitle.Text = "Update User";
            }
            else
            {
                _User = new clsUsers();
                lblTitle.Text = "Add New User";
            }
        }
        private void _LoadData()
        {
            _User = clsUsers.FindByUserID(_UserID);
            if (_User != null)
            {
                _PersonID = _User.PersonID;
                ctrlPersonInfoWithFilter1.LoadData(_PersonID);
                ctrlPersonInfoWithFilter1.FilterEnable = false;
                lblCreateDate.Text = _User.CreatedDate.ToShortDateString();
                lblUserID.Text = _User.UserID.ToString();
                chkIsActive.Checked = _User.IsActive;
                //tbPassword.Text = _User.Password;
                tbUserName.Text = _User.UserName;
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
        }
        private void frmAddUpdateUsers_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void plDoctor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Are you sure you want to add this user", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.No)
            {
                return;
            }
            _User.UserName = tbUserName.Text.Trim();
            _User.Password = clsHashPassword.ComputeHash(tbPassword.Text.Trim());
            _User.CreatedByUserID = clsGlobal.CurrentUser.CreatedByUserID;
            _User.CreatedDate = DateTime.Now;
            _User.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _User.IsActive=chkIsActive.Checked;
            if (!_User.Save())
            {
                MessageBox.Show($"We couldn't save data", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Mode = enMode.Update;
            lblUserID.Text = _User.UserID.ToString();
            MessageBox.Show($"Data Save Successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblTitle.Text = "Update User";


        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbUserName.Text.Trim()))
            {
                errorProvider1.SetError(tbUserName,"This is Required");
                e.Cancel = true;
            }
            else if(clsUsers.IsUserExists(tbUserName.Text.Trim()))
            {
                if(tbUserName.Text!=_User?.UserName)
                {
                    errorProvider1.SetError(tbUserName, "This already exist");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbUserName, null);
                }
            }
            else
            {
                errorProvider1.SetError(tbUserName, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbPassword, "This is Required");
                e.Cancel = true;
            }
            else if(tbPassword.Text.Length<=6)
            {
                errorProvider1.SetError(tbPassword, "This is week enter a strong password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void btnIsShowPassword_Click(object sender, EventArgs e)
        {
            if(btnIsShowPassword.IconChar==IconChar.Eye)
            {
                btnIsShowPassword.IconChar= IconChar.EyeSlash;
                tbPassword.PasswordChar = '*';

            }
            else
            {
                btnIsShowPassword.IconChar = IconChar.Eye;
                tbPassword.PasswordChar = '\0';
           }
        }
    }
}
