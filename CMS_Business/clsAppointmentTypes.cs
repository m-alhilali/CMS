using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsAppointmentTypes
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int AppointmentTypeID { get; set; }
        public string AppointmentTypeTitle { get; set; }
        public decimal AppointmentTypeFees { get; set; }
        public bool IsActive { get; set; }

        public clsAppointmentTypes()
        {
            AppointmentTypeID = -1;
            AppointmentTypeTitle = "";
            AppointmentTypeFees = -1;
            Mode = enMode.Add;

        }
        private clsAppointmentTypes(int AppointmentTypeID, string AppointmentTypeTitle, decimal AppointmentTypeFees, bool isActive)
        {
            this.AppointmentTypeID = AppointmentTypeID;
            this.AppointmentTypeTitle = AppointmentTypeTitle;
            this.AppointmentTypeFees = AppointmentTypeFees;
            this.IsActive = isActive;
            Mode = enMode.Update;
        }

        public static clsAppointmentTypes Find(int AppointmentTypeID)
        {
            string AppointmentTypeTitle = "";
            decimal AppointmentTypeFees = -1;
            bool isActive = false;
            if (clsAppointmentTypesData.GetByAppointmentTypeID(AppointmentTypeID, ref AppointmentTypeTitle, ref AppointmentTypeFees,ref isActive))
            {
                return new clsAppointmentTypes(AppointmentTypeID, AppointmentTypeTitle, AppointmentTypeFees, isActive);
            }
            return null;
        }
        private bool _AddNewAppointmentType()
        {
            this.AppointmentTypeID = clsAppointmentTypesData.AddNewAppointmentType(this.AppointmentTypeTitle, this.AppointmentTypeFees,this.IsActive);
            return (this.AppointmentTypeID > 0);
        }
        private bool _UpdateAppointmentType()
        {
            return clsAppointmentTypesData.UpdateAppointmentType(this.AppointmentTypeID, this.AppointmentTypeTitle, this.AppointmentTypeFees,this.IsActive);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewAppointmentType())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateAppointmentType())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool InActive(int AppointmentTypeID)
        {
            return clsAppointmentTypesData.UpdateStatus(AppointmentTypeID,false);
        }
        public bool InActive()
        {
            return clsAppointmentTypesData.UpdateStatus(this.AppointmentTypeID,false);
        }
        public static bool IsAppointmentTypeExist(string AppointmentTypeTile)
        {
            return clsAppointmentTypesData.IsAppointmentTypeExist(AppointmentTypeTile);
        }
        public static bool Active(int AppointmentTypeID)
        {
            return clsAppointmentTypesData.UpdateStatus(AppointmentTypeID,true);
        }
        public bool Active()
        {
            return clsAppointmentTypesData.UpdateStatus(this.AppointmentTypeID,true);
        }
        public static DataTable GetAllAppointmentTypesList()
        {
            return clsAppointmentTypesData.GetAllAppointmentTypes();
        }

    }
}
