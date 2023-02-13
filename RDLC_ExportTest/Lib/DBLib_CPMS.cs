using RDLC_ExportTest.Models;
using System;
using System.Collections.Generic;
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
            "Data Source=192.168.100.221;Initial Catalog=CPMSDB;persist security info=True;user id=cpms;password=cpms;MultipleActiveResultSets=True;TrustServerCertificate=True;";

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
                            result.Add(new RDLCTestModel_CPMS()
                            {
                                ControlSetId = reader.GetInt64(1)
,
                                ReportConfigId = reader.GetInt32(2)
,
                                ReportId = reader.GetString(3)
,
                                ReportName = reader.GetString(4)
,
                                Message = reader.GetString(5)
,
                                DueDateStart = reader.GetDateTime(6)
,
                                DueDateEnd = reader.GetDateTime(7)
,
                                ResultFileName = reader.GetString(8)
,
                                FileName = reader.GetString(9)
                            });
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
