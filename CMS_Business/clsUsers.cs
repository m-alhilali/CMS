using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsUsers
    {
        public enum enMode { Add=1,Update=2}
        public enMode Mode=enMode.Add;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public clsUsers()
        {
            IsActive = false;
            UserID = -1;
            CreatedByUserID = -1;
            PersonID = -1;
            Password = "";
            UserName = string.Empty;
            CreatedDate = DateTime.MinValue;
            Mode=enMode.Add;

        }
        private clsUsers(int userID, int personID, string password, string userName, DateTime createdDate, bool isActive,int CreatedByUserID)
        {
            this.UserID = userID;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonID = personID;
            this.Password = password;
            this.UserName = userName;
            this.CreatedDate = createdDate;
            this.IsActive = isActive;
            this.PersonInfo = clsPerson.Find(PersonID);
            Mode = enMode.Update;

        }

        public static clsUsers FindByUserID(int UserID)
        {
            string UserName = "", Password = "";
            DateTime CreatedDate = DateTime.MinValue;
            int PersonID = -1, CreatedByUserID=-1;
            bool IsActive = false;
            if (clsUsersData.GetByUserID(UserID, ref PersonID, ref UserName, ref Password, ref CreatedDate,ref CreatedByUserID, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Password, UserName, CreatedDate, IsActive, CreatedByUserID);
            }
            return null;
        }
        public static clsUsers FindByUserNameAndPassword(string UserName,string Password)
        {
            int UserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            int PersonID = -1, CreatedByUserID=-1;
            bool IsActive = false;
            if (clsUsersData.GetByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref CreatedDate, ref CreatedByUserID, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Password, UserName, CreatedDate, IsActive, CreatedByUserID);
            }
            return null;
        }
        public static clsUsers FindByPersonID(int PersonID)
        {
            string UserName = "", Password = "";
            DateTime CreatedDate = DateTime.MinValue;
            int UserID = -1, CreatedByUSerId=-1;
            bool IsActive = false;
            if (clsUsersData.GetByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref CreatedDate,ref CreatedByUSerId, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Password, UserName, CreatedDate, IsActive, CreatedByUSerId);
            }
            return null;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUsers(this.PersonID,this.UserName,this.Password,this.CreatedDate,this.CreatedByUserID,this.IsActive);
            return (this.UserID > 0);
        }
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUsers(this.UserID,this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewUser())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateUser())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool IsUserExists(int UserID)
        {
            return clsUsersData.IsUserExists(UserID);
        }
        public static bool IsUserExists(string UserName)
        {
            return clsUsersData.IsUserExists(UserName);
        }
        public static bool IsUserExists(string UserName,string Password)
        {
            return clsUsersData.IsUserExists(UserName,Password);
        }
        public static bool DeActive(int UserID)
        {
            return clsUsersData.UpdateStatus(UserID, false);
        }
        public static bool Active(int UserID)
        {
            return clsUsersData.UpdateStatus(UserID, true);
        }
        public bool DeActive()
        {
            return clsUsersData.UpdateStatus(this.UserID, false);
        }
        public bool Active()
        {
            return clsUsersData.UpdateStatus(this.UserID,true);
        }

        public static DataTable GetAllUserList()
        {
            return clsUsersData.GetAllUsersList();
        }
    }
}
