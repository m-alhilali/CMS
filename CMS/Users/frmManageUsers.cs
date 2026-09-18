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
    public partial class frmManageUsers : Form
    {
        private static DataTable _dtAllUsers;

        public frmManageUsers()
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

        void _RefereshUsersData()
        {
            _dtAllUsers = clsUsers.GetAllUserList();
            dgvUsers.DataSource = _dtAllUsers;
            lblTotalRecord.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns["UserID"].HeaderText = "User ID";
                dgvUsers.Columns["UserID"].Width = 120;
                dgvUsers.Columns["FullName"].HeaderText = "Full Name";
                dgvUsers.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvUsers.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }
        private void femManageUsers_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315, 150);
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshUsersData();
        }
        private void _MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }
        private void _MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            iconSearch.Visible = cbFilter.Text != "None" && cbFilter.SelectedIndex != -1;
            tbSearch.Visible = iconSearch.Visible;
            tbSearch.PlaceholderText = tbSearch.Text;
            if (tbSearch.Visible)
            {
                tbSearch.Focus();
            }
            else
            {
                if (_dtAllUsers != null && _dtAllUsers.Rows.Count > 0)
                {
                    _dtAllUsers.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvUsers.Rows.Count.ToString();
                }
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result = cbGenderFilter.Text;
            string Column = "Gender";
            if (Result == "All")
            {
                Result = "";
            }
            try
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, Result);
            }
            catch
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvUsers.Rows.Count.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "User ID":
                    Column = "UserID";
                    break;
                case "Full Name":
                    Column = "FullName";
                    break;
                case "User Name":
                    Column = "UserName";
                    break;
            }
            if (Column == "None" || tbSearch.Text == "")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "UserID")
                {
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvUsers.Rows.Count.ToString();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsers frm = new frmAddUpdateUsers();
            frm.ShowDialog();
            _RefereshUsersData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvUsers.CurrentRow==null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            frmAddUpdateUsers frm=new frmAddUpdateUsers(UserID);
            frm.ShowDialog();
            _RefereshUsersData();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            frmChangeUserPassword frm = new frmChangeUserPassword(UserID);
            frm.ShowDialog();
            _RefereshUsersData();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            frmUserDetails frm = new frmUserDetails(UserID);
            frm.ShowDialog();
            _RefereshUsersData();
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            clsUsers.Active(UserID);
            _RefereshUsersData();

        }

        private void deactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            clsUsers.DeActive(UserID);
            _RefereshUsersData();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            clsUsers User = clsUsers.FindByUserID(UserID);
            activeToolStripMenuItem.Enabled = !User.IsActive;
            deactiveToolStripMenuItem.Enabled = User.IsActive;
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(null,null);
        }
    }
}
