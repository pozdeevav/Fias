using Newtonsoft.Json;

namespace FiasClient.Models
{
    public class FiasStandartModel<TParam>
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("data")]
        public TParam Data { get; set; }
    }
}