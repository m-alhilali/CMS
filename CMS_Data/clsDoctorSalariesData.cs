using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsDoctorSalariesData
    {
        
        public static int AddNewSalary(int DoctorID, decimal Salary, int CreatedByUserID, DateTime CreatedDate, DateTime StartDate,bool IsActive)
        {
            int SalaryID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"
                            UPDATE DoctorSalaries 
                            Set EndDate=GetDate(),IsActive=0
                            Where DoctorID=@DoctorID and IsActive=1;
                            
                            INSERT INTO 
                            DoctorSalaries
                            (
                                   DoctorID,
                                   Salary,
                                   CreatedByUserID,
                                   CreatedDate,
                                   StartDate,
                                   IsActive
                            )
                                   
                            Values
                            (
                                   @DoctorID,
                                   @Salary,
                                   @CreatedByUserID,
                                   @CreatedDate,
                                   @StartDate,
                                   1
                             )
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        command.Parameters.AddWithValue(@"Salary", Salary);
                        command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue(@"StartDate", StartDate);
                        command.Parameters.AddWithValue(@"CreatedDate", CreatedDate);
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            SalaryID = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
           
            return SalaryID;
        }
        public static bool GetByDoctorID(int DoctorID,ref int SalaryID,ref  decimal Salary,ref int CreatedByUserID,ref DateTime CreatedDate,ref DateTime StartDate,ref DateTime? EndDate,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {

                    string Query = @"Select Top 1 * from DoctorSalaries 
                            Where DoctorID=@DoctorID
                             Order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                SalaryID = Convert.ToInt32(reader["SalaryID"]);
                                Salary = Convert.ToDecimal(reader["Salary"]);
                                if (reader["EndDate"] != DBNull.Value)
                                    EndDate = Convert.ToDateTime(reader["EndDate"]);
                                else
                                    EndDate = null;

                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                StartDate = Convert.ToDateTime(reader["StartDate"]);
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
        public static decimal GetSalaryByDoctorID(int DoctorID)
        {
            decimal salary = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Top 1 Salary from DoctorSalaries 
                             Where DoctorID=@DoctorID
                             order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        object result = command.ExecuteScalar();
                        decimal.TryParse(result.ToString(), out salary);
                    }
                }
            }
            catch
            {

            }
           
            return salary;
        }
        public static DataTable GetDoctorSalariesByDoctorID(int DoctorID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select SalaryID,Salary,StartDate,EndDate,DoctorSalaries.CreatedDate,Users.UserName from DoctorSalaries join Users On Users.UserID=DoctorSalaries.CreatedByUserID
                             Where DoctorID=@DoctorID
                             order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
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
        public static DataTable GetAllDoctorSalaries()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"Select * from DoctorSalaries 
                            Order by SalaryID desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();
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
