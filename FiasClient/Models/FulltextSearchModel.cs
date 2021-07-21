using Newtonsoft.Json;

namespace FiasClient.Models
{
    public class FulltextSearchModel
    {
        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
