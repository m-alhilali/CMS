using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsSpecialties
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int SpecialtyID  {get; set;}
        public string SpecialtyName  {get; set;}
        public bool IsActive {get; set;}

        public clsSpecialties()
        {
            this.SpecialtyID = -1;
            this.SpecialtyName = "";
            this.IsActive = false;

            Mode = enMode.Add;

        }
        private clsSpecialties(int SpecialtyID, string SpecialtyName, bool IsActive)
        {
            this.SpecialtyID = SpecialtyID;
            this.SpecialtyName = SpecialtyName;
            this.IsActive = IsActive;
            Mode = enMode.Update;

        }

        public static clsSpecialties Find(int SpecialtyID)
        {
            string SpecialtyName = "";
            bool IsActive = false;
            if (clsSpecialtiesData.GetBySpecialtyID(SpecialtyID, ref SpecialtyName, ref IsActive))
            {
                return new clsSpecialties(SpecialtyID, SpecialtyName, IsActive);
            }
            return null;
        }
        private bool _AddNewSpecialty()
        {
            this.SpecialtyID = clsSpecialtiesData.AddNewSpecialty(this.SpecialtyName, this.IsActive);
            return (this.SpecialtyID > 0);
        }
        private bool _UpdateSpecialty()
        {
            return clsSpecialtiesData.UpdateSpecialty(this.SpecialtyID, this.SpecialtyName, this.IsActive);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewSpecialty())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateSpecialty())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool DeActive(int SpecialtyID)
        {
            return clsSpecialtiesData.UpdateStatus(SpecialtyID,false);
        }
        public bool DeActive()
        {
            return clsSpecialtiesData.UpdateStatus(this.SpecialtyID, false);
        }
        public bool Active()
        {
            return clsSpecialtiesData.UpdateStatus(this.SpecialtyID,true);
        }
        public static bool Active(int SpecialtyID)
        {
            return clsSpecialtiesData.UpdateStatus(SpecialtyID, true);
        }

        public static DataTable GetAllSpecialtiestList()
        {
            return clsSpecialtiesData.GetAllSpecialties();
        }
        public static bool IsSpecialitiesActive(int SpecialtyID)
        {
            return clsSpecialtiesData.IsSpecialtiesActive(SpecialtyID);
        }
        public static bool IsSpecialitiesExist(string SpecialtyName)
        {
            return clsSpecialtiesData.IsSpecialitiesExist(SpecialtyName);
        }
        public  bool IsSpecialitiesActive()
        {
            return clsSpecialtiesData.IsSpecialtiesActive(this.SpecialtyID);
        }
    }
}
