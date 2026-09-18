using CMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Contols
{
    public partial class ctrlDoctorSalariesList : UserControl
    {
        private clsDoctors _DoctorInfo;
        private DataTable _dtDoctorISalaries;
        private int _DoctorID;
        public clsDoctors DoctorInfo
        {
            get { return _DoctorInfo; }
        }
        public int DoctorID
        {
            get { return _DoctorID; }
        }
        public ctrlDoctorSalariesList()
        {
            InitializeComponent();
        }

        private void FillData()
        {
            _dtDoctorISalaries = clsDoctorSalaries.GetDoctorSalariesByDoctorID(_DoctorID);
            dgvSalaries.DataSource = _dtDoctorISalaries;
            if (dgvSalaries.Rows.Count > 0)
            {
                dgvSalaries.Columns[0].Width = 120;
                dgvSalaries.Columns[1].Width = 150;
                dgvSalaries.Columns[2].Width = 150;
                dgvSalaries.Columns[3].Width = 150;
                dgvSalaries.Columns[4].Width = 150;
            }
            lblTotalRecord.Text="Record : "+dgvSalaries.Rows.Count.ToString();

        }
        public void LoadData(int DoctorID)
        {
            _DoctorInfo = clsDoctors.FindByDoctorID(DoctorID);
            if (_DoctorInfo == null)
            {
                MessageBox.Show($"Ops! The Doctor with ID {DoctorID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DoctorID = DoctorID;
            FillData();
        }
    }
}
