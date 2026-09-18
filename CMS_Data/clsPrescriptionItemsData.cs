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
    public class clsPrescriptionItemsData
    {
        
        public static bool UpdatePrescriptionItems(int PrescriptionItemID, int ConsultationID, int MedicineID,
                                          string SpecialInstructions,byte? Duration,string DurationUnit,string Dosage,decimal PaidFees
                                          )
        {
            int EfferctedRow = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"UPDATE PrescriptionItems 
                            Set ConsultationID=@ConsultationID,MedicineID=@MedicineID,SpecialInstructions=@SpecialInstructions,Duration=@Duration,DurationUnit=@DurationUnit,Dosage=@Dosage,
                                   PaidFees=@PaidFees
                            Where PrescriptionItemID=@PrescriptionItemID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PrescriptionItemID", PrescriptionItemID);
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);
                        command.Parameters.AddWithValue(@"MedicineID", MedicineID);
                        command.Parameters.AddWithValue(@"PaidFees", PaidFees);
                        if (!string.IsNullOrEmpty(SpecialInstructions))
                        {
                            command.Parameters.AddWithValue(@"SpecialInstructions", SpecialInstructions);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"SpecialInstructions", DBNull.Value);

                        }
                        if (!string.IsNullOrEmpty(Dosage))
                        {
                            command.Parameters.AddWithValue(@"Dosage", Dosage);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Dosage", DBNull.Value);

                        }
                        if (Duration != null)
                        {
                            command.Parameters.AddWithValue(@"Duration", Duration);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Duration", DBNull.Value);

                        }
                        if (!string.IsNullOrEmpty(DurationUnit))
                        {
                            command.Parameters.AddWithValue(@"DurationUnit", DurationUnit);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"DurationUnit", DBNull.Value);

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
        public static int AddNewPrescriptionItems(int ConsultationID, int MedicineID,
                                          string SpecialInstructions, byte? Duration, string DurationUnit, string Dosage, decimal PaidFees,
                                          DateTime CreatedDate, int CreatedByUserID,bool IsActive)
        {
            int NewPrescriptionItem = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"INSERT INTO 
                            PrescriptionItems(ConsultationID,MedicineID,Duration,
                                   DurationUnit,Dosage,PaidFees,SpecialInstructions,CreatedByUserID,CreatedDate,IsActive)
                            Values(@ConsultationID,@MedicineID,@Duration,@DurationUnit,
                                   @Dosage,@PaidFees,@SpecialInstructions,@CreatedByUserID,@CreatedDate,@IsActive)
                             Select Scope_Identity()";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);
                        command.Parameters.AddWithValue(@"MedicineID", MedicineID);
                        command.Parameters.AddWithValue(@"PaidFees", PaidFees);
                        if (!string.IsNullOrEmpty(SpecialInstructions))
                        {
                            command.Parameters.AddWithValue(@"SpecialInstructions", SpecialInstructions);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"SpecialInstructions", DBNull.Value);

                        }
                        if (!string.IsNullOrEmpty(Dosage))
                        {
                            command.Parameters.AddWithValue(@"Dosage", Dosage);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Dosage", DBNull.Value);

                        }
                        if (!string.IsNullOrEmpty(DurationUnit))
                        {
                            command.Parameters.AddWithValue(@"DurationUnit", DurationUnit);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"DurationUnit", DBNull.Value);

                        }
                        if (Duration != null)
                        {
                            command.Parameters.AddWithValue(@"Duration", Duration);

                        }
                        else
                        {
                            command.Parameters.AddWithValue(@"Duration", DBNull.Value);

                        }
                        command.Parameters.AddWithValue(@"CreatedDate", CreatedDate);
                        command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue(@"IsActive", IsActive);


                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            NewPrescriptionItem = insertedID;
                        }
                    }
                }
            }
            catch
            {

            }
           
            return NewPrescriptionItem;
        }
        public static bool Deactive(int PrescriptionItemID)
        {
            bool IsDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Update PrescriptionItems 
                             Set IsActive=0
                            Where PrescriptionItemID=@PrescriptionItemID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PrescriptionItemID", PrescriptionItemID);

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

        public static DataTable GetActivePrescriptionItemsByConsultationID(int ConsultationID )
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"SELECT PrescriptionItems.PrescriptionItemID, PrescriptionItems.ConsultationID, Medicines.MedicineName, PrescriptionItems.Duration, PrescriptionItems.DurationUnit, PrescriptionItems.Dosage, PrescriptionItems.PaidFees, 
                             PrescriptionItems.SpecialInstructions, PrescriptionItems.CreatedDate,PrescriptionItems.IsActive
                             FROM   PrescriptionItems INNER JOIN
                             Medicines ON PrescriptionItems.MedicineID = Medicines.MedicineID
                             Where ConsultationID=@ConsultationID";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);

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
        public static DataTable GetAllPrescriptionItemsByConsultationID(int ConsultationID )
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"SELECT PrescriptionItems.PrescriptionItemID, PrescriptionItems.ConsultationID, Medicines.MedicineName, PrescriptionItems.Duration, PrescriptionItems.DurationUnit, PrescriptionItems.Dosage, PrescriptionItems.PaidFees, 
                             PrescriptionItems.SpecialInstructions, PrescriptionItems.CreatedDate,PrescriptionItems.IsActive
                             FROM   PrescriptionItems INNER JOIN
                             Medicines ON PrescriptionItems.MedicineID = Medicines.MedicineID
                             Where ConsultationID=@ConsultationID";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);

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
        public static DataTable GetAllPrescriptionItems()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    string Query = @"SELECT PrescriptionItems.PrescriptionItemID, PrescriptionItems.ConsultationID, Medicines.MedicineName, PrescriptionItems.Duration, PrescriptionItems.DurationUnit, PrescriptionItems.Dosage, PrescriptionItems.PaidFees, 
                             PrescriptionItems.SpecialInstructions, PrescriptionItems.CreatedDate, PrescriptionItems.IsActive
                             FROM   Medicines INNER JOIN
                             PrescriptionItems ON Medicines.MedicineID = PrescriptionItems.MedicineID";

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
        public static bool GetByPrescriptionItemID(int PrescriptionItemID,ref int ConsultationID,ref int MedicineID,
                                          ref string SpecialInstructions,ref byte? Duration,ref string DurationUnit, ref string Dosage,ref decimal PaidFees,
                                          ref DateTime CreatedDate,ref int CreatedByUserID,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select Top 1 * from PrescriptionItems 
                            Where PrescriptionItemID=@PrescriptionItemID order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"PrescriptionItemID", PrescriptionItemID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ConsultationID = Convert.ToInt32(reader["ConsultationID"]);
                                MedicineID = Convert.ToInt32(reader["MedicineID"]);


                                DurationUnit = (reader["DurationUnit"] != DBNull.Value) ? Convert.ToString(reader["DurationUnit"]) : null;
                                Dosage = (reader["Dosage"] != DBNull.Value) ? Convert.ToString(reader["Dosage"]) : null;
                                SpecialInstructions = (reader["SpecialInstructions"] != DBNull.Value) ? Convert.ToString(reader["SpecialInstructions"]) : null;

                                if (reader["Duration"] != DBNull.Value)
                                {
                                    Duration = Convert.ToByte(reader["Duration"]);
                                }
                                else
                                {
                                    Duration = null;
                                }


                                PaidFees = Convert.ToDecimal(reader["PaidFees"]);
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
        public static bool GetByConsultationID(int ConsultationID, ref int PrescriptionItemID, ref int MedicineID,
                                          ref string SpecialInstructions, ref byte? Duration, ref string DurationUnit, ref string Dosage, ref decimal PaidFees,
                                          ref DateTime CreatedDate, ref int CreatedByUserID,ref bool IsActive)
        {
            bool IsFind = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    string Query = @"Select top 1 * from Consultations 
                            Where ConsultationID=@ConsultationID order by CreatedDate desc";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue(@"ConsultationID", ConsultationID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PrescriptionItemID = Convert.ToInt32(reader["PrescriptionItemID"]);
                                MedicineID = Convert.ToInt32(reader["MedicineID"]);

                                DurationUnit = (reader["DurationUnit"] != DBNull.Value) ? Convert.ToString(reader["DurationUnit"]) : null;
                                Dosage = (reader["Dosage"] != DBNull.Value) ? Convert.ToString(reader["Dosage"]) : null;
                                SpecialInstructions = (reader["SpecialInstructions"] != DBNull.Value) ? Convert.ToString(reader["SpecialInstructions"]) : null;

                                if (reader["Duration"] != DBNull.Value)
                                {
                                    Duration = Convert.ToByte(reader["Duration"]);
                                }
                                else
                                {
                                    Duration = null;
                                }
                                PaidFees = Convert.ToDecimal(reader["PaidFees"]);
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

    }
}
