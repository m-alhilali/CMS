using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsMedicines
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public decimal MedicineFees { get; set; }
        public bool IsActive { get; set; }

        public clsMedicines()
        {
            MedicineID = -1;
            MedicineName = "";
            MedicineFees = -1;
            IsActive = false;
            Mode = enMode.Add;

        }
        private clsMedicines(int MedicineID, string MedicineName, decimal MedicineFees,bool IsActive)
        {
            this.MedicineID = MedicineID;
            this.MedicineName = MedicineName;
            this.MedicineFees = MedicineFees;
            this.IsActive = IsActive;
            Mode = enMode.Update;

        }

        public static clsMedicines Find(int MedicineID)
        {
            string MedicineName = "";
            decimal MedicineFees = -1;
            bool IsActive = false;
            if (clsMedicinesData.GetByMedicineID(MedicineID, ref MedicineName, ref MedicineFees,ref IsActive))
            {
                return new clsMedicines(MedicineID, MedicineName, MedicineFees, IsActive);
            }
            return null;
        }
        private bool _AddNewMedicines()
        {
            this.MedicineID = clsMedicinesData.AddNewMedicine(this.MedicineName, this.MedicineFees,this.IsActive);
            return (this.MedicineID > 0);
        }
        private bool _UpdateMedicines()
        {
            return clsMedicinesData.UpdateMedicine(this.MedicineID, this.MedicineName, this.MedicineFees,this.IsActive);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewMedicines())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateMedicines())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool Deactive(int MedicineID)
        {
            return clsMedicinesData.UpdateStatus(MedicineID,false);
        }
        public static bool Active(int MedicineID)
        {
            return clsMedicinesData.UpdateStatus(MedicineID, true);
        }
        public bool Deactive()
        {
            return clsMedicinesData.UpdateStatus(this.MedicineID,false);
        }
        public bool Active()
        {
            return clsMedicinesData.UpdateStatus(this.MedicineID,true);
        }

        public static DataTable GetAllMedicinesList()
        {
            return clsMedicinesData.GetAllMedicines();
        }
        public static bool IsMedicineExist(string MedicineName)
        {
            return clsMedicinesData.IsMedicineExist(MedicineName);
        }
    }
}
