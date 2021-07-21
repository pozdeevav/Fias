using FIASLibary.Models;
using FIASLibary.StandartModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public class FulltextSearchRepository : IFulltextSearchRepository
    {
        public string FulltextSearch(List<string> querys)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, FullnamesModel> addrobjs = new Dictionary<int, FullnamesModel>(10);

                string CommandText = "";

                if (querys.Count == 1)
                {
                    CommandText = "select TOP(10) AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_2 where CONTAINS(FULLNAME, '\"" + querys[0] + "\"')";
                }
                else if (querys.Count == 2)
                {
                    CommandText = "select TOP(10) AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_2 where CONTAINS(FULLNAME, '\"" + querys[0] + "\"') and CONTAINS(FULLNAME, '\"" + querys[1] + "\"')";
                }
                else if (querys.Count == 3)
                {
                    CommandText = "select TOP(10) AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_2 where CONTAINS(FULLNAME, '\"" + querys[0] + "\"') and CONTAINS(FULLNAME, '\"" + querys[1] + "\"') and CONTAINS(FULLNAME, '\"" + querys[2] + "\"')";
                }

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    addrobjs.Add(j, new FullnamesModel
                    {
                        AOGUID = Convert.ToString(sqlDataReader.GetValue(i)),
                        Fullname = Convert.ToString(sqlDataReader.GetValue(i+1))
                    });

                    j++;
                }

                sqlDataReader.Close();

                return JsonConvert.SerializeObject(addrobjs);
            }
        }

        public string FulltextSearchInfo(string query)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, ADDROBJModel> addrobjs = new Dictionary<int, ADDROBJModel>();

                string CommandText = "";

                CommandText = "select top(1) [FIAS_66].dbo.ADDROBJ.AOLEVEL,[FIAS_66].dbo.ADDROBJ.IFNSFL, [FIAS_66].dbo.ADDROBJ.IFNSUL, [FIAS_66].dbo.ADDROBJ.OKATO,[FIAS_66].dbo.ADDROBJ.OKTMO, [FIAS_66].dbo.ADDROBJ.POSTALCODE,[FIAS_66].dbo.ADDROBJ.AOGUID,[FIAS_66].dbo.ADDROBJ.ACTSTATUS,[FIAS_66].dbo.ADDROBJ.STARTDATE,[FIAS_66].dbo.ADDROBJ.UPDATEDATE, [FIAS_66].dbo.ADDROBJ.NORMDOC from [FIAS_66].dbo.ADDROBJ, [FIAS_66].dbo.ADDROBJ_2 where [FIAS_66].dbo.ADDROBJ.AOGUID = (select [FIAS_66].dbo.ADDROBJ_2.AOGUID from [FIAS_66].dbo.ADDROBJ_2 where [FIAS_66].dbo.ADDROBJ_2.FULLNAME = '" + query + "') and LIVESTATUS = 1";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        int i = 0;
                        addrobjs.Add(j, new ADDROBJModel
                        {
                            AOLEVEL = Convert.ToString(sqlDataReader.GetValue(0)),
                            IFNSFL = sqlDataReader.GetValue(1).ToString(),
                            IFNSUL = sqlDataReader.GetValue(2).ToString(),
                            OKATO = sqlDataReader.GetValue(3).ToString(),
                            OKTMO = sqlDataReader.GetValue(4).ToString(),
                            POSTALCODE = sqlDataReader.GetValue(5).ToString(),
                            AOGUID = sqlDataReader.GetValue(6).ToString(),
                            ACTSTATUS = sqlDataReader.GetValue(7).ToString(),
                            STARTDATE = Convert.ToString(sqlDataReader.GetValue(8)),
                            UPDATEDATE = Convert.ToString(sqlDataReader.GetValue(9)),
                            NORMDOC = Convert.ToString(sqlDataReader.GetValue(10)),
                            FULLNAME = query
                        });

                        j++;
                    }
                }

                sqlDataReader.Close();

                return JsonConvert.SerializeObject(addrobjs);
            }
        }

        public string FulltextSearchStreets(string query)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, ADDROBJModel> addrobjs = new Dictionary<int, ADDROBJModel>();

                string CommandText = "";

                CommandText = "select * from [FIAS_66].dbo.ADDROBJ where PARENTGUID = '" + query + "' and AOLEVEL = 7 and LIVESTATUS = 1 order by FORMALNAME";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        int i = 0;
                        addrobjs.Add(j, new ADDROBJModel
                        {
                            AOID = Convert.ToString(sqlDataReader.GetValue(0)),
                            AOGUID = Convert.ToString(sqlDataReader.GetValue(1)),
                            PARENTGUID = Convert.ToString(sqlDataReader.GetValue(2)),
                            PREVID = Convert.ToString(sqlDataReader.GetValue(3)),
                            NEXTID = Convert.ToString(sqlDataReader.GetValue(4)),
                            FORMALNAME = Convert.ToString(sqlDataReader.GetValue(5)),
                            OFFNAME = Convert.ToString(sqlDataReader.GetValue(6)),
                            SHORTNAME = Convert.ToString(sqlDataReader.GetValue(7)),
                            AOLEVEL = sqlDataReader.GetValue(8).ToString(),
                            REGIONCODE = sqlDataReader.GetValue(9).ToString(),
                            AREACODE = sqlDataReader.GetValue(10).ToString(),
                            AUTOCODE = sqlDataReader.GetValue(11).ToString(),
                            CITYCODE = sqlDataReader.GetValue(12).ToString(),
                            CTARCODE = sqlDataReader.GetValue(13).ToString(),
                            PLACECODE = sqlDataReader.GetValue(14).ToString(),
                            PLANCODE = sqlDataReader.GetValue(15).ToString(),
                            STREETCODE = sqlDataReader.GetValue(16).ToString(),
                            EXTRCODE = sqlDataReader.GetValue(17).ToString(),
                            SEXTCODE = sqlDataReader.GetValue(18).ToString(),
                            PLAINCODE = Convert.ToString(sqlDataReader.GetValue(19)),
                            CODE = Convert.ToString(sqlDataReader.GetValue(20)),
                            CURRSTATUS = sqlDataReader.GetValue(21).ToString(),
                            ACTSTATUS = sqlDataReader.GetValue(22).ToString(),
                            LIVESTATUS = sqlDataReader.GetValue(23).ToString(),
                            CENTSTATUS = sqlDataReader.GetValue(24).ToString(),
                            OPERSTATUS = sqlDataReader.GetValue(25).ToString(),
                            IFNSFL = sqlDataReader.GetValue(26).ToString(),
                            IFNSUL = sqlDataReader.GetValue(27).ToString(),
                            OKATO = sqlDataReader.GetValue(28).ToString(),
                            OKTMO = sqlDataReader.GetValue(29).ToString(),
                            POSTALCODE = sqlDataReader.GetValue(30).ToString(),
                            STARTDATE = Convert.ToString(sqlDataReader.GetValue(31)),
                            ENDDATE = Convert.ToString(sqlDataReader.GetValue(32)),
                            UPDATEDATE = Convert.ToString(sqlDataReader.GetValue(33)),
                            DIVTYPE = sqlDataReader.GetValue(34).ToString(),
                            NORMDOC = Convert.ToString(sqlDataReader.GetValue(35)),
                            TERRIFNSFL = sqlDataReader.GetValue(36).ToString(),
                            TERRIFNSUL = sqlDataReader.GetValue(37).ToString()
                        });

                        j++;
                    }
                }

                sqlDataReader.Close();

                return JsonConvert.SerializeObject(addrobjs);
            }
        }

        public string FulltextSearchStead(string query)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, SteadModel> steads = new Dictionary<int, SteadModel>();

                string CommandText = "SELECT * FROM [FIAS_66].[dbo].STEAD WHERE PARENTGUID = '" + query + "' order by NUMBER";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    steads.Add(j, new SteadModel
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

                return JsonConvert.SerializeObject(steads);
            }
        }

        public string FulltextSearchHouse(string query)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, HouseModel> houses = new Dictionary<int, HouseModel>();

                string CommandText = "SELECT * FROM [FIAS_66].[dbo].HOUSE WHERE AOGUID = '" + query + "' order by HOUSENUM";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    houses.Add(j, new HouseModel
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
                        ENDDATE = Convert.ToString(sqlDataReader.GetValue(i + 14)),
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

                return JsonConvert.SerializeObject(houses);
            }
        }
    }
}
