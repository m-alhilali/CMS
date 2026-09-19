using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
                   
                    using (SqlCommand command = new SqlCommand("SP_UpdateSpecialty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"SpecialtyID", SqlDbType.Int).Value= SpecialtyID;
                        command.Parameters.Add(@"SpecialtyName", SqlDbType.NVarChar,200).Value=SpecialtyName;
                        command.Parameters.Add(@"IsActive", SqlDbType.Bit).Value = IsActive;

                        EfferctedRow = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
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
                   
                    using (SqlCommand command = new SqlCommand("SP_AddNewSpecialty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(@"SpecialtyName", SqlDbType.NVarChar,200).Value= SpecialtyName;
                        command.Parameters.Add(@"IsActive", SqlDbType.Bit).Value= IsActive;
                        SqlParameter parameter = command.Parameters.Add("SpecialtyID", SqlDbType.Int);
                        parameter.Direction= ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        if (parameter.Value != null && parameter.Value!=DBNull.Value && Convert.ToInt32(parameter.Value)>0)
                        {
                            SpecialtyID = Convert.ToInt32(parameter.Value);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return SpecialtyID;
        }
        public static bool UpdateStatus(int SpecialtyID,bool IsActive)
        {
            bool NewStatus = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateSpecialtyStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"SpecialtyID", SqlDbType.Int).Value = SpecialtyID;
                        command.Parameters.Add(@"IsActive", SqlDbType.Bit).Value = IsActive;
                        int rowEffected = command.ExecuteNonQuery();
                        NewStatus = rowEffected > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return NewStatus;
        }
        public static bool GetBySpecialtyID(int SpecialtyID, ref string SpecialtyName,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetSpecialtyByID", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
                        command.Parameters.Add(@"SpecialtyID", SqlDbType.Int).Value=SpecialtyID;
                        SqlParameter NameParameters = command.Parameters.Add(@"SpecialtyName", SqlDbType.NVarChar, 200);
                        NameParameters.Direction = ParameterDirection.Output;
                        SqlParameter IsActiveParameters = command.Parameters.Add(@"IsActive", SqlDbType.Bit);
                        IsActiveParameters.Direction = ParameterDirection.Output;
                        SqlParameter IsFoundParameters = command.Parameters.Add(@"@IsFound", SqlDbType.Int);
                        IsFoundParameters.Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        if (IsFoundParameters.Value!=null && IsFoundParameters.Value!=DBNull.Value &&Convert.ToInt32(IsFoundParameters.Value)==1)
                        {
                            SpecialtyName = Convert.ToString(NameParameters.Value);
                            IsActive = Convert.ToBoolean(IsActiveParameters.Value);

                            IsFind = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
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
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
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
                    using (SqlCommand command = new SqlCommand("SP_IsSpecialitiesExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(@"SpecialtyName", SqlDbType.NVarChar,200).Value=SpecialtyName;
                        SqlParameter parameter=new SqlParameter();
                        parameter.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(parameter);
                         command.ExecuteNonQuery();
                        int result = (parameter.Value != null && parameter.Value != DBNull.Value) ? Convert.ToInt32(parameter.Value) : 0;
                        IsExists = (result == 1);
                    }

                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
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
                    using (SqlCommand command = new SqlCommand("SP_IsSpecialtiesActive", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(@"SpecialtyID", SqlDbType.Int).Value = SpecialtyID;
                        SqlParameter parameter = new SqlParameter();
                        parameter.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();
                        int result = (parameter.Value != null && parameter.Value != DBNull.Value) ? Convert.ToInt32(parameter.Value) : 0;
                        IsExists = (result == 1);
                    }

                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return IsExists;
        }

    }
}
