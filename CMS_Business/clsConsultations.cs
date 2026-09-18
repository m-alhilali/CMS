using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CMS_Business.clsAppointments;

namespace CMS_Business
{
    public class clsConsultations
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int ConsultationID { get; set; }
        public int AppointmentID { get; set; }
        public clsAppointments AppointmentsInfo {  get; set; }
        public DateTime ConsultationDate { get; set; }
        public decimal AdditionalFees { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers UserInfo { get; set; }

        public clsConsultations()
        {
            Mode = enMode.Add;
            this.AppointmentID = -1;
            this.ConsultationID = -1;
            this.ConsultationDate = DateTime.Now;
            this.AdditionalFees = 0;
            this.Diagnosis = "";
            this.Notes = "";
            this.CreatedByUserID = -1;



        }
        private clsConsultations(int ConsultationID, int AppointmentID, DateTime ConsultaionDate, decimal ConsultationFees, string Diagnosis, string Notes, int CreatedByUserID)
        {
            this.AppointmentID = AppointmentID;
            this.AppointmentsInfo = clsAppointments.FindByAppointmentID(this.AppointmentID);
            this.ConsultationID = ConsultationID;
            this.ConsultationDate = ConsultaionDate;
            this.AdditionalFees = ConsultationFees;
            this.Diagnosis = Diagnosis;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUsers.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
        }

        public static clsConsultations FindByAppointmentID(int AppointmentID)
        {
            DateTime ConsultaionDate = DateTime.Now;
            string Diagnosis = "", Notes="";
            int ConsultationID = -1, CreatedByUserID = -1;
            decimal ConsultationFees = -1;
            if (clsConsultationsData.GetByAppointmentID(AppointmentID, ref ConsultationID, ref ConsultationFees, ref Diagnosis, ref Notes, ref ConsultaionDate, ref CreatedByUserID))
            {
                return new clsConsultations(ConsultationID, AppointmentID, ConsultaionDate, ConsultationFees, Diagnosis, Notes, CreatedByUserID);
            }
            return null;
        }
        public static clsConsultations FindByConsultationID(int ConsultationID)
        {
            DateTime ConsultaionDate = DateTime.Now;
            string Diagnosis = "", Notes = "";
            int AppointmentID = -1, CreatedByUserID = -1;
            decimal ConsultationFees = -1;
            if (clsConsultationsData.GetByConsultationID(  ConsultationID,ref AppointmentID, ref ConsultationFees, ref Diagnosis, ref Notes, ref ConsultaionDate, ref CreatedByUserID))
            {
                return new clsConsultations(ConsultationID, AppointmentID, ConsultaionDate, ConsultationFees, Diagnosis, Notes, CreatedByUserID);
            }
            return null;
        }
        private bool _AddNewAppointments()
        {
            this.ConsultationID = clsConsultationsData.AddNewConsultations(this.AppointmentID, this.AdditionalFees, this.Diagnosis,this.Notes,this.ConsultationDate, this.CreatedByUserID);
            return (this.AppointmentID > 0);
        }
        private bool _UpdateAppointments()
        {
            return clsConsultationsData.UpdateConsultations(this.ConsultationID,this.AppointmentID, this.AdditionalFees, this.Diagnosis, this.Notes);

        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewAppointments())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateAppointments())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool Delete(int ConsultationID)
        {
            return clsConsultationsData.Delete(ConsultationID);
        }
        public bool Delete()
        {
            return clsConsultationsData.Delete(this.ConsultationID);
        }

        public static DataTable GetAllConsultationsListDetails()
        {
            return clsConsultationsData.GetAllConsultationsListDetails();
        }
        public static DataTable GetAllConsultations()
        {
            return clsConsultationsData.GetAllConsultations();
        }
     
    }
}
