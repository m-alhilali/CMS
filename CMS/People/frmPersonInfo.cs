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
    public partial class frmPersonInfo : Form
    {
        private int _PersonID = -1;
        public frmPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonInfo1.Loadinfo(_PersonID);
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            clsGlobal.ChangeSizeControl(sender);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            clsGlobal.ResetSizeControl(sender);
        }
    }
}
