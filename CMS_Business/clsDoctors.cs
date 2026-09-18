using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsDoctors
    {
        public enum enMode { Add=1,Update=2}
        public enMode Mode= enMode.Add;
        public int DoctorID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int SpecialtyID { get; set; }
        public clsSpecialties SpecialtyInfo { get; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public decimal Salary { get
            {
                return GetSalaryByDoctorID();
            }
        }
        public clsUsers UserInfo { get; set; }

        public bool IsActive { get; set; }

        public clsDoctors()
        {
            DoctorID = -1;
            CreatedByUserID = -1;
            SpecialtyID = -1;
            PersonID = -1;
            IsActive = false;
            CreatedDate = DateTime.MinValue;
            Mode = enMode.Add;

        }
        private clsDoctors(int DoctorID, int PersonID,int SpecialtyID, DateTime createdDate, int CreatedByUserID,bool IsActive)
        {
            this.DoctorID = DoctorID;
            this.CreatedByUserID = CreatedByUserID;
            this.SpecialtyID = SpecialtyID;
            this.PersonID = PersonID;
            this.IsActive = IsActive;
            this.CreatedDate = createdDate;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserInfo = clsUsers.FindByUserID(this.CreatedByUserID);
            this.SpecialtyInfo = clsSpecialties.Find(this.SpecialtyID);
            Mode = enMode.Update;

        }

        public static clsDoctors FindByPersonID(int PersonID)
        {
            int DoctorID = -1, SpecialtyID = -1, CreatedByUserID = -1;
            bool IsActive = false;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsDoctorsData.GetByPersonID(PersonID, ref DoctorID,ref IsActive,  ref SpecialtyID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDoctors(DoctorID, PersonID, SpecialtyID, CreatedDate, CreatedByUserID, IsActive);
            }
            return null;
        }
        public static clsDoctors FindByDoctorID(int DoctorID)
        {
            int  PersonID= -1, SpecialtyID = -1, CreatedByUserID = -1;
            bool IsActive = false;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsDoctorsData.GetByDoctorID(DoctorID, ref PersonID, ref IsActive, ref SpecialtyID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDoctors(DoctorID, PersonID, SpecialtyID, CreatedDate, CreatedByUserID, IsActive);
            }
            return null;
        }

        private decimal GetSalaryByDoctorID()
        {
            return (clsDoctorSalaries.GetSalaryByDoctorID(this.DoctorID));
        }
        private bool _AddNewDoctor()
        {
            this.DoctorID = clsDoctorsData.AddNewDoctors(this.PersonID, this.IsActive,this.SpecialtyID, this.CreatedByUserID, this.CreatedDate);
            return (this.DoctorID > 0);
        }
        private bool _UpdateDoctor()
        {
            return clsDoctorsData.UpdateDoctor(this.DoctorID,this.PersonID, this.IsActive, this.SpecialtyID);
        }
       
        public bool Save()
        {
           
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewDoctor())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateDoctor())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public bool IsDoctorExists(int DoctorID)
        {
            return clsDoctorsData.IsDoctorExists(DoctorID);
        }
        public static bool InActive(int DoctorID)
        {
            return clsDoctorsData.UpdateStatus(DoctorID,false);
        }
        public static bool Active(int DoctorID)
        {
            return clsDoctorsData.UpdateStatus(DoctorID,true);
        }
        public bool InActive()
        {
            return clsDoctorsData.UpdateStatus(this.DoctorID,false);
        }
        public bool Active()
        {
            return clsDoctorsData.UpdateStatus(this.DoctorID,true);
        }
        public int GetDoctorIDByPersonID()
        {
            return clsDoctorsData.GetDoctorIDByPersonID(this.PersonID);
        }
        public static int GetDoctorIDByPersonID(int PersonID)
        {
            return clsDoctorsData.GetDoctorIDByPersonID(PersonID);
        }


        public static DataTable GetAllDoctorsList()
        {
            return clsDoctorsData.GetAllDoctorsList();
        }
      
        
    }
}
