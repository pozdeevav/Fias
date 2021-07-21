using Fias_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fias_Service.Repositories
{
    public class GetHouseRepository : IGetHouseRepository
    {
        public Dictionary<int, HouseModel> GetHouse(string Parent)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, HouseModel> childs = new Dictionary<int, HouseModel>();

                string CommandText = "select * from HOUSE where AOGUID = '" + Parent + "' order by HOUSENUM";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    childs.Add(j, new HouseModel
                    {
                        HOUSEID = Convert.ToString(sqlDataReader.GetValue(i)),
                        HOUSEGUID = Convert.ToString(sqlDataReader.GetValue(i + 1)),
                        AOGUID = Convert.ToString(sqlDataReader.GetValue(i + 2)),
                        HOUSENUM = Convert.ToString(sqlDataReader.GetValue(i + 3)),
                        STRSTATUS = Convert.ToString(sqlDataReader.GetValue(i + 4)),
                        ESTSTATUS = Convert.ToString(sqlDataReader.GetValue(i + 5)),
                        STATSTATUS = Convert.ToString(sqlDataReader.GetValue(i + 6)),
                        IFNSFL = Convert.ToString(sqlDataReader.GetValue(i + 7)),
                        IFNSUL = Convert.ToString(sqlDataReader.GetValue(i + 8)),
                        TERRIFNSUL = Convert.ToString(sqlDataReader.GetValue(i + 9)),
                        OKATO = Convert.ToString(sqlDataReader.GetValue(i + 10)),
                        OKTMO = Convert.ToString(sqlDataReader.GetValue(i + 11)),
                        POSTALCODE = Convert.ToString(sqlDataReader.GetValue(i + 12)),
                        STARTDATE = Convert.ToString(sqlDataReader.GetValue(i + 13)),
                        ENDDATE = Convert.ToString(sqlDataReader.GetValue(i+14)),
                        UPDATEDATE = Convert.ToString(sqlDataReader.GetValue(i + 15)),
                        COUNTER = Convert.ToString(sqlDataReader.GetValue(i + 16)),
                        DIVTYPE = Convert.ToString(sqlDataReader.GetValue(i + 17)),
                        REGIONCODE = Convert.ToString(sqlDataReader.GetValue(i + 18)),
                        BUILDNUM = Convert.ToString(sqlDataReader.GetValue(i + 19)),
                        STRUCNUM = Convert.ToString(sqlDataReader.GetValue(i + 20)),
                        NORMDOC = Convert.ToString(sqlDataReader.GetValue(i + 21)),
                        CADNUM = Convert.ToString(sqlDataReader.GetValue(i + 22))
                    });

                    j++;
                }

                sqlDataReader.Close();

                return childs;
            }
        }
    }
}
