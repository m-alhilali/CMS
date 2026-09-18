using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static CMS_Business.clsAppointments;
using static CMS_Business.clsPerson;

namespace CMS_Business
{
    public class clsAppointments
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int AppointmentID {  get; set; }
        public int AppointmentTypeID {  get; set; }
        public clsAppointmentTypes AppointmentTypeInfo {  get; set; }
        public int DoctorID {  get; set; }
        public clsDoctors DoctorInfo { get; set; }
        public int PatientID {  get; set; }
        public clsPatients PatientInfo { get; set; }

        public clsAppointments.enAppointmentStatus AppointmentStatus {  get; set; }
        public enum enAppointmentStatus { Pending=1,Completed=2,Cancelled=3, NotAttended = 4 }
        public DateTime AppointmentDate {  get; set; }
        public DateTime LastStatusDate {  get; set; }
        public DateTime CreatedDate {  get; set; }
        public decimal AppointmentFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUsers UserInfo { get; set; }
        public clsAppointments()
        {
            Mode = enMode.Add;
            this.AppointmentID = -1;
            this.DoctorID = -1;
            this.PatientID = -1;
            this.AppointmentStatus = enAppointmentStatus.Pending;
            this.AppointmentTypeID = -1;
            this.AppointmentDate = DateTime.Now;
            this.CreatedDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.AppointmentFees = 0;
            this.CreatedByUserID = 0;

           

        }
        private clsAppointments(int DoctorID, int AppointmentID, int PatientID, int AppointmentTypeID, enAppointmentStatus AppointmentStatus, DateTime AppointmentDate, DateTime LastStatusDate, DateTime CreatedDate, decimal PaidFees, int CreatedByUserID)
        {
            this.AppointmentID = AppointmentID;
            this.DoctorID = DoctorID;
            this.DoctorInfo =clsDoctors.FindByDoctorID(this.DoctorID);
            this.PatientID = PatientID;
            this.PatientInfo=clsPatients.FindByPatientID(this.PatientID);
            this.AppointmentStatus = AppointmentStatus;
            this.AppointmentTypeID = AppointmentTypeID;
            this.AppointmentTypeInfo = clsAppointmentTypes.Find(this.AppointmentTypeID);
            this.AppointmentDate = AppointmentDate;
            this.CreatedDate = CreatedDate;
            this.LastStatusDate = LastStatusDate;
            this.AppointmentFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUsers.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
        }

        public static clsAppointments FindByAppointmentID(int AppointmentID)
        {
            DateTime AppointmentDate = DateTime.MinValue, LastStatusDate=DateTime.MinValue, CreatedDate=DateTime.MinValue;
            int PatientID = -1, CreatedByUserID = -1, AppointmentStatus = 0, AppointmentTypeID = 0, DoctorID = -1;
            decimal PaidFees = -1;
            if (clsAppointmentsData.GetByAppointmentID(AppointmentID, ref DoctorID, ref PatientID, ref AppointmentTypeID, ref AppointmentStatus, ref AppointmentDate, ref LastStatusDate, ref CreatedDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsAppointments(DoctorID, AppointmentID, PatientID, AppointmentTypeID,(enAppointmentStatus) AppointmentStatus, AppointmentDate, LastStatusDate, CreatedDate, PaidFees, CreatedByUserID);
            }
            return null;
        }
        public static clsAppointments FindByDoctorID(int DoctorID)
        {
            DateTime AppointmentDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue, CreatedDate = DateTime.MinValue;
            int PatientID = -1, CreatedByUserID = -1, AppointmentStatus = 0, AppointmentTypeID = 0, AppointmentID = -1;
            decimal PaidFees = -1;
            if (clsAppointmentsData.GetByDoctorID( DoctorID,ref AppointmentID, ref PatientID, ref AppointmentTypeID, ref AppointmentStatus, ref AppointmentDate, ref LastStatusDate, ref CreatedDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsAppointments(DoctorID, AppointmentID, PatientID, AppointmentTypeID, (enAppointmentStatus)AppointmentStatus, AppointmentDate, LastStatusDate, CreatedDate, PaidFees, CreatedByUserID);
            }
            return null;
        }
        public static clsAppointments FindByPatientID(int PatientID)
        {
            DateTime AppointmentDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue, CreatedDate = DateTime.MinValue;
            int DoctorID = -1, CreatedByUserID = -1, AppointmentStatus = 0, AppointmentTypeID = 0, AppointmentID = -1;
            decimal PaidFees = -1;
            if (clsAppointmentsData.GetByPatientID(PatientID,ref DoctorID, ref AppointmentID, ref AppointmentTypeID, ref AppointmentStatus, ref AppointmentDate, ref LastStatusDate, ref CreatedDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsAppointments(DoctorID, AppointmentID, PatientID, AppointmentTypeID, (enAppointmentStatus)AppointmentStatus, AppointmentDate, LastStatusDate, CreatedDate, PaidFees, CreatedByUserID);
            }
            return null;
        }

        private bool _AddNewAppointments()
        {
            this.AppointmentID = clsAppointmentsData.AddNewAppointment(this.DoctorID, this.PatientID,this.AppointmentTypeID,(int) this.AppointmentStatus, this.AppointmentDate, this.LastStatusDate, this.CreatedDate, this.AppointmentFees, this.CreatedByUserID);
            return (this.AppointmentID > 0);
        }
        private bool _UpdateAppointments()
        {
            return clsAppointmentsData.UpdateAppointment(this.AppointmentID,this.DoctorID, this.PatientID,this.AppointmentTypeID, (int)this.AppointmentStatus, this.AppointmentDate, this.LastStatusDate, this.AppointmentFees);

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
        public static bool Delete(int AppointmentID)
        {
            return clsAppointments.Delete(AppointmentID);
        }
        public bool Delete()
        {
            return clsAppointments.Delete(this.AppointmentID);
        }

        public static  DataTable GetAppointmentsListByPatientID(int PatientID)
        {
            return clsAppointmentsData.GetAppointmentsListByPatientID(PatientID);
        }
        public static DataTable GetAllAppointments()
        {
            DataTable dt= clsAppointmentsData.GetAllAppointments();
            return dt;
        }
        public static DataTable GetAllAppointmentsListByDoctorID(int DoctorID)
        {
            return clsAppointmentsData.GetAllAppointmentsListByDoctorID(DoctorID);
        }
        public static DataTable GetActiveAppointmentsByDoctorID(int DoctorID)
        {
            return clsAppointmentsData.GetActiveAppointmentsByDoctorID(DoctorID);
        }
        public bool IsHaveAnActiveAppointmentInThisTime()
        {
            if(this==null)
                return false;
            return clsAppointmentsData.IsHaveAnActiveAppointmentInThisTime(this.DoctorID,this.AppointmentDate);
        }
        public bool IsExpiredAppointment()
        {
            return !IsHaveAnActiveAppointmentInThisTime();
        }
        public static bool CheckIsExpiredAnyAppointment()
        {
            return clsAppointmentsData.CheckIsExpiredAnyAppointment();
        }
        public bool IsExpiredAppointment(int DoctorID, DateTime AppointmentDate)
        {
            return !IsHaveAnActiveAppointmentInThisTime(DoctorID, AppointmentDate);
        }
        public bool NotAttended()
        {
            return clsAppointmentsData.ChangeStatus(this.AppointmentID,(int)clsAppointments.enAppointmentStatus.NotAttended);
        }
        public static bool NotAttended(int AppointmentID)
        {
            return clsAppointmentsData.ChangeStatus(AppointmentID,(int)clsAppointments.enAppointmentStatus.NotAttended);
        }
        public bool Completed()
        {
            return clsAppointmentsData.ChangeStatus(this.AppointmentID,(int)clsAppointments.enAppointmentStatus.Completed);
        }
        public static bool Completed(int AppointmentID)
        {
            return clsAppointmentsData.ChangeStatus(AppointmentID,(int)clsAppointments.enAppointmentStatus.Completed);
        }
        public bool Cancelled()
        {
            return clsAppointmentsData.ChangeStatus(this.AppointmentID,(int)clsAppointments.enAppointmentStatus.Cancelled);
        }
        public static bool Cancelled(int AppointmentID)
        {
            return clsAppointmentsData.ChangeStatus(AppointmentID,(int)clsAppointments.enAppointmentStatus.Cancelled);
        }
        public static bool IsHaveAnActiveAppointmentInThisTime(int DoctorID,DateTime AppointmentDate)
        {
            return clsAppointmentsData.IsHaveAnActiveAppointmentInThisTime(DoctorID,AppointmentDate);
        }
    }
}
