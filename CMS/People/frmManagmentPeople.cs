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

namespace CMS.People
{
    public partial class frmManagmentPeople : Form
    {
        private static DataTable _dtAllPeople;
        private DataTable _dtPeople;
        public frmManagmentPeople()
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


        void _RefereshPeopleData()
        {
            _dtAllPeople = clsPerson.GetPeopleList();
            if (_dtAllPeople != null)
                _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth", "Gender", "Phone", "Nationality", "Address");
            dgvPeople.DataSource = _dtPeople;
            lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
            if(dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns["PersonID"].HeaderText = "Person ID";
                dgvPeople.Columns["PersonID"].Width = 120;
                dgvPeople.Columns["NationalNo"].HeaderText = "National No";
                dgvPeople.Columns["FirstName"].HeaderText = "F.Name";
                dgvPeople.Columns["SecondName"].HeaderText = "S.Name";
                dgvPeople.Columns["ThirdName"].HeaderText = "Th.Name";
                dgvPeople.Columns["LastName"].HeaderText = "L.Name";
                dgvPeople.Columns["DateOfBirth"].HeaderText = "D.O.Birth";
                dgvPeople.Columns["Gender"].Width = 120;
                dgvPeople.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvPeople.RowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }
        private void frmManagmentPeople_Load(object sender, EventArgs e)
        {
            this.Location = new Point(315,150);
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            _RefereshPeopleData();

        }

        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            _RefereshPeopleData();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvPeople.CurrentRow==null)
            {
                return;
            }
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(PersonID);
            frmAddUpdatePerson.ShowDialog();
            _RefereshPeopleData();
        }

        private void ShowPersonInfo(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmPersonInfo frmInfo = new frmPersonInfo(PersonID);
            frmInfo.ShowDialog();
            _RefereshPeopleData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                return;
            }
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            if(MessageBox.Show("Are you sure you want to delete this person ? ","Notes",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.No)
            {
                return;
            }
            if (!clsPerson.Delete(PersonID))
            {
                MessageBox.Show("Deleted Failed the Person has Data conected with him", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Person Deleted Successfully ! ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _RefereshPeopleData();
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
            iconSearch.Visible = cbFilter.Text != "None" && cbFilter.SelectedIndex!=-1;
            tbSearch.Visible = iconSearch.Visible;
            tbSearch.PlaceholderText=tbSearch.Text;
            if(tbSearch.Visible)
            {
                tbSearch.Focus();
            }
            else
            {
                if (_dtPeople != null && _dtPeople.Rows.Count > 0)
                {
                    _dtPeople.DefaultView.RowFilter = "";
                    lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
                }
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Result=cbGenderFilter.Text;
            string Column="Gender";
            if(Result=="All")
            {
                Result = "";
            }
            try
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column,Result);
            }
            catch
            {
                _dtPeople.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text=dgvPeople.Rows.Count.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string Column = cbFilter.Text;
            switch (Column)
            {
                case "Person ID":
                    Column = "PersonID";
                    break;
                case "National No":
                    Column = "NationalNo";
                    break;
                case "First Name":
                    Column = "FirstName";
                    break;
                case "Second Name":
                    Column = "SecondName";
                    break;
                case "Third Name":
                    Column = "ThirdName";
                    break;
                case "Last Name":
                    Column = "LastName";
                    break;
                case "Phone":
                    Column = "Phone";
                    break;
                case "Country":
                    Column = "Nationality";
                    break;
            }
            if(Column=="None"||tbSearch.Text=="")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            try
            {
                if (Column == "PersonID")
                {
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", Column, tbSearch.Text);
                }
                else
                {
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Column, tbSearch.Text);
                }
            }
            catch
            {
                _dtPeople.DefaultView.RowFilter = "";
            }
            lblTotalRecord.Text = dgvPeople.Rows.Count.ToString();
        }
    }
}
