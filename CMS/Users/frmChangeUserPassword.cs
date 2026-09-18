using CMS.Global;
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

namespace CMS.Users
{
    public partial class frmChangeUserPassword : Form
    {
        private int _UserID=-1;
        private clsUsers _User;
        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            _User=clsUsers.FindByUserID(this._UserID);
            if (_User == null)
            {
                MessageBox.Show($"Error: we could not find the user with ID [{_User}]","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblUserID.Text = _User.UserID.ToString();
            ctrlPersonInfoWithFilter1.FilterEnable=false;
            ctrlPersonInfoWithFilter1.LoadData(_User.PersonID);
            
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbCurrentPassword, "This Field is required");
                e.Cancel = true;
                return;
            }
            if(_User.Password!=clsHashPassword.ComputeHash(tbCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbCurrentPassword, "Wrong Password!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, null);
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbNewPassword, "This Field is required");
                e.Cancel = true;
                return;
            }
            if (tbNewPassword.Text.Trim().Length<6)
            {
                errorProvider1.SetError(tbNewPassword, "Week Password enter a strong password!");
                e.Cancel = true;
                return;
            }
            if(tbNewPassword.Text.Trim()==_User.Password)
            {
                errorProvider1.SetError(tbNewPassword, "you cann't change like a current password!,enter another password!");
                e.Cancel= true;
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, null);
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfirmPassword.Text.Trim() != tbNewPassword.Text.Trim())
            {
                errorProvider1.SetError(tbConfirmPassword, "Wrong Password enter the same new password!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show($"Error: there is an error where the small red icon, click on the circle red icon to show the error", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.Password = tbNewPassword.Text.Trim();
            if(!_User.Save())
            {
                MessageBox.Show($"Error: Failed save data", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"Successfully: done save data", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmChangeUserPassword_Activated(object sender, EventArgs e)
        {
            tbCurrentPassword.Focus();
        }
    }
}
