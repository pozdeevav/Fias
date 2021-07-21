using Fias_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fias_Service.Repositories
{
    public class GetRootRepository : IGetRootRepository
    {
        public Dictionary<int, ADDROBJModel> GetRoot(string Division)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, ADDROBJModel> roots = new Dictionary<int, ADDROBJModel>(200);

                string CommandText = "select * from ADDROBJ where PARENTGUID is NULL and NEXTID is NULL and ACTSTATUS = " + Division + " order by FORMALNAME";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    roots.Add(j, new ADDROBJModel
                    {
                        AOID = Convert.ToString(sqlDataReader.GetValue(i)),
                        AOGUID = Convert.ToString(sqlDataReader.GetValue(i + 1)),
                        PARENTGUID = Convert.ToString(sqlDataReader.GetValue(i + 2)),
                        PREVID = Convert.ToString(sqlDataReader.GetValue(i + 3)),
                        NEXTID = Convert.ToString(sqlDataReader.GetValue(i + 4)),
                        FORMALNAME = Convert.ToString(sqlDataReader.GetValue(i + 5)),
                        OFFNAME = Convert.ToString(sqlDataReader.GetValue(i + 6)),
                        SHORTNAME = Convert.ToString(sqlDataReader.GetValue(i + 7)),
                        AOLEVEL = Convert.ToInt32(sqlDataReader.GetValue(i + 8)),
                        REGIONCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 9)),
                        AREACODE = Convert.ToInt32(sqlDataReader.GetValue(i + 10)),
                        AUTOCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 11)),
                        CITYCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 12)),
                        CTARCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 13)),
                        PLACECODE = Convert.ToInt32(sqlDataReader.GetValue(i + 14)),
                        PLANCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 15)),
                        STREETCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 16)),
                        EXTRCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 17)),
                        SEXTCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 18)),
                        PLAINCODE = Convert.ToString(sqlDataReader.GetValue(i + 19)),
                        CODE = Convert.ToString(sqlDataReader.GetValue(i + 20)),
                        CURRSTATUS = Convert.ToInt32(sqlDataReader.GetValue(i + 21)),
                        ACTSTATUS = Convert.ToInt32(sqlDataReader.GetValue(i + 22)),
                        LIVESTATUS = Convert.ToInt32(sqlDataReader.GetValue(i + 23)),
                        CENTSTATUS = Convert.ToInt32(sqlDataReader.GetValue(i + 24)),
                        OPERSTATUS = Convert.ToInt32(sqlDataReader.GetValue(i + 25)),
                        IFNSFL = Convert.ToInt32(sqlDataReader.GetValue(i + 26)),
                        IFNSUL = Convert.ToInt32(sqlDataReader.GetValue(i + 27)),
                        OKATO = sqlDataReader.GetValue(i + 28).ToString(),
                        OKTMO = sqlDataReader.GetValue(i + 29).ToString(),
                        POSTALCODE = Convert.ToInt32(sqlDataReader.GetValue(i + 30)),
                        STARTDATE = Convert.ToDateTime(sqlDataReader.GetValue(i + 31)),
                        ENDDATE = Convert.ToDateTime(sqlDataReader.GetValue(i + 32)),
                        UPDATEDATE = Convert.ToDateTime(sqlDataReader.GetValue(i + 33)),
                        DIVTYPE = Convert.ToInt32(sqlDataReader.GetValue(i + 34)),
                        NORMDOC = Convert.ToString(sqlDataReader.GetValue(i + 35)),
                        TERRIFNSFL = Convert.ToInt32(sqlDataReader.GetValue(i + 36)),
                        TERRIFNSUL = Convert.ToInt32(sqlDataReader.GetValue(i + 37))
                    });

                    j++;
                }

                sqlDataReader.Close();

                return roots;
            }
        }
    }
}
