using Newtonsoft.Json;

namespace FiasClient.Models
{
    public class AdvancedSearchModel
    {
        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("subject")]
        public string SubjectRF { get; set; }

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

        [JsonProperty("carseatnumber")]
        public string CarSeatNumber { get; set; }

        [JsonProperty("roomnumber")]
        public string RoomNumber { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("okato")]
        public string OKATO { get; set; }

        [JsonProperty("oktmo")]
        public string OKTMO { get; set; }

        [JsonProperty("uniquenumber")]
        public string UniqueNumber { get; set; }

        [JsonProperty("cadastralnumber")]
        public string CadastralNumber { get; set; }
    }
}
