using Newtonsoft.Json;

namespace FIASLibary.StandartModels
{
    public class FiasStandartModel<TParam>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("data")]
        public TParam Data { get; set; }
    }
}
