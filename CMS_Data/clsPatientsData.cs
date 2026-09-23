using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsPatientsData
    {
       
        public static bool UpdatePatients(int PatientID, int PersonID, string BloodType,bool IsActive)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UPDATE Patients 
                            Set BloodType=@BloodType,PersonID=@PersonID,
                                IsActive=@IsActive
                            Where PatientID=@PatientID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);
                        command.Parameters.AddWithValue(@"PatientID", PatientID);
                        if (!string.IsNullOrEmpty(BloodType))
                            command.Parameters.AddWithValue(@"BloodType", BloodType);
                        else
                            command.Parameters.AddWithValue(@"BloodType", DBNull.Value);
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
        public static int AddNewPatients(int PersonID, string BloodType, int CreatedByUserID, DateTime CreatedDate,bool IsActive)
        {
            int NewDoctorID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            Patients(PersonID,BloodType,
                                   CreatedByUserID,CreatedDate,IsActive)
                                   
                            Values(@PersonID,@BloodType,
                                   @CreatedByUserID,@CreatedDate,@IsActive)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);
                        if (!string.IsNullOrEmpty(BloodType))
                            command.Parameters.AddWithValue(@"BloodType", BloodType);
                        else
                            command.Parameters.AddWithValue(@"BloodType", DBNull.Value);

                        command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue(@"CreatedDate", CreatedDate);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);
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
        public static bool Delete(int PatientID)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    //This will not delete doctor but will change him status to deactive
                    string Query = @"UpdateStatus Patients 
                            Where PatientID=@PatientID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PatientID", PatientID);

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
        public static bool GetByPersonID(int PersonID,ref int PatientID,ref string BloodType,ref int CreatedByUserID,ref DateTime CreatedDate,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Patients 
                            Where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PersonID", PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PatientID = Convert.ToInt32(reader["PatientID"]);
                                if (reader["BloodType"] != DBNull.Value)
                                    BloodType = Convert.ToString(reader["BloodType"]);
                                else
                                    BloodType = "";
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        public static bool GetByPatientID(int PatientID,ref int PersonID,ref string BloodType,ref int CreatedByUserID,ref DateTime CreatedDate,ref bool IsActive)
        {
            bool IsFind = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"Select * from Patients 
                            Where PatientID=@PatientID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PatientID", PatientID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = Convert.ToInt32(reader["PersonID"]);
                                if (reader["BloodType"] != DBNull.Value)
                                    BloodType = Convert.ToString(reader["BloodType"]);
                                else
                                    BloodType = "";
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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

        public static DataTable GetAllActivePatients()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Patients.PatientID,People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,Patients.BloodType,Patients.CreatedDate from Patients join People On Patients.PersonID=People.PersonID 
                             Where IsActive=1
                            Order by PatientID desc";
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
        public static DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Patients.PatientID,People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,case when People.Gender=0 then 'Male' else 'Female' End as Gender,Patients.BloodType,Patients.CreatedDate,Patients.IsActive from Patients join People On Patients.PersonID=People.PersonID 
                            Order by PatientID desc";
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
