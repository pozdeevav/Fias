using Newtonsoft.Json;

namespace Fias_Service.Models
{
    public class AdvancedSearchModel
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("settlement")]
        public string Settlement { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("planningelement")]
        public string PlanningElement { get; set; }

        [JsonProperty("roadnetworkelement")]
        public string RoadNetworkElement { get; set; }

        [JsonProperty("landnumber")]
        public string LandNumber { get; set; }

        [JsonProperty("buildingnumber")]
        public string BuildingNumber { get; set; }

        [JsonProperty("roomnumber")]
        public string RoomNumber { get; set; }
    }
}
