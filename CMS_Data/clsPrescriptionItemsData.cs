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
                    using (SqlCommand command = new SqlCommand("SP_UpdatePrescriptionItems", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"ConsultationID", SqlDbType.Int).Value = ConsultationID;
                        command.Parameters.Add(@"MedicineID", SqlDbType.Int).Value = MedicineID;
                        command.Parameters.Add(@"PaidFees", SqlDbType.SmallMoney).Value = PaidFees;

                        if (!string.IsNullOrEmpty(SpecialInstructions))
                        {
                            command.Parameters.Add(@"SpecialInstructions", SqlDbType.NVarChar, 300).Value = SpecialInstructions;

                        }
                        else
                        {
                            command.Parameters.Add(@"SpecialInstructions", SqlDbType.NVarChar, 300).Value = DBNull.Value;

                        }

                        if (!string.IsNullOrEmpty(Dosage))
                        {
                            command.Parameters.Add(@"Dosage", SqlDbType.NVarChar, 100).Value = Dosage;
                        }
                        else
                        {
                            command.Parameters.Add(@"Dosage", SqlDbType.NVarChar, 100).Value = DBNull.Value;

                        }

                        if (!string.IsNullOrEmpty(DurationUnit))
                        {
                            command.Parameters.Add(@"DurationUnit", SqlDbType.NVarChar, 50).Value = DurationUnit;

                        }
                        else
                        {
                            command.Parameters.Add(@"DurationUnit", SqlDbType.NVarChar, 50).Value = DBNull.Value;

                        }

                        if (Duration != null)
                        {
                            command.Parameters.Add(@"Duration", SqlDbType.TinyInt).Value = Duration;

                        }
                        else
                        {
                            command.Parameters.Add(@"Duration", SqlDbType.TinyInt).Value = DBNull.Value;

                        }

                        EfferctedRow = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return EfferctedRow > 0;
        }
        public static int AddNewPrescriptionItems(int ConsultationID, int MedicineID,
                                          string SpecialInstructions, byte? Duration, string DurationUnit, string Dosage, decimal PaidFees,
                                          DateTime CreatedDate, int CreatedByUserID,bool IsActive)
        {
            int PrescriptionItemID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSittings.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewPrescriptionItems", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"ConsultationID", SqlDbType.Int).Value= ConsultationID;
                        command.Parameters.Add(@"MedicineID", SqlDbType.Int).Value= MedicineID;
                        command.Parameters.Add(@"PaidFees", SqlDbType.SmallMoney).Value= PaidFees;

                        if (!string.IsNullOrEmpty(SpecialInstructions))
                        {
                            command.Parameters.Add(@"SpecialInstructions", SqlDbType.NVarChar,300).Value=SpecialInstructions;

                        }
                        else
                        {
                            command.Parameters.Add(@"SpecialInstructions", SqlDbType.NVarChar, 300).Value = DBNull.Value;

                        }

                        if (!string.IsNullOrEmpty(Dosage))
                        {
                            command.Parameters.Add(@"Dosage", SqlDbType.NVarChar, 100).Value = Dosage;
                        }
                        else
                        {
                            command.Parameters.Add(@"Dosage", SqlDbType.NVarChar, 100).Value = DBNull.Value;

                        }

                        if (!string.IsNullOrEmpty(DurationUnit))
                        {
                            command.Parameters.Add(@"DurationUnit", SqlDbType.NVarChar, 50).Value = DurationUnit;

                        }
                        else
                        {
                            command.Parameters.Add(@"DurationUnit", SqlDbType.NVarChar, 50).Value = DBNull.Value;

                        }

                        if (Duration != null)
                        {
                            command.Parameters.Add(@"Duration", SqlDbType.TinyInt).Value = Duration;

                        }
                        else
                        {
                            command.Parameters.Add(@"Duration", SqlDbType.TinyInt).Value = DBNull.Value;

                        }

                        command.Parameters.Add(@"CreatedDate",SqlDbType.DateTime).Value = CreatedDate;
                        command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                        command.Parameters.Add(@"IsActive", SqlDbType.Bit).Value = IsActive;

                        SqlParameter parameter = command.Parameters.Add(@"PrescriptionItemID", SqlDbType.Int);
                        parameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        if (parameter.Value!=null && parameter.Value!=DBNull.Value&&int.TryParse(parameter.Value?.ToString(),out int newID))
                        {
                            PrescriptionItemID = newID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return PrescriptionItemID;
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
            catch(Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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
                    using (SqlCommand command = new SqlCommand("SP_GetActivePrescriptionItemsByConsultationID", connection))
                    {
                        command.CommandType=CommandType.StoredProcedure;
                        command.Parameters.Add(@"ConsultationID",SqlDbType.Int).Value= ConsultationID;

                        using (SqlDataAdapter data = new SqlDataAdapter(command))
                        {
                            data.Fill(dt);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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
                    using (SqlCommand command = new SqlCommand("SP_GetAllPrescriptionItemsByConsultationID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"ConsultationID", SqlDbType.Int).Value = ConsultationID;

                        using (SqlDataAdapter data = new SqlDataAdapter(command))
                        {
                            data.Fill(dt);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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

                    using (SqlCommand command = new SqlCommand("SP_GetAllPrescriptionItems", connection))
                    {
                        connection.Open();
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
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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
                    
                    using (SqlCommand command = new SqlCommand("SP_GetByPrescriptionItemID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"PrescriptionItemID",SqlDbType.Int).Value= PrescriptionItemID;

                        SqlParameter ConsultationIDparameter = command.Parameters.Add(@"ConsultationID", SqlDbType.Int);
                        ConsultationIDparameter.Direction = ParameterDirection.Output;
                        SqlParameter MedicineIDparameter = command.Parameters.Add(@"MedicineID", SqlDbType.Int);
                        MedicineIDparameter.Direction = ParameterDirection.Output;
                        SqlParameter SpecialInstructionsparameter = command.Parameters.Add(@"SpecialInstructions", SqlDbType.NVarChar,300);
                        SpecialInstructionsparameter.Direction = ParameterDirection.Output;
                        SqlParameter Durationparameter = command.Parameters.Add(@"Duration", SqlDbType.TinyInt);
                        Durationparameter.Direction = ParameterDirection.Output;
                        SqlParameter DurationUnitparameter = command.Parameters.Add(@"DurationUnit", SqlDbType.NVarChar,50);
                        DurationUnitparameter.Direction = ParameterDirection.Output;
                        SqlParameter PaidFeesparameter = command.Parameters.Add(@"PaidFees", SqlDbType.SmallMoney);
                        PaidFeesparameter.Direction = ParameterDirection.Output;
                        SqlParameter CreatedDateparameter = command.Parameters.Add(@"CreatedDate", SqlDbType.DateTime);
                        CreatedDateparameter.Direction = ParameterDirection.Output;
                        SqlParameter CreatedByUserIDparameter = command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int);
                        CreatedByUserIDparameter.Direction = ParameterDirection.Output;
                        SqlParameter Dosageparameter = command.Parameters.Add(@"Dosage", SqlDbType.NVarChar,100);
                        Dosageparameter.Direction = ParameterDirection.Output;
                        SqlParameter IsActiveparameter = command.Parameters.Add(@"IsActive", SqlDbType.Bit);
                        IsActiveparameter.Direction = ParameterDirection.Output;
                        int IsFound = 0;
                        SqlParameter IsFoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        IsFoundparameter.Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        if (IsFound==1)
                        {
                            ConsultationID = Convert.ToInt32(ConsultationIDparameter.Value);
                            MedicineID = Convert.ToInt32(MedicineIDparameter.Value);


                            DurationUnit = (DurationUnitparameter.Value != DBNull.Value) ? Convert.ToString(DurationUnitparameter.Value) : null;
                            Dosage = (Dosageparameter.Value != DBNull.Value) ? Convert.ToString(Dosageparameter.Value) : null;
                            SpecialInstructions = (SpecialInstructionsparameter.Value != DBNull.Value) ? Convert.ToString(SpecialInstructionsparameter.Value) : null;

                            if (Durationparameter.Value != DBNull.Value)
                            {
                                Duration = Convert.ToByte(Durationparameter.Value);
                            }
                            else
                            {
                                Duration = null;
                            }

                            PaidFees = Convert.ToDecimal(PaidFeesparameter.Value);
                            CreatedByUserID = Convert.ToInt32(CreatedByUserIDparameter.Value);
                            CreatedDate = Convert.ToDateTime(CreatedDateparameter.Value);
                            IsActive = Convert.ToBoolean(IsActiveparameter.Value);
                            IsFind = true;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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

                    using (SqlCommand command = new SqlCommand("SP_GetByConsultationID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(@"ConsultationID", SqlDbType.Int).Value = ConsultationID;

                        SqlParameter ConsultationIDparameter = command.Parameters.Add(@"PrescriptionItemID", SqlDbType.Int);
                        ConsultationIDparameter.Direction = ParameterDirection.Output;
                        SqlParameter MedicineIDparameter = command.Parameters.Add(@"MedicineID", SqlDbType.Int);
                        MedicineIDparameter.Direction = ParameterDirection.Output;
                        SqlParameter SpecialInstructionsparameter = command.Parameters.Add(@"SpecialInstructions", SqlDbType.NVarChar, 300);
                        SpecialInstructionsparameter.Direction = ParameterDirection.Output;
                        SqlParameter Durationparameter = command.Parameters.Add(@"Duration", SqlDbType.TinyInt);
                        Durationparameter.Direction = ParameterDirection.Output;
                        SqlParameter DurationUnitparameter = command.Parameters.Add(@"DurationUnit", SqlDbType.NVarChar, 50);
                        DurationUnitparameter.Direction = ParameterDirection.Output;
                        SqlParameter PaidFeesparameter = command.Parameters.Add(@"PaidFees", SqlDbType.SmallMoney);
                        PaidFeesparameter.Direction = ParameterDirection.Output;
                        SqlParameter CreatedDateparameter = command.Parameters.Add(@"CreatedDate", SqlDbType.DateTime);
                        CreatedDateparameter.Direction = ParameterDirection.Output;
                        SqlParameter CreatedByUserIDparameter = command.Parameters.Add(@"CreatedByUserID", SqlDbType.Int);
                        CreatedByUserIDparameter.Direction = ParameterDirection.Output;
                        SqlParameter Dosageparameter = command.Parameters.Add(@"Dosage", SqlDbType.NVarChar, 100);
                        Dosageparameter.Direction = ParameterDirection.Output;
                        SqlParameter IsActiveparameter = command.Parameters.Add(@"IsActive", SqlDbType.Bit);
                        IsActiveparameter.Direction = ParameterDirection.Output;
                        int IsFound = 0;
                        SqlParameter IsFoundparameter = command.Parameters.Add(@"IsFound", SqlDbType.Int);
                        IsFoundparameter.Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        if (IsFound == 1)
                        {
                            ConsultationID = Convert.ToInt32(ConsultationIDparameter.Value);
                            MedicineID = Convert.ToInt32(MedicineIDparameter.Value);


                            DurationUnit = (DurationUnitparameter.Value != DBNull.Value) ? Convert.ToString(DurationUnitparameter.Value) : null;
                            Dosage = (Dosageparameter.Value != DBNull.Value) ? Convert.ToString(Dosageparameter.Value) : null;
                            SpecialInstructions = (SpecialInstructionsparameter.Value != DBNull.Value) ? Convert.ToString(SpecialInstructionsparameter.Value) : null;

                            if (Durationparameter.Value != DBNull.Value)
                            {
                                Duration = Convert.ToByte(Durationparameter.Value);
                            }
                            else
                            {
                                Duration = null;
                            }

                            PaidFees = Convert.ToDecimal(PaidFeesparameter.Value);
                            CreatedByUserID = Convert.ToInt32(CreatedByUserIDparameter.Value);
                            CreatedDate = Convert.ToDateTime(CreatedDateparameter.Value);
                            IsActive = Convert.ToBoolean(IsActiveparameter.Value);
                            IsFind = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.TypeErrorInViwerLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return IsFind;
        }

    }
}
