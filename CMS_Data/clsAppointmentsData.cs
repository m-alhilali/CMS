using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    public class clsAppointmentsData
    {


        public static bool UpdateAppointment(int AppointmentID, int DoctorID, int PatientID,
                                            int AppointmentTypeID, int AppointmentStatus,
                                            DateTime AppointmentDate, DateTime LastStatusDate,
                                            decimal AppointmentFees)
        {
            int EfferctedRow = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                { 
                    connection.Open();
                    string Query = @"UPDATE Appointments 
                            Set DoctorID=@DoctorID,PatientID=@PatientID,
                                AppointmentTypeID=@AppointmentTypeID,
                                AppointmentStatus=@AppointmentStatus,
                                AppointmentDate=@AppointmentDate,
                                LastStatusDate=@LastStatusDate,
                                AppointmentFees=@AppointmentFees
                                   
                            Where AppointmentID=@AppointmentID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentID", AppointmentID);
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        command.Parameters.AddWithValue(@"PatientID", PatientID);
                        command.Parameters.AddWithValue(@"AppointmentTypeID", AppointmentTypeID);
                        command.Parameters.AddWithValue(@"AppointmentStatus", AppointmentStatus);
                        command.Parameters.AddWithValue(@"AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue(@"LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue(@"AppointmentFees", AppointmentFees);

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
        public static int AddNewAppointment(int DoctorID, int PatientID,
                                            int AppointmentTypeID, int AppointmentStatus,
                                            DateTime AppointmentDate, DateTime LastStatusDate, DateTime CreatedDate,
                                            decimal AppointmentFees, int CreatedByUserID)
        {
            int NewAppointmentID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"
                            Update Patients
                            Set IsActive=1
                            Where PatientID=@PatientID;

                            INSERT INTO 
                            Appointments(DoctorID,PatientID,AppointmentTypeID,
                                   AppointmentStatus,AppointmentDate,LastStatusDate,
                                   CreatedDate,AppointmentFees,CreatedByUserID)
                            Values(@DoctorID,@PatientID,@AppointmentTypeID,
                                   @AppointmentStatus,@AppointmentDate,@LastStatusDate,
                                   @CreatedDate,@AppointmentFees,@CreatedByUserID)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        command.Parameters.AddWithValue(@"PatientID", PatientID);
                        command.Parameters.AddWithValue(@"AppointmentTypeID", AppointmentTypeID);
                        command.Parameters.AddWithValue(@"AppointmentStatus", AppointmentStatus);
                        command.Parameters.AddWithValue(@"AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue(@"LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue(@"CreatedDate", CreatedDate);
                        command.Parameters.AddWithValue(@"AppointmentFees", AppointmentFees);
                        command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            NewAppointmentID = insertedID;
                        }
                    }
                }

            }
            catch
            {

            }
            
            return NewAppointmentID;
        }
        public static bool CheckIsExpiredAnyAppointment()
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update Appointments
                             Set AppointmentStatus=4 ,LastStatusDate=GetDate()
                             Where DATEADD(MINUTE,30,Appointments.AppointmentDate)<GetDAte() And AppointmentStatus=1 ;

                             Update Patients
                             Set IsActive=0
                             Where PatientID not in (Select PatientID From Appointments Where AppointmentStatus=1)
                              ";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        int reader = command.ExecuteNonQuery();
                        IsFind = reader > 0;
                    }
                }
            }
            catch
            {
                IsFind = false;
            }
            return IsFind;
        }
        public static bool ChangeStatus(int AppointmentID,int AppointmentStatus)
        {
            bool IsDeleted = false;

            try {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                { 
                    connection.Open();
                    string Query = @"Update Appointments 
                             Set AppointmentStatus=@AppointmentStatus,LastStatusDate=GetDate()
                            Where AppointmentID=@AppointmentID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentID", AppointmentID);
                        command.Parameters.AddWithValue(@"AppointmentStatus", AppointmentStatus);

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
        public static DataTable GetAppointmentsListByPatientID(int PatientID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Appointments 
                             Where PatientID=@PatientID
                            Order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PatientID", PatientID);

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
        public static DataTable GetAllAppointmentsListByDoctorID(int DoctorID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Appointments 
                             Where DoctorID=@DoctorID
                            Order by CreatedDate desc";
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
        public static bool IsHaveAnActiveAppointmentInThisTime(int DoctorID,DateTime AppointmentDate)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Find=1 from Appointments 
                             Where DoctorID=@DoctorID and AppointmentDate=@AppointmentDate and AppointmentStatus=1
                             ";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);
                        command.Parameters.AddWithValue(@"AppointmentDate", AppointmentDate);

                        object result = command.ExecuteScalar();
                        IsFind = Convert.ToInt16(result) > 0;
                    }

                }
            }
            catch
            {
                IsFind = false;
            }
            return IsFind;
        }
        public static DataTable GetActiveAppointmentsByDoctorID(int DoctorID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Appointments 
                             Where DoctorID=@DoctorID and AppointmentStatus=1
                             Order by CreatedDate desc";
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
        public static DataTable GetAllAppointments()
        {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select * from Appointments_View 
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
        public static bool GetByAppointmentID(int AppointmentID,ref int DoctorID, ref int PatientID,
                                           ref int AppointmentTypeID, ref int AppointmentStatus,
                                           ref DateTime AppointmentDate, ref DateTime LastStatusDate, ref DateTime CreatedDate,
                                           ref decimal AppointmentFees, ref int CreatedByUserID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select top 1 * from Appointments 
                            Where AppointmentID=@AppointmentID order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"AppointmentID", AppointmentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DoctorID = Convert.ToInt32(reader["DoctorID"]);
                                PatientID = Convert.ToInt32(reader["PatientID"]);
                                AppointmentTypeID = Convert.ToInt32(reader["AppointmentTypeID"]);
                                AppointmentStatus = Convert.ToInt32(reader["AppointmentStatus"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                AppointmentFees = Convert.ToDecimal(reader["AppointmentFees"]);
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                                LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
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
        public static bool GetByPatientID(int PatientID, ref int DoctorID, ref int AppointmentID,
                                           ref int AppointmentTypeID, ref int AppointmentStatus,
                                           ref DateTime AppointmentDate, ref DateTime LastStatusDate, ref DateTime CreatedDate,
                                           ref decimal AppointmentFees, ref int CreatedByUserID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select top 1 * from Appointments 
                            Where PatientID=@PatientID order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PatientID", PatientID);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DoctorID = Convert.ToInt32(reader["DoctorID"]);
                                AppointmentID = Convert.ToInt32(reader["AppointmentID"]);
                                AppointmentTypeID = Convert.ToInt32(reader["AppointmentTypeID"]);
                                AppointmentStatus = Convert.ToInt32(reader["AppointmentStatus"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                AppointmentFees = Convert.ToDecimal(reader["AppointmentFees"]);
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                                LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
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
        public static bool GetByDoctorID(int DoctorID, ref int AppointmentID, ref int PatientID,
                                           ref int AppointmentTypeID, ref int AppointmentStatus,
                                           ref DateTime AppointmentDate, ref DateTime LastStatusDate, ref DateTime CreatedDate,
                                           ref decimal AppointmentFees, ref int CreatedByUserID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select top 1 * from Appointments 
                            Where DoctorID=@DoctorID order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"DoctorID", DoctorID);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PatientID = Convert.ToInt32(reader["PatientID"]);
                                AppointmentID = Convert.ToInt32(reader["AppointmentID"]);
                                AppointmentTypeID = Convert.ToInt32(reader["AppointmentTypeID"]);
                                AppointmentStatus = Convert.ToInt32(reader["AppointmentStatus"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                AppointmentFees = Convert.ToDecimal(reader["AppointmentFees"]);
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                                LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
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
    }
}
