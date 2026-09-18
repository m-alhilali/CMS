using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsAppointmentTypesData
    {
        public static bool UpdateAppointmentType(int AppointmentTypeID, string AppointmentTypeTitle,decimal AppointmentTypeFees,bool IsActive)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update AppointmentTypes 
                            Set AppointmentTypeTitle=@AppointmentTypeTitle,
                                AppointmentTypeFees=@AppointmentTypeFees,
                                IsActive=@IsActive
                            Where AppointmentTypeID=@AppointmentTypeID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentTypeID", AppointmentTypeID);
                        command.Parameters.AddWithValue(@"AppointmentTypeTitle", AppointmentTypeTitle);
                        command.Parameters.AddWithValue(@"AppointmentTypeFees", AppointmentTypeFees);
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
        public static int AddNewAppointmentType(string AppointmentTypeTitle,decimal AppointmentTypeFees,bool IsActive)
        {
            int SpecialtyID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            AppointmentTypes(AppointmentTypeTitle,AppointmentTypeFees,IsActive)
                            Values(@AppointmentTypeTitle,@AppointmentTypeFees,@IsActive)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentTypeTitle", AppointmentTypeTitle);
                        command.Parameters.AddWithValue(@"AppointmentTypeFees", AppointmentTypeFees);
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
        public static bool UpdateStatus(int AppointmentTypeID,bool IsActive)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update AppointmentTypes 
                             set IsActive=@IsActive
                            Where AppointmentTypeID=@AppointmentTypeID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentTypeID", AppointmentTypeID);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);

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
        public static bool GetByAppointmentTypeID(int AppointmentTypeID, ref string AppointmentTypeTitle,ref decimal AppointmentTypeFees,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from AppointmentTypes 
                            Where AppointmentTypeID=@AppointmentTypeID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    { 
                        command.Parameters.AddWithValue(@"AppointmentTypeID", AppointmentTypeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AppointmentTypeTitle = Convert.ToString(reader["AppointmentTypeTitle"]);
                                AppointmentTypeFees = Convert.ToDecimal(reader["AppointmentTypeFees"]);
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
        public static bool IsAppointmentTypeExist(string AppointmentTypeTitle)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find =1  from AppointmentTypes 
                            Where AppointmentTypeTitle=@AppointmentTypeTitle";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentTypeTitle", AppointmentTypeTitle);

                        object reader = command.ExecuteScalar();
                        if (reader != null)
                        {
                            IsFind = Convert.ToInt32(reader) > 0;
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
        public static DataTable GetAllAppointmentTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from AppointmentTypes 
                            Order by AppointmentTypeID";
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
