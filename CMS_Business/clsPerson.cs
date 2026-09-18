using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsPerson
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get { return FirstName + " " + SecondName+" "+ThirdName+" "+LastName; } 
        }
        public DateTime DateOfBirth { get; set; }
        public enum enGender { Male=0,Female=1 }
        public enGender Gender { get; set; }
        public byte NationalityCountryID { get; set; }
        public clsCountries CountryInfo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            Mode = enMode.Add;
            PersonID = -1;
            NationalNo= string.Empty;
            FirstName= string.Empty;
            SecondName= string.Empty;
            ThirdName= string.Empty;
            LastName= string.Empty;
            DateOfBirth= DateTime.MinValue;
            Gender= 0;
            NationalityCountryID = 0;
            Phone= string.Empty;
            Address= string.Empty;
            ImagePath= string.Empty;

        }
        private clsPerson(int PersonID,string NationalNo,string FirstName,string SecondName,string ThirdName, string LastName, DateTime DateOfBirth,enGender Gender,byte NationalityCountryID,string Phone,string Address, string ImagePath)
        {
            Mode = enMode.Update;
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountries.Find((int)NationalityCountryID);
            this.Phone = Phone;
            this.Address = Address;
            this.ImagePath = ImagePath;
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0, NationalityCountryID = 0;
            if (clsPersonData.GetByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref NationalityCountryID, ref Phone, ref Address,ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,(enGender) Gender, NationalityCountryID, Phone, Address,ImagePath);
            }
            return null;
        }
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            int PersonID = -1;
            byte Gender = 0, NationalityCountryID = 0;
            if (clsPersonData.GetByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref NationalityCountryID, ref Phone, ref Address,ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGender)Gender, NationalityCountryID, Phone, Address,ImagePath);
            }
            return null;
        }

        private bool _AddNewPerson()
        {
            this.PersonID=clsPersonData.AddNewPerson(this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.DateOfBirth,(byte)this.Gender,this.NationalityCountryID,this.Phone,this.Address,this.ImagePath);
            return (this.PersonID>0);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID,this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.DateOfBirth,(byte)this.Gender,this.NationalityCountryID,this.Phone,this.Address,this.ImagePath);
        }
        public bool Save()
        {
            bool IsSave=false;
            switch(Mode)
            {
                case enMode.Add:
                    if(_AddNewPerson())
                    {
                        IsSave=true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdatePerson())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool Delete(int PersonID)
        {
            return clsPersonData.Delete(PersonID);
        }
        public bool Delete()
        {
            return clsPersonData.Delete(this.PersonID);
        }

        public static DataTable GetNormalPeopleList()
        {
            return clsPersonData.GetNormalPeopleList();
        }
        public static DataTable GetPeopleList()
        {
            return clsPersonData.GetPeopleList();
        }
        public static bool IsPersonExists(string NationalNo)
        {
            return clsPersonData.IsPersonExists(NationalNo);
        }
        public static bool IsPersonExists(int PersonID)
        {
            return clsPersonData.IsPersonExists(PersonID);
        }
        public int GetDoctorIDByPersonID()
        {
            return clsDoctorsData.GetDoctorIDByPersonID(this.PersonID);
        }
        public int GetPatientIDByPersonID()
        {
            return clsDoctorsData.GetPatientIDByPersonID(this.PersonID);
        }
        public static int GetDoctorIDByPersonID(int PersonID)
        {
            return clsDoctorsData.GetDoctorIDByPersonID(PersonID);
        }

    }
}
