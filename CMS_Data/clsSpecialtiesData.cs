using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsSpecialtiesData
    {
        public static bool UpdateSpecialty(int SpecialtyID, string SpecialtyName,bool IsActive)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UPDATE Specialties 
                            Set SpecialtyName=@SpecialtyName,IsActive=@IsActive
                            Where SpecialtyID=@SpecialtyID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"SpecialtyID", SpecialtyID);
                        command.Parameters.AddWithValue(@"SpecialtyName", SpecialtyName);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);

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
        public static int AddNewSpecialty(string SpecialtyName,bool IsActive)
        {
            int SpecialtyID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            Specialties(SpecialtyName,IsActive)
                            Values(@SpecialtyName,@IsActive)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"SpecialtyName", SpecialtyName);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            SpecialtyID = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
            return SpecialtyID;
        }
        public static bool UpdateStatus(int SpecialtyID,bool IsActive)
        {
            bool DeActive = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update Specialties 
                             Set IsActive=@IsActive
                            Where SpecialtyID=@SpecialtyID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"SpecialtyID", SpecialtyID);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);
                        int reader = command.ExecuteNonQuery();
                        DeActive = reader > 0;
                    }
                }

            }
            catch
            {
                DeActive = false;
            }
            return DeActive;
        }
        public static bool GetBySpecialtyID(int SpecialtyID, ref string SpecialtyName,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Specialties 
                            Where SpecialtyID=@SpecialtyID ";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"SpecialtyID", SpecialtyID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                SpecialtyName = Convert.ToString(reader["SpecialtyName"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);

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
        public static DataTable GetAllSpecialties()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Specialties 
                            Order by SpecialtyName ";
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
        public static bool IsSpecialitiesExist(string SpecialtyName)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find=1 from Specialties 
                            Where SpecialtyName=@SpecialtyName ";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"SpecialtyName", SpecialtyName);

                        object obj = command.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out int numberset))
                        {

                            IsExists = numberset>0 ? true : false;
                        }
                    }

                }
            }
            catch
            {
                IsExists = false;
            }
            return IsExists;
        }
        public static bool IsSpecialtiesActive(int SpecialtyID)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find=1 from Specialties 
                            Where SpecialtyID=@SpecialtyID and IsActive=1";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"SpecialtyID", SpecialtyID);

                        object obj = command.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out int numberset))
                        {

                            IsExists = numberset > 0 ? true : false;
                        }
                    }

                }
            }
            catch
            {
                IsExists = false;
            }
            return IsExists;
        }

    }
}
