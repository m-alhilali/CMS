using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsConsultationsData
    {
       

        public static bool UpdateConsultations(int ConsultationID, int AppointmentID, decimal AdditionalFees,
                                           string Diagnosis, string Notes)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UPDATE Consultations 
                            Set AppointmentID=@AppointmentID,AdditionalFees=@AdditionalFees,Diagnosis=@Diagnosis,Notes=@Notes
                            Where ConsultationID=@ConsultationID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentID", AppointmentID);
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);
                        command.Parameters.AddWithValue(@"AdditionalFees", AdditionalFees);
                        if (!string.IsNullOrEmpty(Diagnosis))
                        {
                            command.Parameters.AddWithValue(@"Diagnosis", Diagnosis);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Diagnosis", DBNull.Value);

                        }
                        if (!string.IsNullOrEmpty(Notes))
                        {
                            command.Parameters.AddWithValue(@"Notes", Notes);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Notes", DBNull.Value);

                        }
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
        public static int AddNewConsultations(int AppointmentID, decimal AdditionalFees,
                                           string Diagnosis, string Notes,
                                           DateTime ConsultationDate, int CreatedByUserID)
        {
            int ConsultationID = -1;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"
                            Update Appointments
                            set AppointmentStatus=2 ,LastStatusDate=GetDate()
                            Where AppointmentID=@AppointmentID;

                            INSERT INTO 
                            Consultations(AppointmentID,AdditionalFees,Diagnosis,
                                   Notes,ConsultationDate,CreatedByUserID)
                            Values(@AppointmentID,@AdditionalFees,@Diagnosis,
                                   @Notes,@ConsultationDate,@CreatedByUserID)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentID", AppointmentID);
                        command.Parameters.AddWithValue(@"AdditionalFees", AdditionalFees);
                        if (!string.IsNullOrEmpty(Diagnosis))
                        {
                            command.Parameters.AddWithValue(@"Diagnosis", Diagnosis);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Diagnosis", DBNull.Value);

                        }
                        if (!string.IsNullOrEmpty(Notes))
                        {
                            command.Parameters.AddWithValue(@"Notes", Notes);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Notes", DBNull.Value);

                        }
                        command.Parameters.AddWithValue(@"ConsultationDate", ConsultationDate);
                        command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ConsultationID = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
            return ConsultationID;
        }
        public static bool Delete(int ConsultationID)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UpdateStatus Consultations 
                            Where ConsultationID=@ConsultationID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);

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

        public static DataTable GetAllConsultationsListDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Consultations
                            Order by AppointmentID desc";
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
        public static DataTable GetAllConsultations()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Consultation_View 
                            Order by AppointmentID desc";
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
        public static bool GetByAppointmentID(int AppointmentID,ref int ConsultationID,ref decimal AdditionalFees,
                                           ref string Diagnosis,ref string Notes,
                                           ref DateTime ConsultationDate, ref int CreatedByUserID)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Top 1 * from Consultations 
                            Where AppointmentID=@AppointmentID order by ConsultationDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentID", AppointmentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ConsultationID = Convert.ToInt32(reader["ConsultationID"]);
                                AdditionalFees = Convert.ToInt32(reader["AdditionalFees"]);
                                if (reader["Diagnosis"] != DBNull.Value)
                                {
                                    Diagnosis = Convert.ToString(reader["Diagnosis"]);
                                }
                                else
                                {
                                    Diagnosis = "";
                                }
                                if (reader["Notes"] != DBNull.Value)
                                {
                                    Notes = Convert.ToString(reader["Notes"]);
                                }
                                else
                                {
                                    Notes = "";
                                }
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                ConsultationDate = Convert.ToDateTime(reader["ConsultationDate"]);
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
        public static bool GetByConsultationID(int ConsultationID, ref int AppointmentID, ref decimal AdditionalFees,
                                           ref string Diagnosis, ref string Notes,
                                           ref DateTime ConsultationDate, ref int CreatedByUserID)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select top 1 * from Consultations 
                            Where ConsultationID=@ConsultationID order by ConsultationDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AppointmentID = Convert.ToInt32(reader["AppointmentID"]);
                                AdditionalFees = Convert.ToDecimal(reader["AdditionalFees"]);
                                if (reader["Diagnosis"] != DBNull.Value)
                                {
                                    Diagnosis = Convert.ToString(reader["Diagnosis"]);
                                }
                                else
                                {
                                    Diagnosis = "";
                                }
                                if (reader["Notes"] != DBNull.Value)
                                {
                                    Notes = Convert.ToString(reader["Notes"]);
                                }
                                else
                                {
                                    Notes = "";
                                }
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                ConsultationDate = Convert.ToDateTime(reader["ConsultationDate"]);
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

    }
}
