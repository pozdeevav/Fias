using FIASLibary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIASLibary.StandartModels
{
    public class GetChildModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public Dictionary<int, ADDROBJModel> Data { get; set; }
    }
}
