using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsMedicinesData
    {

        public static bool UpdateMedicine(int MedicineID, string MedicineName,decimal MedicineFees,bool IsActive)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"UPDATE Medicines 
                            Set MedicineName=@MedicineName,MedicineFees=@MedicineFees,IsActive=@IsActive
                            Where MedicineID=@MedicineID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"MedicineID", MedicineID);
                        command.Parameters.AddWithValue(@"MedicineName", MedicineName);
                        command.Parameters.AddWithValue(@"MedicineFees", MedicineFees);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);

                        connection.Open();
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
        public static int AddNewMedicine(string MedicineName,decimal MedicineFees, bool IsActive)
        {
            int SpecialtyID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            Medicines(MedicineName,MedicineFees,IsActive)
                            Values(@MedicineName,@MedicineFees,@IsActive)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"MedicineName", MedicineName);
                        command.Parameters.AddWithValue(@"MedicineFees", MedicineFees);
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
        public static bool UpdateStatus(int MedicineID,bool IsActive)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update Medicines 
                                     Set IsActive=@IsActive
                            Where MedicineID=@MedicineID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"MedicineID", MedicineID);
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
        public static bool GetByMedicineID(int MedicineID, ref string MedicineName,ref decimal MedicineFees,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Medicines 
                            Where MedicineID=@MedicineID ";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"MedicineID", MedicineID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MedicineName = Convert.ToString(reader["MedicineName"]);
                                MedicineFees = Convert.ToDecimal(reader["MedicineFees"]);
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
        public static DataTable GetAllMedicines()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Medicines 
                            Order by MedicineName";
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

        public static bool IsMedicineExist(string MedicineName)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find =1  from Medicines 
                            Where MedicineName=@MedicineName";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"MedicineName", MedicineName);

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

    }
}
