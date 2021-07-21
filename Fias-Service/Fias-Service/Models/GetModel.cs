using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fias_Service.StandartModels
{
    public class GetModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("ao")]
        public string AO { get; set; }
    }
}
