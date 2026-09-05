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
using CMS.People;

namespace CMS.Controls
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void _OnPersonSelected(int personId)
        {
            Action<int> handler = OnPersonSelected;
            if(handler != null)
            {
                handler(personId);
            }
        }

        public int PersonID
        {
            get {return ctrlPersonInfo1.PersonID; }
        }
        private bool _FilterEnable;
        public bool FilterEnable
        {
            set 
            {
                _FilterEnable=value;
                plFilter.Enabled = _FilterEnable; 
            }
        }
        public clsPerson PersonSelectedInfo
        {
            get {return ctrlPersonInfo1.PersonInfo; }
        }
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                errorProvider1.SetError(tbSearch, "it's empty");
                return;
            }
            else
            {
                errorProvider1.SetError(tbSearch, null);

            }
            FillDataNow();
            FocusText();
        }
        public void LoadData(int PersonID)
        {
            tbSearch.Text= PersonID.ToString();
            FillDataNow();
        }
        private void FillDataNow()
        {
            switch(cbFilter.Text)
            {
                case "Person ID":
                    ctrlPersonInfo1.Loadinfo(Convert.ToInt32(tbSearch.Text));
                    break;
                case "National No":
                    ctrlPersonInfo1.Loadinfo(tbSearch.Text);
                    break;
            }

            if(plFilter.Enabled)
            {
                _OnPersonSelected(ctrlPersonInfo1.PersonID);
            }

        }
        private void DataBack(object sender,int PersonID)
        {
            if (PersonID!=-1)
           { 
                cbFilter.SelectedIndex = 0;
                tbSearch.Text = PersonID.ToString();
                FillDataNow();
           }
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm=new frmAddUpdatePerson();
            frm.DataBack += DataBack;
            frm.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Focus();
        }

        public void FocusText()
        {
            tbSearch.Focus();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            FocusText();
        }
    }
}
