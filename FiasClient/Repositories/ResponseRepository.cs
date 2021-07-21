using FiasClient.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FiasClient.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        public Dictionary<int, AddrobjModel>.ValueCollection GetRoot(string Id)
        {
            WebRequest request = WebRequest.Create("http://localhost:59615/response/get/" + Id);

            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var rows = reader.ReadToEnd();

                    var json = Deserialize<GetRootModel>(rows);

                    return json.Data.Values;
                }
            }
        }

        public Dictionary<int, AddrobjModel>.ValueCollection GetInfo(string Id)
        {
            WebRequest request = WebRequest.Create("http://localhost:59615/response/get/" + Id);

            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var rows = reader.ReadToEnd();

                    var json = Deserialize<GetRootModel>(rows);

                    return json.Data.Values;
                }
            }
        }

        public Dictionary<int, AddrobjModel>.ValueCollection GetFulltextInfo(string Id)
        {
            WebRequest request = WebRequest.Create("http://localhost:59615/response/get/" + Id);

            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var rows = reader.ReadToEnd();

                    var json = Deserialize<GetRootModel>(rows);

                    return json.Data.Values;
                }
            }
        }

        public TResult Deserialize<TResult>(string obj)
        {
            return JsonConvert.DeserializeObject<TResult>(obj);
        }

        public string Serialize(string obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}