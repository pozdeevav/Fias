using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fias_Service.StandartModels
{
    public class GetInfoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("addrobj")]
        public string Addrobj { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }
    }
}
