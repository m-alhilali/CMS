using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsPersonData
    {
        public static bool UpdatePerson(int PersonID,string NationalNo,string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, byte NationalityCountryID,string Phone,string Address,string ImagePath)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"PersonID",   SqlDbType.Int).Value=PersonID;
                        command.Parameters.Add(@"NationalNo", SqlDbType.NVarChar,50).Value=NationalNo;
                        command.Parameters.Add(@"FirstName",  SqlDbType.NVarChar, 50).Value=FirstName;
                        command.Parameters.Add(@"SecondName", SqlDbType.NVarChar, 50).Value=SecondName;
                        command.Parameters.Add(@"ThirdName",  SqlDbType.NVarChar, 50).Value=ThirdName;
                        command.Parameters.Add(@"LastName",   SqlDbType.NVarChar, 50).Value=LastName;
                        command.Parameters.Add(@"DateOfBirth",SqlDbType.DateTime).Value= DateOfBirth;
                        command.Parameters.Add(@"Gender",     SqlDbType.TinyInt).Value=Gender;
                        command.Parameters.Add(@"NationalityCountryID", SqlDbType.Int, 50).Value= NationalityCountryID;
                        command.Parameters.Add(@"Phone", SqlDbType.NVarChar, 20).Value = Phone;
                        command.Parameters.Add(@"Address", SqlDbType.Int, 300).Value = Address;
                        if (!string.IsNullOrWhiteSpace(ImagePath))
                            command.Parameters.Add(@"ImagePath", SqlDbType.NVarChar, 250).Value = ImagePath;
                        else
                            command.Parameters.Add(@"ImagePath", SqlDbType.NVarChar, 250).Value = DBNull.Value;

                        EfferctedRow = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return EfferctedRow>0;
        }
        public static int AddNewPerson(string NationalNo,string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, byte NationalityCountryID,string Phone,string Address,string ImagePath)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter PersonIDParam=command.Parameters.Add(@"PersonID", SqlDbType.Int);
                        PersonIDParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(@"NationalNo", SqlDbType.NVarChar, 50).Value = NationalNo;
                        command.Parameters.Add(@"FirstName", SqlDbType.NVarChar, 50).Value = FirstName;
                        command.Parameters.Add(@"SecondName", SqlDbType.NVarChar, 50).Value = SecondName;
                        command.Parameters.Add(@"ThirdName", SqlDbType.NVarChar, 50).Value = ThirdName;
                        command.Parameters.Add(@"LastName", SqlDbType.NVarChar, 50).Value = LastName;
                        command.Parameters.Add(@"DateOfBirth", SqlDbType.DateTime).Value = DateOfBirth;
                        command.Parameters.Add(@"Gender", SqlDbType.TinyInt).Value = Gender;
                        command.Parameters.Add(@"NationalityCountryID", SqlDbType.Int, 50).Value = NationalityCountryID;
                        command.Parameters.Add(@"Phone", SqlDbType.NVarChar, 20).Value = Phone;
                        command.Parameters.Add(@"Address", SqlDbType.Int, 300).Value = Address;
                        if (!string.IsNullOrWhiteSpace(ImagePath))
                            command.Parameters.Add(@"ImagePath", SqlDbType.NVarChar, 250).Value = ImagePath;
                        else
                            command.Parameters.Add(@"ImagePath", SqlDbType.NVarChar, 250).Value = DBNull.Value;

                        command.ExecuteNonQuery();
                        if (PersonIDParam.Value != null&&PersonIDParam.Value != DBNull.Value && int.TryParse(PersonIDParam.Value.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message,EventLogEntryType.Error);
            }
            return PersonID;
        }
        public static bool IsPersonExists( string NationalNo)
        {
            bool IsExists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find=1 from People 
                            Where NationalNo=@NationalNo";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"NationalNo", NationalNo);

                        object obj = command.ExecuteScalar();
                        IsExists = obj != null ? true : false;
                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return IsExists;
        }
        public static bool IsPersonExists( int PersonID)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find=1 from People 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);

                        object obj = command.ExecuteScalar();
                        IsExists = obj != null ? true : false;
                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }

            return IsExists;
        }
        public static bool Delete( int PersonID)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"delete People 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);


                        int reader = command.ExecuteNonQuery();
                        IsDeleted = reader > 0;
                    }

                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, EventLogEntryType.Error);
            }
            return IsDeleted;
        }
        public static bool GetByNationalNo( string NationalNo,ref int PersonID, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref byte Gender, ref byte NationalityCountryID,
            ref string Phone, ref string Address, ref string ImagePath)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand("SP_GetPersonInfoByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"NationalNo", SqlDbType.NVarChar, 50).Value = NationalNo;
                        var PersonIDparameter = command.Parameters.Add(@"PersonID", SqlDbType.Int);
                        PersonIDparameter.Direction = ParameterDirection.Output;
                        var FirstNameparameter = command.Parameters.Add(@"FirstName", SqlDbType.NVarChar, 50);
                        FirstNameparameter.Direction = ParameterDirection.Output;
                        var SecondNameparameter = command.Parameters.Add(@"SecondName", SqlDbType.NVarChar, 50);
                        SecondNameparameter.Direction = ParameterDirection.Output;
                        var ThirdNameparamerter = command.Parameters.Add(@"ThirdName", SqlDbType.NVarChar, 50);
                        ThirdNameparamerter.Direction = ParameterDirection.Output;
                        var LastNameparameter = command.Parameters.Add(@"LastName", SqlDbType.NVarChar, 50);
                        LastNameparameter.Direction = ParameterDirection.Output;
                        var DateOfBirthparameter = command.Parameters.Add(@"DateOfBirth", SqlDbType.DateTime);
                        DateOfBirthparameter.Direction = ParameterDirection.Output;
                        var Genderparameter = command.Parameters.Add(@"Gender", SqlDbType.TinyInt);
                        Genderparameter.Direction = ParameterDirection.Output;
                        var NationalityCountryIDparameter = command.Parameters.Add(@"NationalityCountryID", SqlDbType.Int);
                        NationalityCountryIDparameter.Direction = ParameterDirection.Output;
                        var Phoneparameter = command.Parameters.Add(@"Phone", SqlDbType.NVarChar, 20);
                        Phoneparameter.Direction = ParameterDirection.Output;
                        var Addressparameter = command.Parameters.Add(@"Address", SqlDbType.NVarChar, 300);
                        Addressparameter.Direction = ParameterDirection.Output;
                        var ImagePathparameter = command.Parameters.Add(@"ImagePath", SqlDbType.NVarChar, 250);
                        ImagePathparameter.Direction = ParameterDirection.Output;
                        var IsFoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        IsFoundparameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        if (IsFoundparameter.Value != null && IsFoundparameter.Value != DBNull.Value && Convert.ToInt32(IsFoundparameter.Value) == 1)
                        {
                            PersonID = Convert.ToInt32(PersonIDparameter.Value);
                            FirstName = Convert.ToString(FirstNameparameter.Value);
                            SecondName = Convert.ToString(SecondNameparameter.Value);
                            ThirdName = Convert.ToString(ThirdNameparamerter.Value);
                            LastName = Convert.ToString(LastNameparameter.Value);
                            DateOfBirth = Convert.ToDateTime(DateOfBirthparameter.Value);
                            Gender = Convert.ToByte(Genderparameter.Value);
                            NationalityCountryID = Convert.ToByte(NationalityCountryIDparameter.Value);
                            Phone = Convert.ToString(Phoneparameter.Value);
                            Address = Convert.ToString(Addressparameter.Value);
                            if (ImagePathparameter.Value != DBNull.Value && ImagePathparameter.Value!= null)
                                ImagePath = Convert.ToString(ImagePathparameter.Value);
                            else
                                ImagePath = "";
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
        public static bool GetByID(int PersonID,ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref byte Gender, ref byte NationalityCountryID,
            ref string Phone, ref string Address, ref string ImagePath)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPersonInfoByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"PersonID", SqlDbType.Int).Value = PersonID;
                        var NationalNoparameter = command.Parameters.Add(@"NationalNo", SqlDbType.NVarChar,50);
                        NationalNoparameter.Direction = ParameterDirection.Output;
                        var FirstNameparameter = command.Parameters.Add(@"FirstName", SqlDbType.NVarChar, 50);
                        FirstNameparameter.Direction = ParameterDirection.Output;
                        var SecondNameparameter = command.Parameters.Add(@"SecondName", SqlDbType.NVarChar, 50);
                        SecondNameparameter.Direction = ParameterDirection.Output;
                        var ThirdNameparamerter = command.Parameters.Add(@"ThirdName", SqlDbType.NVarChar, 50);
                        ThirdNameparamerter.Direction = ParameterDirection.Output;
                        var LastNameparameter = command.Parameters.Add(@"LastName", SqlDbType.NVarChar, 50);
                        LastNameparameter.Direction = ParameterDirection.Output;
                        var DateOfBirthparameter = command.Parameters.Add(@"DateOfBirth", SqlDbType.DateTime);
                        DateOfBirthparameter.Direction = ParameterDirection.Output;
                        var Genderparameter = command.Parameters.Add(@"Gender", SqlDbType.TinyInt);
                        Genderparameter.Direction = ParameterDirection.Output;
                        var NationalityCountryIDparameter = command.Parameters.Add(@"NationalityCountryID", SqlDbType.Int);
                        NationalityCountryIDparameter.Direction = ParameterDirection.Output;
                        var Phoneparameter = command.Parameters.Add(@"Phone", SqlDbType.NVarChar, 20);
                        Phoneparameter.Direction = ParameterDirection.Output;
                        var Addressparameter = command.Parameters.Add(@"Address", SqlDbType.NVarChar, 300);
                        Addressparameter.Direction = ParameterDirection.Output;
                        var ImagePathparameter = command.Parameters.Add(@"ImagePath", SqlDbType.NVarChar, 250);
                        ImagePathparameter.Direction = ParameterDirection.Output;
                        var IsFoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        IsFoundparameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        if (IsFoundparameter.Value != null && IsFoundparameter.Value != DBNull.Value && Convert.ToInt32(IsFoundparameter.Value) == 1)
                        {
                            NationalNo = Convert.ToString(NationalNoparameter.Value);
                            FirstName = Convert.ToString(FirstNameparameter.Value);
                            SecondName = Convert.ToString(SecondNameparameter.Value);
                            ThirdName = Convert.ToString(ThirdNameparamerter.Value);
                            LastName = Convert.ToString(LastNameparameter.Value);
                            DateOfBirth = Convert.ToDateTime(DateOfBirthparameter.Value);
                            Gender = Convert.ToByte(Genderparameter.Value);
                            NationalityCountryID = Convert.ToByte(NationalityCountryIDparameter.Value);
                            Phone = Convert.ToString(Phoneparameter.Value);
                            Address = Convert.ToString(Addressparameter.Value);
                            if (ImagePathparameter.Value != DBNull.Value && ImagePathparameter.Value != null)
                                ImagePath = Convert.ToString(ImagePathparameter.Value);
                            else
                                ImagePath = "";
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

        public static DataTable GetNormalPeopleList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from People 
                            Order by PersonID";
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
        public static DataTable GetPeopleList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPeopleList", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
                        using (SqlDataAdapter reader = new SqlDataAdapter(command))
                        {
                            reader.Fill(dt);
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
