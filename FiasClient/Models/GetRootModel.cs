using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiasClient.Models
{
    public class GetRootModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public Dictionary<int, AddrobjModel> Data { get; set; }
    }
}