using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static CMS_Business.clsPerson;

namespace CMS_Business
{
    public class clsPrescriptionItems
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int PrescriptionItemID { get; set; }
        public int ConsultationID { get; set; }
        clsConsultations ConsultationsInfo { get; set; }
        public int MedicineID { get; set; }
        public clsMedicines MedicinesInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SpecialInstructions { get; set; } 
        public decimal PaidFees { get; set; }
        public byte? Duration { get; set; }
        public string DurationUnit { get; set; }
        public string Dosage { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }

        public clsPrescriptionItems()
        {
            Mode = enMode.Add;
            this.ConsultationID = -1;
            this.PrescriptionItemID = -1;
            this.CreatedByUserID = -1;
            this.MedicineID = -1;
            this.CreatedDate = DateTime.Now;
            this.SpecialInstructions = string.Empty;
            this.PaidFees = 0;
            this.DurationUnit = string.Empty;
            this.Duration = 0;
            this.Dosage = string.Empty;
            this.IsActive = false;

        }
        private clsPrescriptionItems(int PrescriptionItemID, int ConsultationID, int MedicineID, string SpecialInstructions, byte? Duration,string DurationUnit, string Dosage, decimal PaidFees, DateTime CreatedDate, int CreatedByUserID,bool IsActive)
        {
            Mode = enMode.Update;
            this.ConsultationID = ConsultationID;
            this.PrescriptionItemID = PrescriptionItemID;
            this.ConsultationsInfo=clsConsultations.FindByConsultationID(this.ConsultationID);
            this.CreatedByUserID = CreatedByUserID;
            this.MedicineID = MedicineID;
            this.MedicinesInfo=clsMedicines.Find(this.MedicineID);
            this.CreatedDate = CreatedDate;
            this.SpecialInstructions = SpecialInstructions;
            this.PaidFees = PaidFees;
            this.Duration = Duration;
            this.DurationUnit = DurationUnit;
            this.Dosage = Dosage;
            this.IsActive = IsActive;

        }

        public static clsPrescriptionItems FindByPrescriptionItemID(int PrescriptionItemID)
        {
            int ConsultationID = -1,CreatedByUserID = -1, MedicineID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            string SpecialInstructions = "", DurationUnit = "", Dosage="";
            decimal PaidFees = 0;
            byte? Duration = 0;
            bool IsActive = false;

            if (clsPrescriptionItemsData.GetByPrescriptionItemID(PrescriptionItemID, ref ConsultationID, ref MedicineID, ref SpecialInstructions, ref Duration,ref DurationUnit, ref Dosage, ref PaidFees, ref CreatedDate, ref CreatedByUserID,ref IsActive))
            {
                return new clsPrescriptionItems(PrescriptionItemID, ConsultationID, MedicineID, SpecialInstructions, Duration,DurationUnit, Dosage, PaidFees,CreatedDate, CreatedByUserID, IsActive);
            }
            return null;
        }
        public static clsPrescriptionItems FindByConsultationID(int ConsultationID)
        {
            int PrescriptionItemID = -1, CreatedByUserID = -1, MedicineID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            string SpecialInstructions = "", DurationUnit = "", Dosage = "";
            decimal PaidFees = 0;
            byte? Duration = 0;
            bool IsActive = false;
            if (clsPrescriptionItemsData.GetByConsultationID(ConsultationID, ref PrescriptionItemID, ref MedicineID, ref SpecialInstructions, ref Duration,ref DurationUnit, ref Dosage, ref PaidFees, ref CreatedDate, ref CreatedByUserID,ref IsActive))
            {
                return new clsPrescriptionItems(PrescriptionItemID, ConsultationID, MedicineID, SpecialInstructions, Duration, DurationUnit, Dosage, PaidFees, CreatedDate, CreatedByUserID, IsActive);
            }
            return null;
        }

        private bool _AddNewPrescriptionItems()
        {
            this.IsActive = true;
            this.PrescriptionItemID = clsPrescriptionItemsData.AddNewPrescriptionItems(this.ConsultationID, this.MedicineID, this.SpecialInstructions, this.Duration,this.DurationUnit, this.Dosage, this.PaidFees, this.CreatedDate, this.CreatedByUserID,this.IsActive);
            return (this.PrescriptionItemID > 0);
        }
        private bool _UpdatePrescriptionItems()
        {
            return clsPrescriptionItemsData.UpdatePrescriptionItems(this.PrescriptionItemID,this.ConsultationID, this.MedicineID, this.SpecialInstructions, this.Duration,this.DurationUnit, this.Dosage, this.PaidFees);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewPrescriptionItems())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdatePrescriptionItems())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool Deactive(int PrescriptionItemID)
        {
            return clsPrescriptionItemsData.Deactive(PrescriptionItemID);
        }
        public bool Deactive()
        {
            return clsPrescriptionItemsData.Deactive(this.PrescriptionItemID);
        }

        public static DataTable GetAllPrescriptionItemsByConsultationID(int ConsultationID)
        {
            return clsPrescriptionItemsData.GetAllPrescriptionItemsByConsultationID(ConsultationID);
        }
        public static DataTable GetActivePrescriptionItemsByConsultationID(int ConsultationID)
        {
            return clsPrescriptionItemsData.GetActivePrescriptionItemsByConsultationID(ConsultationID);
        }
        public static DataTable GetAllPrescriptionItems()
        {
            return clsPrescriptionItemsData.GetAllPrescriptionItems();
        }
    }
}
