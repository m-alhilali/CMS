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
    public class clsUsersData
    {
        public static bool UpdateUsers(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"UserID",SqlDbType.Int).Value= UserID;
                        command.Parameters.Add(@"PersonID",SqlDbType.Int).Value= PersonID;
                        command.Parameters.Add(@"UserName",SqlDbType.NVarChar,50).Value= UserName;
                        command.Parameters.Add(@"Password",SqlDbType.NVarChar,65).Value= Password;
                        command.Parameters.Add(@"IsActive",SqlDbType.Bit).Value= IsActive;

                        EfferctedRow = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                EfferctedRow = -1;
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return EfferctedRow > 0;
        }
        public static int AddNewUsers(int PersonID, string UserName, string Password, DateTime CreatedDate,int CreatedByUserID, bool IsActive)
        {
            int UserID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"PersonID",SqlDbType.Int).Value= PersonID;
                        command.Parameters.Add(@"UserName", SqlDbType.NVarChar,50).Value= UserName;
                        command.Parameters.Add(@"Password", SqlDbType.NVarChar,65).Value= Password;
                        command.Parameters.Add(@"CreatedDate", SqlDbType.DateTime).Value= CreatedDate;
                        command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int).Value= CreatedByUserID;
                        command.Parameters.Add(@"IsActive", SqlDbType.Bit).Value= IsActive;
                        SqlParameter parameter= new SqlParameter(@"UserID",SqlDbType.Int);
                        parameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(parameter);

                        command.ExecuteNonQuery();
                        if(parameter.Value!=DBNull.Value)
                            UserID=Convert.ToInt32(parameter.Value);

                    }
                }
            }
            catch(Exception ex) 
            {
                UserID = -1;
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
           
            return UserID;
        }
        public static bool UpdateStatus(int UserID,bool IsActive)
        {
            bool IsUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand("SP_UpdateUserStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(@"UserID", SqlDbType.Int).Value=UserID;
                        command.Parameters.Add(@"IsActive", SqlDbType.Bit).Value=IsActive;

                        int EffectedRow = command.ExecuteNonQuery();
                        IsUpdated = EffectedRow >0;
                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return IsUpdated;
        }
        public static bool IsUserExists(string UserName,string Password)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_IsUserExistsByUserNameAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"UserName", SqlDbType.NVarChar, 50).Value = UserName;
                        command.Parameters.Add(@"Password", SqlDbType.NVarChar, 65).Value = Password;
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
        public static bool IsUserExists(string UserName)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_IsUserExistsByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"UserName", SqlDbType.NVarChar,50).Value = UserName;
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
        public static bool IsUserExists(int UserID)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand("SP_IsUserExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"UserID", SqlDbType.Int).Value=UserID;
                        SqlParameter parameter = new SqlParameter();
                        parameter.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();
                        
                        int result =(parameter.Value!=null && parameter.Value != DBNull.Value)? Convert.ToInt32(parameter.Value):0;
                        IsExists = (result==1);
                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return IsExists;
        }
        public static bool GetByPersonID(int PersonID,ref int UserID, ref string UserName,ref string Password,ref DateTime CreatedDate,ref int CreatedByUserID,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserByPersonID", connection))
                    {
                        command.CommandType=CommandType.StoredProcedure;
                        command.Parameters.Add(@"PersonID", SqlDbType.Int).Value=PersonID;
                        var useridparameter = command.Parameters.Add(@"UserID", SqlDbType.Int);
                        useridparameter.Direction = ParameterDirection.Output;
                        var usernameparameter = command.Parameters.Add(@"UserName", SqlDbType.NVarChar, 50);
                        usernameparameter.Direction = ParameterDirection.Output;
                        var passwordparameter = command.Parameters.Add(@"Password", SqlDbType.NVarChar, 65);
                        passwordparameter.Direction = ParameterDirection.Output;
                        var datedparamerter = command.Parameters.Add(@"CreatedDate", SqlDbType.DateTime);
                        datedparamerter.Direction = ParameterDirection.Output;
                        var createbyparameter = command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int);
                        createbyparameter.Direction = ParameterDirection.Output;
                        var isactiveparameter = command.Parameters.Add(@"IsActive", SqlDbType.Bit);
                        isactiveparameter.Direction = ParameterDirection.Output;
                        var isfoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        isfoundparameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        if(isfoundparameter.Value !=null && isfoundparameter.Value !=DBNull.Value && Convert.ToInt32(isfoundparameter.Value) == 1)
                        {
                             
                              UserID = Convert.ToInt32(useridparameter.Value);
                              CreatedByUserID = Convert.ToInt32(createbyparameter.Value);
                              UserName = Convert.ToString(usernameparameter.Value);
                              Password = Convert.ToString(passwordparameter.Value);
                              CreatedDate = Convert.ToDateTime(datedparamerter.Value);
                              IsActive = Convert.ToBoolean(isactiveparameter.Value);
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
        public static bool GetByUserNameAndPassword(string UserName, string Password, ref int UserID,ref int PersonID,ref DateTime CreatedDate,ref int CreatedByUserID, ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserByUserNameAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"UserName", SqlDbType.NVarChar,50).Value = UserName;
                        command.Parameters.Add(@"Password", SqlDbType.NVarChar,65).Value = Password;
                        var personidparameter = command.Parameters.Add(@"PersonID", SqlDbType.Int);
                        personidparameter.Direction = ParameterDirection.Output;
                        var useridparameter = command.Parameters.Add(@"UserID", SqlDbType.NVarChar, 50);
                        useridparameter.Direction = ParameterDirection.Output;
                        var datedparamerter = command.Parameters.Add(@"CreatedDate", SqlDbType.DateTime);
                        datedparamerter.Direction = ParameterDirection.Output;
                        var createbyparameter = command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int);
                        createbyparameter.Direction = ParameterDirection.Output;
                        var isactiveparameter = command.Parameters.Add(@"IsActive", SqlDbType.Bit);
                        isactiveparameter.Direction = ParameterDirection.Output;
                        var isfoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        isfoundparameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        if (isfoundparameter.Value != null && isfoundparameter.Value != DBNull.Value && Convert.ToInt32(isfoundparameter.Value) == 1)
                        {

                            PersonID = Convert.ToInt32(useridparameter.Value);
                            UserID = Convert.ToInt32(personidparameter.Value);
                            CreatedByUserID = Convert.ToInt32(createbyparameter.Value);
                            CreatedDate = Convert.ToDateTime(datedparamerter.Value);
                            IsActive = Convert.ToBoolean(isactiveparameter.Value);
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
        public static bool GetByUserID(int UserID,ref int PersonID,ref string UserName,ref string Password,ref DateTime CreatedDate,ref int CreatedByUserID, ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"UserID", SqlDbType.Int).Value = UserID;
                        var personidparameter = command.Parameters.Add(@"PersonID", SqlDbType.Int);
                        personidparameter.Direction = ParameterDirection.Output;
                        var usernameparameter = command.Parameters.Add(@"UserName", SqlDbType.NVarChar, 50);
                        usernameparameter.Direction = ParameterDirection.Output;
                        var passwordparameter = command.Parameters.Add(@"Password", SqlDbType.NVarChar, 65);
                        passwordparameter.Direction = ParameterDirection.Output;
                        var datedparamerter = command.Parameters.Add(@"CreatedDate", SqlDbType.DateTime);
                        datedparamerter.Direction = ParameterDirection.Output;
                        var createbyparameter = command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int);
                        createbyparameter.Direction = ParameterDirection.Output;
                        var isactiveparameter = command.Parameters.Add(@"IsActive", SqlDbType.Bit);
                        isactiveparameter.Direction = ParameterDirection.Output;
                        var isfoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        isfoundparameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        if (isfoundparameter.Value != null && isfoundparameter.Value != DBNull.Value && Convert.ToInt32(isfoundparameter.Value) == 1)
                        {

                            PersonID = Convert.ToInt32(personidparameter.Value);
                            CreatedByUserID = Convert.ToInt32(createbyparameter.Value);
                            UserName = Convert.ToString(usernameparameter.Value);
                            Password = Convert.ToString(passwordparameter.Value);
                            CreatedDate = Convert.ToDateTime(datedparamerter.Value);
                            IsActive = Convert.ToBoolean(isactiveparameter.Value);
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
        public static DataTable GetAllUsersList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter data = new SqlDataAdapter(command))
                        {
                           data.Fill(dt);
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

    }
}
