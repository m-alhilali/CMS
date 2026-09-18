using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsPatients
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;

        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string BloodType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers UserInfo { get; set; }
        public bool IsActive { get; set; }

        public clsPatients()
        {
            PatientID = -1;
            CreatedByUserID = -1;
            PersonID = -1;
            BloodType = string.Empty;
            CreatedDate = DateTime.MinValue;
            IsActive = false;
            Mode = enMode.Add;

        }
        private clsPatients(int PatientID, int personID, string BloodType, DateTime createdDate, int CreatedByUserID,bool IsActive)
        {
            this.PatientID = PatientID;
            this.PersonID = personID;
            this.BloodType = BloodType;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = createdDate;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserInfo = clsUsers.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;

        }

        public static clsPatients FindByPersonID(int PersonID)
        {
            string BloodType = "";
            DateTime CreatedDate = DateTime.MinValue;
            int PatientID = -1, CreatedByUserID=-1;
            bool IsActive=false;
            if (clsPatientsData.GetByPersonID(PersonID, ref PatientID, ref BloodType, ref CreatedByUserID, ref CreatedDate,ref IsActive))
            {
                return new clsPatients(PatientID, PersonID, BloodType, CreatedDate, CreatedByUserID, IsActive);
            }
            return null;
        }
        public static clsPatients FindByPatientID(int PatientID)
        {
            string BloodType = "";
            DateTime CreatedDate = DateTime.MinValue;
            bool IsActive = false;
            int PersonID = -1, CreatedByUserID = -1;
            if (clsPatientsData.GetByPatientID(PatientID, ref PersonID, ref BloodType, ref CreatedByUserID, ref CreatedDate,ref IsActive))
            {
                return new clsPatients(PatientID, PersonID, BloodType, CreatedDate, CreatedByUserID, IsActive);
            }
            return null;
        }

        private bool _AddNewPatient()
        {
            this.PatientID = clsPatientsData.AddNewPatients(this.PersonID, this.BloodType, this.CreatedByUserID, this.CreatedDate,this.IsActive);
            return (this.PatientID > 0);
        }
        private bool _UpdatePatient()
        {
            return clsPatientsData.UpdatePatients(this.PatientID, this.PersonID, this.BloodType, this.IsActive);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewPatient())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdatePatient())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool Delete(int PatientID)
        {
            return clsPatientsData.Delete(PatientID);
        }
        public bool Delete()
        {
            return clsPatientsData.Delete(this.PatientID);
        }

        public static DataTable GetAllPatientList()
        {
            return clsPatientsData.GetAllPatients();
        }
        public static DataTable GetAllActivePatients()
        {
            return clsPatientsData.GetAllActivePatients();
        }
    }
}
