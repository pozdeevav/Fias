using Fias_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fias_Service.Repositories
{
    public class GetSteadRepository : IGetSteadRepository
    {
        public Dictionary<int, SteadModel> GetStead(string Parent)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, SteadModel> childs = new Dictionary<int, SteadModel>(200);

                string CommandText = "select * from STEAD where PARENTGUID = '" + Parent + "' order by NUMBER";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    childs.Add(j, new SteadModel
                    {
                        STEADGUID = Convert.ToString(sqlDataReader.GetValue(i)),
                        NUMBER = Convert.ToString(sqlDataReader.GetValue(i + 1)),
                        REGIONCODE = Convert.ToString(sqlDataReader.GetValue(i + 2)),
                        POSTALCODE = Convert.ToString(sqlDataReader.GetValue(i + 3)),
                        IFNSFL = Convert.ToString(sqlDataReader.GetValue(i + 4)),
                        IFNSUL = Convert.ToString(sqlDataReader.GetValue(i + 5)),
                        TERRIFNSFL = Convert.ToString(sqlDataReader.GetValue(i + 6)),
                        TERRIFNSUL = Convert.ToString(sqlDataReader.GetValue(i + 7)),
                        OKATO = Convert.ToString(sqlDataReader.GetValue(i + 8)),
                        UPDATEDATE = Convert.ToString(sqlDataReader.GetValue(i + 9)),
                        PARENTGUID = Convert.ToString(sqlDataReader.GetValue(i + 10)),
                        STEADID = Convert.ToString(sqlDataReader.GetValue(i + 11)),
                        OPERSTATUS = Convert.ToString(sqlDataReader.GetValue(i + 12)),
                        STARTDATE = Convert.ToString(sqlDataReader.GetValue(i + 13)),
                        ENDDATE = Convert.ToString(sqlDataReader.GetValue(i + 14)),
                        OKTMO = Convert.ToString(sqlDataReader.GetValue(i + 15)),
                        LIVESTATUS = Convert.ToString(sqlDataReader.GetValue(i + 16)),
                        CADNUM = Convert.ToString(sqlDataReader.GetValue(i + 17)),
                        DIVTYPE = Convert.ToString(sqlDataReader.GetValue(i + 18)),
                        NORMDOC = Convert.ToString(sqlDataReader.GetValue(i + 19))
                    });

                    j++;
                }

                sqlDataReader.Close();

                return childs;
            }
        }
    }
}
