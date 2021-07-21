using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIASLibary.StandartModels
{
    public class QueryModel
    {
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
