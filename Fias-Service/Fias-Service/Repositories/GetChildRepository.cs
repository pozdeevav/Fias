using Fias_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fias_Service.Repositories
{
    public class GetChildRepository : IGetChildRepository
    {
        public Dictionary<int, ADDROBJModel> GetChild(string Parent, string Division, string AO)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, ADDROBJModel> childs = new Dictionary<int, ADDROBJModel>(200);

                string CommandText = "";

                if (AO == "3")
                {
                    CommandText = "select * from ADDROBJ where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and (AOLEVEL = " + AO + " or AOLEVEL = 4) order by FORMALNAME";
                }
                else if (AO == "4")
                {
                    CommandText = "select * from ADDROBJ where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and AOLEVEL = 4 order by FORMALNAME";
                }
                else if (AO == "46")
                {
                    CommandText = "select * from ADDROBJ where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and (AOLEVEL = 4 or AOLEVEL = 6) order by FORMALNAME";
                }
                else if (AO == "7")
                {
                    CommandText = "select * from ADDROBJ where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and AOLEVEL = 7 order by FORMALNAME";
                }
                else if (AO == "65")
                {
                    CommandText = "select * from ADDROBJ where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and (AOLEVEL = 65 or AOLEVEL = 91) order by FORMALNAME";
                }

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    childs.Add(j, new ADDROBJModel
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

                return childs;
            }
        }
    }
}
