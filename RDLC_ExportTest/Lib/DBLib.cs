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
    public static class DBLib
    {
        public static List<RDLCTestModel> GetDatas(int dataCount)
        {
            var result = new List<RDLCTestModel>();
            try
            {
                string connectionString =
            "Data Source=192.168.100.81;Initial Catalog=PAYTPDB_PingTung;persist security info=True;user id=sa;password=html5!its;MultipleActiveResultSets=True;TrustServerCertificate=True;";

                string queryString =
                $"SELECT TOP(@count)  [ListID] ,[AccountNo] ,[Amount]," +
                $"[ChannelID],[TradeNo],[ShortName],[ParkingLotID],[PaymentID]," +
                $"[DepartmentID],[DepartmentName],[HospitalID],[HospitalName]," +
                $"[PaymentDate] from TransactionLists ";

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
                            result.Add(new RDLCTestModel() {
                                ListID = reader[0].ToString(), 
                                AccountNo = reader[1].ToString(), 
                                Amount = decimal.Parse(reader[2].ToString()),
                            ChannelID = reader[3].ToString(),
                            TradeNo = reader[4].ToString(),
                            ShortName = reader[5].ToString(),
                            ParkingLotID = reader[6].ToString(),
                            PaymentID = reader[7].ToString(),
                            DepartmentID = reader[8].ToString(),
                            DepartmentName = reader[9].ToString(),
                            HospitalID = reader[10].ToString(),
                            HospitalName = reader[11].ToString(),
                            PaymentDate = reader[12].ToString()
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
