using CMS.People;
using CMS.Properties;
using CMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CMS.Controls
{
    public partial class ctrlPersonInfo : UserControl
    {
        private clsPerson _Person;
        private int _PersonID=-1;
        public clsPerson PersonInfo
        {
            get { return _Person; }
        }
        public int PersonID
        {
            get { return _PersonID; }
        }
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        private void SetImage()
        {
            if(_Person.ImagePath!="")
            {
                string FilePath = _Person.ImagePath;
                if (File.Exists(FilePath))
                {
                    pbImage.Load(FilePath);
                    return;
                }
               
                MessageBox.Show($"Failed Load Image maybe is not exists", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }
            return;
        }
        private void FillData()
        {
            if(_Person.Gender == clsPerson.enGender.Male)
            {
                pbImage.Image = Resources.manicon;
            }
            else
            {
                pbImage.Image = Resources.womanicon;

            }
            SetImage();
            lblName.Text = _Person.FullName;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("d");
            lblGender.Text = _Person.Gender==clsPerson.enGender.Male?"Male":"Female";
            lblNationalNo.Text = _Person.NationalNo;
            lblPhone.Text = _Person.Phone;
            lblPersonID.Text = _Person.PersonID.ToString();
            lnklblEditPerson.Enabled = _Person != null;
        }
        public void Loadinfo(int PersonID)
        {
            _Person=clsPerson.Find(PersonID);
            if(_Person==null)
            {
                ResetInfo();
                MessageBox.Show($"There is no Person with ID {PersonID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PersonID=PersonID;
            FillData();

        }
        public void Loadinfo(string NationalNo)
        {
            _Person=clsPerson.Find(NationalNo);
            lnklblEditPerson.Enabled = _Person != null;
            if(_Person==null)
            {
                ResetInfo();
                MessageBox.Show($"There is no Person with National No {NationalNo}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PersonID=_Person.PersonID;
            FillData();

        }
        public void ResetInfo()
        {
            _PersonID = -1;
            lblAddress.Text = "????";
            lblPersonID.Text = "????";
            lblPhone.Text = "????";
            lblNationalNo.Text = "????";
            lblName.Text = "????";
            lblDateOfBirth.Text = "????";
            lblCountry.Text = "????";
            lblGender.Text = "????";
            pbImage.Image = Resources.manicon;
            lnklblEditPerson.Enabled = _PersonID != -1;
        }

        private void lnklblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_Person!=null)
            {
                frmAddUpdatePerson frm=new frmAddUpdatePerson(_Person.PersonID);
                frm.ShowDialog();
                Loadinfo(_Person.PersonID);
            }
        }

        private void ctrlPersonInfo_Load(object sender, EventArgs e)
        {
        }
    }
}
