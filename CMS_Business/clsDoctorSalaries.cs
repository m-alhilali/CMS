using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsDoctorSalaries
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int SalaryID { get; set; }
        public int DoctorID { get; set; }
        public clsDoctors DoctorInfo { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }

        public clsDoctorSalaries()
        {
            DoctorID = -1;
            CreatedByUserID = -1;
            EndDate = null;
            StartDate = DateTime.MinValue;
            Salary = -1;
            CreatedDate = DateTime.MinValue;
            IsActive = false;
            Mode = enMode.Add;

        }
        private clsDoctorSalaries(int DoctorID,int SalaryID, decimal Salary, int CreatedByUserID, DateTime CreatedDate, DateTime StartDate, DateTime? EndDate,bool isActive)
        {
            this.DoctorID = DoctorID;
            this.SalaryID = SalaryID;
            this.Salary = Salary;
            this.CreatedByUserID = CreatedByUserID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.IsActive = IsActive;
            this.CreatedDate = CreatedDate;
            this.DoctorInfo = clsDoctors.FindByDoctorID(DoctorID);
            
            Mode = enMode.Update;

        }
        public static clsDoctorSalaries GetByDoctorID(int DoctorID)
        {
            int SalaryID = -1, CreatedByUserID = -1;
            decimal Salary = 0;
            bool IsActive = false;
            DateTime CreatedDate=DateTime.MinValue;
            DateTime StartDate=DateTime.MinValue;
            DateTime? EndDate=null;
            if(clsDoctorSalariesData.GetByDoctorID(DoctorID,ref SalaryID,ref Salary,ref CreatedByUserID,ref CreatedDate,ref StartDate,ref EndDate,ref IsActive))
            {
                return new clsDoctorSalaries(DoctorID,SalaryID,Salary,CreatedByUserID,CreatedDate,StartDate,EndDate, IsActive);
            }
            return null;
        }
        private bool _AddNewDoctorSalary()
        {
            this.DoctorID = clsDoctorSalariesData.AddNewSalary(this.DoctorID, this.Salary,this.CreatedByUserID, this.CreatedDate,this.StartDate,this.IsActive);
            return (this.DoctorID > 0);
        }
        //private bool _UpdateDoctor()
        //{
        //    return clsDoctorSalariesData.UpdateSalary(this.SalaryID,this.DoctorID, this.Salary, this.CreatedByUserID,this.EndDate);
        //}
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewDoctorSalary())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                //case enMode.Update:
                //    if (_UpdateDoctor())
                //    {
                //        IsSave = true;
                //    }
                //    break;
            }
            return IsSave;
        }

        public static DataTable GetAllPatients()
        {
            return clsDoctorSalariesData.GetAllDoctorSalaries();
        }
        public static DataTable GetDoctorSalariesByDoctorID(int DoctorID)
        {
            return clsDoctorSalariesData.GetDoctorSalariesByDoctorID(DoctorID);
        }
        public static decimal GetSalaryByDoctorID(int DoctorID)
        {
            return clsDoctorSalariesData.GetSalaryByDoctorID(DoctorID);
        }

    }
}
