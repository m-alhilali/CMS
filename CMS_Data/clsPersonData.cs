using System;
using System.Collections.Generic;
using System.Data;
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
                    string Query = @"UPDATE People 
                            Set NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,
                                   ThirdName=@ThirdName,LastName=@LastName,DateOfBirth=@DateOfBirth,
                                   Gender=@Gender,NationalityCountryID=@NationalityCountryID,
                                   Phone=@Phone,Address=@Address,ImagePath=@ImagePath
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);
                        command.Parameters.AddWithValue(@"NationalNo", NationalNo);
                        command.Parameters.AddWithValue(@"FirstName", FirstName);
                        command.Parameters.AddWithValue(@"SecondName", SecondName);
                        command.Parameters.AddWithValue(@"ThirdName", ThirdName);
                        command.Parameters.AddWithValue(@"LastName", LastName);
                        command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue(@"Gender", Gender);
                        command.Parameters.AddWithValue(@"NationalityCountryID", NationalityCountryID);
                        command.Parameters.AddWithValue(@"Phone", Phone);
                        command.Parameters.AddWithValue(@"Address", Address);
                        if (!string.IsNullOrWhiteSpace(ImagePath))
                            command.Parameters.AddWithValue(@"ImagePath", ImagePath);
                        else
                            command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);

                        EfferctedRow = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                EfferctedRow = -1;
            }
            return EfferctedRow>0;
        }
        public static int AddNewPerson(string NationalNo,string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, byte NationalityCountryID,string Phone,string Address,string ImagePath)
        {
            int NewPersonID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            People(NationalNo,FirstName,SecondName,
                                   ThirdName,LastName,DateOfBirth,
                                   Gender,NationalityCountryID,
                                   Phone,Address,ImagePath)
                            Values(@NationalNo,@FirstName,@SecondName,
                                   @ThirdName,@LastName,@DateOfBirth,
                                   @Gender,@NationalityCountryID,
                                   @Phone,@Address,@ImagePath)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"NationalNo", NationalNo);
                        command.Parameters.AddWithValue(@"FirstName", FirstName);
                        command.Parameters.AddWithValue(@"SecondName", SecondName);
                        command.Parameters.AddWithValue(@"ThirdName", ThirdName);
                        command.Parameters.AddWithValue(@"LastName", LastName);
                        command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue(@"Gender", Gender);
                        command.Parameters.AddWithValue(@"NationalityCountryID", NationalityCountryID);
                        command.Parameters.AddWithValue(@"Phone", Phone);
                        command.Parameters.AddWithValue(@"Address", Address);
                        if (!string.IsNullOrWhiteSpace(ImagePath))
                            command.Parameters.AddWithValue(@"ImagePath", ImagePath);
                        else
                            command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            NewPersonID = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
            return NewPersonID;
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
            catch
            {
                IsExists = false;
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
            catch
            {
                IsExists = false;
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
            catch
            {
                IsDeleted = false;
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
                    string Query = @"Select * from People 
                            Where NationalNo=@NationalNo";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"NationalNo", NationalNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = Convert.ToInt32(reader["PersonID"]);
                                FirstName = Convert.ToString(reader["FirstName"]);
                                SecondName = Convert.ToString(reader["SecondName"]);
                                ThirdName = Convert.ToString(reader["ThirdName"]);
                                LastName = Convert.ToString(reader["LastName"]);
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                Gender = Convert.ToByte(reader["Gender"]);
                                NationalityCountryID = Convert.ToByte(reader["NationalityCountryID"]);
                                Phone = Convert.ToString(reader["Phone"]);
                                Address = Convert.ToString(reader["Address"]);
                                if (reader["ImagePath"] != DBNull.Value)
                                    ImagePath = Convert.ToString(reader["ImagePath"]);
                                else
                                    ImagePath = "";
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
                    string Query = @"Select * from People 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                NationalNo = Convert.ToString(reader["NationalNo"]);
                                FirstName = Convert.ToString(reader["FirstName"]);
                                SecondName = Convert.ToString(reader["SecondName"]);
                                ThirdName = Convert.ToString(reader["ThirdName"]);
                                LastName = Convert.ToString(reader["LastName"]);
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                Gender = Convert.ToByte(reader["Gender"]);
                                NationalityCountryID = Convert.ToByte(reader["NationalityCountryID"]);
                                Phone = Convert.ToString(reader["Phone"]);
                                Address = Convert.ToString(reader["Address"]);
                                if (reader["ImagePath"] != DBNull.Value)
                                    ImagePath = Convert.ToString(reader["ImagePath"]);
                                else
                                    ImagePath = "";
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
            catch
            {
                dt = null;
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
                    string Query = @"Select PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,
                             DateOfBirth,Case When Gender=0 then 'Male' else 'Female'end as Gender,Phone,CountryName as Nationality,Address,ImagePath from People join Countries On People.NationalityCountryID=Countries.CountryID 
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
            catch
            {
                dt = null;
            }
            return dt;
        }
    }

}
