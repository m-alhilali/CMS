using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsDoctorsData
    {
        public static bool UpdateDoctor(int DoctorID, int PersonID, bool IsActive, int SpecialtyID)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UPDATE Doctors 
                            Set IsActive=@IsActive,PersonID=@PersonID,
                                SpecialtyID=@SpecialtyID
                            Where DoctorID=@DoctorID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);
                        command.Parameters.AddWithValue(@"SpecialtyID", SpecialtyID);

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
        public static int AddNewDoctors(int PersonID, bool IsActive, int SpecialtyID, int CreatedByUserID, DateTime CreatedDate)
        {
            int NewDoctorID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            Doctors(PersonID,IsActive,SpecialtyID,
                                   CreatedByUserID,CreatedDate)
                                   
                            Values(@PersonID,@IsActive,@SpecialtyID,
                                   @CreatedByUserID,@CreatedDate)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);
                        command.Parameters.AddWithValue(@"SpecialtyID", SpecialtyID);
                        command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue(@"CreatedDate", CreatedDate);
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            NewDoctorID = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
            
            return NewDoctorID;
        }
        public static bool UpdateStatus(int DoctorID,bool Status)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update Doctors 
                             Set IsActive=@Status
                            Where DoctorID=@DoctorID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        command.Parameters.AddWithValue(@"Status", Status);

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
        public static bool GetByPersonID(int PersonID, ref int DoctorID, ref bool IsActive, ref int SpecialtyID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Doctors 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DoctorID = Convert.ToInt32(reader["DoctorID"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                SpecialtyID = Convert.ToInt32(reader["SpecialtyID"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        public static bool GetByDoctorID(int DoctorID, ref int PersonID, ref bool IsActive, ref int SpecialtyID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFind = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Doctors 
                            Where DoctorID=@DoctorID"; ;
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = Convert.ToInt32(reader["PersonID"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                SpecialtyID = Convert.ToInt32(reader["SpecialtyID"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        public static bool IsDoctorExists(int DoctorID)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find=1 from Doctors
                            Where DoctorID=@DoctorID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);

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
        public static DataTable GetAllDoctorsList()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Doctors.DoctorID,People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,Case When Gender=0 then 'Male' else 'Female'end as Gender,Specialties.SpecialtyName,Doctors.CreatedDate,Doctors.IsActive from Doctors join People  On People.PersonID=Doctors.PersonID join Specialties On Specialties.SpecialtyID=Doctors.SpecialtyID
                            Order by CreatedDate desc";
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
        public static int GetDoctorIDByPersonID(int PersonID)
        {
            int DoctorID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select DoctorID from Doctors 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);

                        object obj = command.ExecuteScalar();
                        DoctorID = obj != null ? Convert.ToInt32(obj) : -1;
                    }
                }
            }
            catch
            {
                DoctorID = -1;
            }
           return DoctorID;
        }
        public static int GetPatientIDByPersonID(int PersonID)
        {
            int DoctorID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"Select PatientID from Patients 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);

                        connection.Open();
                        object obj = command.ExecuteScalar();
                        DoctorID = obj != null ? Convert.ToInt32(obj) : -1;
                    }
                }
            }
            catch
            {
                DoctorID = -1;
            }
            
            return DoctorID;
        }
    }
}