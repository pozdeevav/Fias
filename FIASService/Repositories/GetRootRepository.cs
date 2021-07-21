using FIASLibary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FIASService.Repositories
{
    public class GetRootRepository : IGetRootRepository
    {
        public Dictionary<int, AdvancedSearchModel> GetRoot(string Division)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, AdvancedSearchModel> roots = new Dictionary<int, AdvancedSearchModel>();

                string CommandText = "select AOGUID, FULLNAME from [FIAS_66].dbo.ADDROBJ_FULLNAMES where PARENTGUID is NULL and LIVESTATUS = " + Division + " order by FULLNAME";

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                sqlCommand.CommandTimeout = 300;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    int i = 0;
                    roots.Add(j, new AdvancedSearchModel
                    {
                        AOGUID = sqlDataReader.GetValue(0).ToString(),
                        FULLNAME = sqlDataReader.GetValue(1).ToString()
                    });

                    j++;
                }

                sqlDataReader.Close();

                return roots;
            }
        }
    }
}
