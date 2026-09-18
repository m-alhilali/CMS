using CMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Business
{
    public class clsCountries
    {
        public enum enMode { Add = 1, Update = 2 }
        public enMode Mode = enMode.Add;
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            CountryID = -1;
            CountryName = "";
            Mode = enMode.Add;

        }
        private clsCountries(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            Mode = enMode.Update;

        }

        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";
            if (clsCountriesData.GetByCountryID(CountryID, ref CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;
        }
        public static clsCountries Find(string CountryName)
        {
            int CountryID = -1;
            if (clsCountriesData.GetByCountryName(CountryName, ref CountryID))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;
        }
        private bool _AddNewCountry()
        {
            this.CountryID = clsCountriesData.AddNewCountry(this.CountryName);
            return (this.CountryID > 0);
        }
        private bool _UpdateCountry()
        {
            return clsCountriesData.UpdateCountry(this.CountryID, this.CountryName);
        }
        public bool Save()
        {
            bool IsSave = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewCountry())
                    {
                        IsSave = true;
                        Mode = enMode.Update;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateCountry())
                    {
                        IsSave = true;
                    }
                    break;
            }
            return IsSave;
        }
        public static bool Delete(int CountryID)
        {
            return  clsCountriesData.Delete(CountryID);
        }
        public bool Delete()
        {
            return clsCountriesData.Delete(this.CountryID);
        }

        public static DataTable GetAllCountriesList()
        {
            return clsCountriesData.GetAllCountries();
        }
    }
}
