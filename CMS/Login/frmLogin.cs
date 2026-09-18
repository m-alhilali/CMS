using CMS.Global;
using CMS_Business;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            clsUsers User = clsUsers.FindByUserNameAndPassword(tbUserName.Text.Trim(),clsHashPassword.ComputeHash(tbPassword.Text.Trim()));
            if (User == null)
            {
                MessageBox.Show("User dose not exists!","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (chkbxRememberme.Checked)
            {
                if (!clsGlobal.RememberMeToLoginAgain(tbUserName.Text.Trim(), tbPassword.Text.Trim()))
                {
                    MessageBox.Show("Failed Save data to remember you again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else clsGlobal.RememberMeToLoginAgain("", "");


            clsGlobal.CurrentUser = User;
            frmMain frm = new frmMain();
            frm.ShowDialog();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";
            if (clsGlobal.GetInfoToLoginAgain(ref UserName, ref Password))
            {
                tbPassword.Text = Password;
                tbUserName.Text = UserName;
                chkbxRememberme.Checked = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            if(iconShowPassword.IconChar==IconChar.Eye)
            {
                tbPassword.PasswordChar = '*';
                iconShowPassword.IconChar = IconChar.EyeSlash;
            }
            else
            {
                tbPassword.PasswordChar = '\0';
                iconShowPassword.IconChar = IconChar.Eye;


            }
        }

        private void chkbxRememberme_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
