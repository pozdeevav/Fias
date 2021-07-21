using Newtonsoft.Json;

namespace FIASLibary.Models
{
    public class FulltextSearchModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
