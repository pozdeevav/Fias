using FIASLibary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public class GetChildRepository : IGetChildRepository
    {
        public Dictionary<int, AdvancedSearchModel> GetChild(string Parent, string Division, string AO)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, AdvancedSearchModel> childs = new Dictionary<int, AdvancedSearchModel>();

                string CommandText = "";

                if (AO == "3")
                {
                    CommandText = "select AOLEVEL, AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_FULLNAMES where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " order by FULLNAME";
                }
                else if (AO == "4")
                {
                    CommandText = "select AOLEVEL, AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_FULLNAMES where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and AOLEVEL = 4 order by FULLNAME";
                }
                else if (AO == "6")
                {
                    CommandText = "select AOLEVEL, AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_FULLNAMES where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and AOLEVEL = 6 order by FULLNAME";
                }
                else if (AO == "7")
                {
                    CommandText = "select AOLEVEL, AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_FULLNAMES where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and AOLEVEL = 7 order by FULLNAME";
                }
                else if (AO == "65")
                {
                    CommandText = "select AOLEVEL, AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_FULLNAMES where PARENTGUID = '" + Parent + "' and LIVESTATUS = " + Division + " and (AOLEVEL = 65 or AOLEVEL = 91) order by FULLNAME";
                }

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    childs.Add(j, new AdvancedSearchModel
                    {
                        AOLEVEL = sqlDataReader.GetValue(0).ToString(),
                        AOGUID = sqlDataReader.GetValue(1).ToString(),
                        FULLNAME = sqlDataReader.GetValue(2).ToString()
                    });

                    j++;
                }

                sqlDataReader.Close();

                return childs;
            }
        }
    }
}
