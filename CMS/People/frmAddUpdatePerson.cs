using CMS.Global;
using CMS.Properties;
using CMS_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.People
{
    public partial class frmAddUpdatePerson : Form
    {
        private int _PersonID;
        private clsPerson _Person;
        public enum enMode { Add=1,Update=2}
        private enMode Mode=enMode.Add;

        public delegate void DataBackEvent(object sender, int PersonID);
        public event DataBackEvent DataBack;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode=enMode.Add;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
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
        private void _FillComboBoxWithCountries()
        {
            DataTable dt = clsCountries.GetAllCountriesList();
            if (dt != null)
            {
                
                cbCountries.DataSource = dt;
                cbCountries.DisplayMember = "CountryName";
                cbCountries.ValueMember = "CountryID";
            }
            cbCountries.SelectedIndex = cbCountries.FindString("Yemen");
        }

       
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if(_Person == null)
            {
                MessageBox.Show($"Person with {_PersonID} is not found", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbAddress.Text = _Person.Address;
            tbPhone.Text = _Person.Phone;
            if((int)_Person.Gender==0)
            {
                rMale.Checked = true;
            }
            else
            {
                rFemale.Checked = true;
            }
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);
            tbNationalNo.Text = _Person.NationalNo;
            lblPersonID.Text = _Person.PersonID.ToString();
            if(_Person.ImagePath!="")
            {
                pbImage.ImageLocation = _Person.ImagePath;
            }
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            btnDeleteImage.Visible = (pbImage.ImageLocation!=null);
        }
        private void _ResetDefaultData()
        {
            _FillComboBoxWithCountries();
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            rMale.Checked = true;
            pbImage.Image = rFemale.Checked ? Resources.womanicon : Resources.manicon;

            if (Mode==enMode.Add)
            {
                _Person = new clsPerson();
                lblTitle.Text = "Add New Person";
                btnDeleteImage.Visible = false;
            }
            else
            {
                lblTitle.Text = "Update Person";
            }
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _Person.PersonID);
            this.Close();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            pbImage.ImageLocation = null;
            btnDeleteImage.Visible = false;
            pbImage.Image = rFemale.Checked ? Resources.womanicon : Resources.manicon;

        }

        private void lnklblChangePhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileImagePath = openFileDialog1.FileName;
                pbImage.Load(FileImagePath);
                btnDeleteImage.Visible = true;
            }

        }

        private void ChangeImageByChangeGender(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = rFemale.Checked ? Resources.womanicon : Resources.manicon;
           
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           if(!_HandleImage())
            {
                MessageBox.Show($"There is an erorr when we save Image", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.Address = tbAddress.Text.Trim();
            _Person.Gender = rFemale.Checked?clsPerson.enGender.Female:clsPerson.enGender.Male;
            _Person.DateOfBirth=dtpDateOfBirth.Value;
            _Person.NationalityCountryID=Convert.ToByte(cbCountries.SelectedValue);
            _Person.ImagePath= (pbImage.ImageLocation!=null)? pbImage.ImageLocation.ToString():"";
            if(!_Person.Save())
            {
                MessageBox.Show($"We couldn't save data", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Mode = enMode.Update;
            lblPersonID.Text = _Person.PersonID.ToString();
            MessageBox.Show($"Data Save Successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblTitle.Text = "Update Person";


        }

        private bool _HandleImage()
        {
            if (pbImage.ImageLocation != _Person.ImagePath)
            {
                string ImagePath = pbImage.ImageLocation?.ToString();
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        if (File.Exists(_Person.ImagePath))
                        {
                            File.Delete(_Person.ImagePath);
                        }
                    }
                    catch { }
                }
                if (pbImage.ImageLocation != null)
                {
                    if (!clsUtil.CopyImageToProgectFolder(ref ImagePath))
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    pbImage.Load(ImagePath);
                    return true;
                }
            }

            return true;
        }

        private void ValidatingTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox tb=sender as Guna2TextBox;

            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "This is Required");
            }
            else
            {
                errorProvider1.SetError(tb, null);

            }
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                errorProvider1.SetError(tbNationalNo,"This is Required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);

            }
            if (Mode == enMode.Update && tbNationalNo.Text == _Person.NationalNo)
            {
                errorProvider1.SetError(tbNationalNo, null);
                return;
            }
            if (clsPerson.IsPersonExists(tbNationalNo.Text.Trim()))
            {
                errorProvider1.SetError(tbNationalNo, "This is already exists");
                e.Cancel= true;
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);
                return;
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }
    }
}
