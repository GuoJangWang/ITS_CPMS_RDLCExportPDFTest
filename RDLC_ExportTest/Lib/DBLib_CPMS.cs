using RDLC_ExportTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RDLC_ExportTest.Lib
{
    public static class DBLib_CPMS
    {
        public static List<RDLCTestModel_CPMS> GetDatas(int dataCount)
        {
            var result = new List<RDLCTestModel_CPMS>();
            try
            {
                string connectionString =
            "Data Source=192.168.100.221;Initial Catalog=CPMSDB;persist security info=True;user id=hncb;password=hncb;MultipleActiveResultSets=True;TrustServerCertificate=True;";

                #region Query
                string queryString =
                $"SELECT TOP (5000) [ControlSetId]" +
                $"      ,[ReportConfigId]" +
                $"     ,[ReportId]" +
                $"      ,[ReportName]" +
                $"      ,[Message]" +
                $"      ,[DueDateStart]" +
                $"      ,[DueDateEnd]     " +
                $" ,[ResultFileName]     " +
                $" ,[FileName]     " +
                $" FROM [CPMSDB].[dbo].[ReportControlSets] ";
                #endregion


                using (SqlConnection connection =
            new SqlConnection(connectionString))
                {
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@count", dataCount);

                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //Console.WriteLine("\t{0}\t{1}\t{2}",
                            //    reader[0], reader[1], reader[2]);

                            var item = new RDLCTestModel_CPMS();

                            item.ControlSetId = reader.IsDBNull(0)? null: reader?.GetInt64(0);

                            item.ReportConfigId = reader.IsDBNull(1)? null: reader?.GetInt32(1);
                            item.ReportId = reader.IsDBNull(2)? "": reader?.GetString(2);
                            item.ReportName = reader.IsDBNull(3) ? "": reader?.GetString(3);
                            item.Message = reader.IsDBNull(4)  ? "": reader?.GetString(4);
                            item.DueDateStart = reader.IsDBNull(5) ? DateTime.MinValue: reader.GetDateTime(5);
                            item.DueDateEnd = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(6);
                            item.ResultFileName = reader.IsDBNull(7)? "": reader?.GetString(7);
                            item.FileName = reader.IsDBNull(8)? "": reader?.GetString(8);


                            result.Add(item);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    //Console.ReadLine();
                }


            }
            catch (Exception e)
            {

                throw e;
            }
            return result;
        }
    }
}
