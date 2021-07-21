using FIASLibary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public class GetInfoRepository : IGetInfoRepository
    {
        public string GetInfo(string Division, string addrobj, string house, string room)
        {
            string connectionString = @"Server=DESKTOP-RU9N0S3\SQLSERVERDEVELOP;Database=FIAS_66;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, ADDROBJModel> addrobjs = new Dictionary<int, ADDROBJModel>();

                string CommandText = "";

                if (room != "null")
                {
                    CommandText = "select top(1) [FIAS_66].dbo.ADDROBJ_2.FULLNAME + ', д. ' + [FIAS_66].dbo.HOUSE.HOUSENUM + ', кв. ' + [FIAS_66].dbo.ROOM.FLATNUMBER AS FULLNAME, [FIAS_66].dbo.ADDROBJ.ACTSTATUS, [FIAS_66].dbo.ADDROBJ.SHORTNAME, [FIAS_66].dbo.ROOM.ROOMGUID, [FIAS_66].dbo.ROOM.POSTALCODE, [FIAS_66].dbo.ADDROBJ.OKATO, [FIAS_66].dbo.ADDROBJ.OKTMO, [FIAS_66].dbo.ADDROBJ.IFNSFL, [FIAS_66].dbo.ADDROBJ.IFNSUL, [FIAS_66].dbo.ADDROBJ.FORMALNAME FROM [FIAS_66].dbo.ADDROBJ, [FIAS_66].dbo.ADDROBJ_2, [FIAS_66].dbo.ROOM, [FIAS_66].dbo.HOUSE where[FIAS_66].dbo.ADDROBJ_2.AOGUID = '" + addrobj + "' and [FIAS_66].dbo.HOUSE.HOUSEGUID = '" + house + "' and [FIAS_66].dbo.ROOM.ROOMGUID = '" + room + "'";
                }
                else if (house != "null")
                {
                    CommandText = "select top(1) [FIAS_66].dbo.ADDROBJ_2.FULLNAME + ', д. ' + [FIAS_66].dbo.HOUSE.HOUSENUM AS FULLNAME, [FIAS_66].dbo.ADDROBJ.ACTSTATUS, [FIAS_66].dbo.ADDROBJ.SHORTNAME, [FIAS_66].dbo.HOUSE.HOUSEGUID, [FIAS_66].dbo.HOUSE.POSTALCODE, [FIAS_66].dbo.HOUSE.OKATO, [FIAS_66].dbo.HOUSE.OKTMO, [FIAS_66].dbo.HOUSE.IFNSFL, [FIAS_66].dbo.HOUSE.IFNSUL FROM [FIAS_66].dbo.HOUSE, [FIAS_66].dbo.ADDROBJ_2, [FIAS_66].dbo.ADDROBJ.FORMALNAME [FIAS_66].dbo.ADDROBJ where[FIAS_66].dbo.HOUSE.HOUSEGUID = '" + house + "' and [FIAS_66].dbo.ADDROBJ_2.AOGUID = '" + addrobj + "'";
                }
                else if (addrobj != null)
                {
                    CommandText = "select [FIAS_66].dbo.ADDROBJ_2.FULLNAME, [FIAS_66].dbo.ADDROBJ.ACTSTATUS, [FIAS_66].dbo.ADDROBJ.SHORTNAME, [FIAS_66].dbo.ADDROBJ.AOGUID, [FIAS_66].dbo.ADDROBJ.POSTALCODE, [FIAS_66].dbo.ADDROBJ.OKATO, [FIAS_66].dbo.ADDROBJ.OKTMO, [FIAS_66].dbo.ADDROBJ.IFNSFL, [FIAS_66].dbo.ADDROBJ.IFNSUL, [FIAS_66].dbo.ADDROBJ.FORMALNAME FROM [FIAS_66].dbo.ADDROBJ, [FIAS_66].dbo.ADDROBJ_2 where[FIAS_66].dbo.ADDROBJ_2.AOGUID = '" + addrobj + "' and[FIAS_66].dbo.ADDROBJ.AOGUID = '" + addrobj + "' and [FIAS_66].dbo.ADDROBJ.LIVESTATUS = " + Division;
                }

                SqlCommand sqlCommand = new SqlCommand(CommandText, connection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int j = 0;

                while (sqlDataReader.Read())
                {
                    addrobjs.Add(j, new ADDROBJModel
                    {
                        FULLNAME = sqlDataReader.GetValue(0).ToString(),
                        ACTSTATUS = sqlDataReader.GetValue(1).ToString(),
                        SHORTNAME = sqlDataReader.GetValue(2).ToString(),
                        AOGUID = sqlDataReader.GetValue(3).ToString(),
                        POSTALCODE = sqlDataReader.GetValue(4).ToString(),
                        OKATO = sqlDataReader.GetValue(5).ToString(),
                        OKTMO = sqlDataReader.GetValue(6).ToString(),
                        IFNSFL = sqlDataReader.GetValue(7).ToString(),
                        IFNSUL = sqlDataReader.GetValue(8).ToString(),
                        FORMALNAME = sqlDataReader.GetValue(9).ToString()
                    });

                    j++;
                }

                sqlDataReader.Close();

                return JsonConvert.SerializeObject(addrobjs);
            }
        }
    }
}
