using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsCountriesData
    {
        public static bool UpdateCountry(int CountryID, string CountryName)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UPDATE Countries 
                            Set CountryName=@CountryName
                            Where CountryID=@CountryID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"CountryID", CountryID);
                        command.Parameters.AddWithValue(@"CountryName", CountryName);

                        EfferctedRow = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                EfferctedRow = -1;
            }
           
            return EfferctedRow > 0;
        }
        public static int AddNewCountry(string CountryName)
        {
            int NewCountryID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            Countries(CountryName)
                            Values(@CountryName)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"CountryName", CountryName);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            NewCountryID = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
           
            return NewCountryID;
        }
        public static bool Delete(int CountryID)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UpdateStatus Countries 
                            Where CountryID=@CountryID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"CountryID", CountryID);

                        int reader = command.ExecuteNonQuery();
                        IsDeleted = reader > 0;
                    }

                }
            }
            catch
            {
                IsDeleted = false;
            }
           
            return IsDeleted;
        }
        public static bool GetByCountryID(int CountryID,ref string CountryName)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"Select * from Countries 
                            Where CountryID=@CountryID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"CountryID", CountryID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CountryName = Convert.ToString(reader["CountryName"]);

                                IsFind = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                IsFind = false;
            }
           
            return IsFind;
        }
        public static bool GetByCountryName(string CountryName,ref int CountryID)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"Select * from Countries 
                            Where CountryName=@CountryName";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"CountryName", CountryName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CountryID = Convert.ToInt32(reader["CountryID"]);

                                IsFind = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                IsFind = false;
            }

            return IsFind;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Countries 
                            Order by CountryName desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }


                }
            }
            catch
            {
                dt = null;
            }
           
            return dt;
        }

    }
}
