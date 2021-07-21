using FiasClient.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace FiasClient.Repositories
{
    public class AdvancedSearch : IAdvancedSearch
    {
        public string AdvSearchRoot(string Id)
        {
            WebRequest request = WebRequest.Create("http://localhost:51479/request/getroot/1/" + Id);

            request.Method = "POST";

            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();

            string responseData;

            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                responseData = responseStream == null
                    ? null
                    : new StreamReader(responseStream).ReadToEnd();
            }
            catch (WebException e)
            {
                if (e.Message.Contains("404"))
                {
                    throw new Exception(e.Message);
                }
                string readToEnd;
                try
                {
                    var responseStream = e.Response.GetResponseStream();
                    readToEnd = new StreamReader(responseStream).ReadToEnd();
                }
                catch
                {
                    readToEnd = e.Message;
                }
                responseData = $"{{\"errorMessage\": \"{readToEnd}\"}}";
                throw new Exception(e.Message);
            }

            return responseData;

        }

        public string AdvSearchInfo(string Id, string Division, string addrobj, string house, string room)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/request/getinfo/" + Id + "/" + Division + "/" + addrobj + "/" + house + "/" + room);

            request.Method = "POST";

            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();

            string responseData;

            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                responseData = responseStream == null
                    ? null
                    : new StreamReader(responseStream).ReadToEnd();
            }
            catch (WebException e)
            {
                if (e.Message.Contains("404"))
                {
                    throw new Exception(e.Message);
                }
                string readToEnd;
                try
                {
                    var responseStream = e.Response.GetResponseStream();
                    readToEnd = new StreamReader(responseStream).ReadToEnd();
                }
                catch
                {
                    readToEnd = e.Message;
                }
                responseData = $"{{\"errorMessage\": \"{readToEnd}\"}}";
                throw new Exception(e.Message);
            }

            return responseData;
        }

        private string Serialize(AdvancedSearchModel obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
