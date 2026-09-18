using CMS_Business;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class frmUserDetails : Form
    {
        private int _UserID = -1;
        private clsUsers _User;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID=UserID;
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
        private void _LoadData()
        {
            lblUserID.Text = _User.UserID.ToString();
            ctrlPersonInfoWithFilter1.FilterEnable = false;
            ctrlPersonInfoWithFilter1.LoadData(_User.PersonID);
            lblActive.Text = _User.IsActive ? "Active" : "InActive";
            lblActive.ForeColor = _User.IsActive ? Color.Green: Color.Red;
            lblUserName.Text = _User.UserName;
            lblCreateDate.Text = _User.CreatedDate.ToShortDateString();
        }
        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            _User = clsUsers.FindByUserID(this._UserID);
            if (_User == null)
            {
                MessageBox.Show($"Error: we could not find the user with ID [{_User}]", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblUserID.Text = _User.UserID.ToString();
            ctrlPersonInfoWithFilter1.FilterEnable = false;
            ctrlPersonInfoWithFilter1.LoadData(_User.PersonID);
            _LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

    }
}
