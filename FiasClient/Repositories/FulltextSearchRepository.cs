using FiasClient.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace FiasClient.Repositories
{
    public class FulltextSearchRepository : IFulltextSearchRepository
    {
        public string FulltextSearch(FulltextSearchModel searchModel)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/request/fulltextsearch");

            request.Method = "POST";

            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();

            var requestData = Encoding.UTF8.GetBytes(Serialize(searchModel));

            requestStream.Write(requestData, 0, requestData.Length);

            string responseData;

            string header;

            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                header = response.Headers.Get("Request-ID");

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

            return header;
        }

        public string FulltextSearchInfo(string Id, string searchModel)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/request/fulltextsearchinfo/" + Id + "/" + searchModel);

            request.Method = "POST";

            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();

            var requestData = Encoding.UTF8.GetBytes(searchModel);

            requestStream.Write(requestData, 0, requestData.Length);

            string responseData;

            string header;

            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                header = response.Headers.Get("Request-ID");

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

            return header;
        }

        private string Serialize(FulltextSearchModel obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
