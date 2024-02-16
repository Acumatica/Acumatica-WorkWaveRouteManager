using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Log;
using WorkWaveIntegrationQA.Tests.Entity;

namespace WorkWaveIntegrationQA.Tests.Helpers
{
    public class SQLHelper
    {
        public List<CarrierLabelHistoryDetails> GetCarrierLabelHistory()
        {
            Log.Information("Get the Carrier Label History data");
            List<CarrierLabelHistoryDetails> results = new List<CarrierLabelHistoryDetails>();
            var connectionSettings = JsonFileHelper.Read<JsonSettings>();
            var connectionString = connectionSettings.ConnectionStrings["MSSQLServer"];
            Log.Information($"Connection String: {connectionString}");
            SqlConnection conn = new SqlConnection($"{connectionString}");
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT CompanyID, RecordID, ShipmentNbr, LineNbr, PluginTypeName, ServiceMethod, RateAmount, " +
                                                "CreatedByID, CreatedByScreenID, CreatedDateTime, UsrCarrier FROM CarrierLabelHistory;", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CarrierLabelHistoryDetails record = new CarrierLabelHistoryDetails()
                    {
                        CompanyID = reader.GetInt32(0),
                        RecordID = reader.GetInt32(1),
                        ShipmentNbr = reader.GetString(2),
                        LineNbr = reader.GetInt32(3),
                        PluginTypeName = reader.GetString(4),
                        ServiceMethod = reader.GetString(5),
                        RateAmount = reader.GetDecimal(6),
                        CreatedByID = reader.GetGuid(7),
                        CreatedByScreenID = reader.GetString(8),
                        CreatedDateTime = reader.GetDateTime(9),
                        UsrCarrier = reader.GetString(10),
                    };
                    results.Add(record);
                }
            }

            conn.Close();
            return results;
        }
    }
}
