using Newtonsoft.Json;
using System;

namespace FiasClient.Models
{
    public class AddrobjModel
    {
        [JsonProperty("AOID")]
        public string AOID { get; set; }
        [JsonProperty("AOGUID")]
        public string AOGUID { get; set; }
        [JsonProperty("PARENTGUID")]
        public string PARENTGUID { get; set; }
        [JsonProperty("PREVID")]
        public string PREVID { get; set; }
        [JsonProperty("NEXTID")]
        public string NEXTID { get; set; }
        [JsonProperty("FORMALNAME")]
        public string FORMALNAME { get; set; }
        [JsonProperty("OFFNAME")]
        public string OFFNAME { get; set; }
        [JsonProperty("SHORTNAME")]
        public string SHORTNAME { get; set; }
        [JsonProperty("AOLEVEL")]
        public object AOLEVEL { get; set; }
        [JsonProperty("REGIONCODE")]
        public object REGIONCODE { get; set; }
        [JsonProperty("AREACODE")]
        public object AREACODE { get; set; }
        [JsonProperty("AUTOCODE")]
        public object AUTOCODE { get; set; }
        [JsonProperty("CITYCODE")]
        public object CITYCODE { get; set; }
        [JsonProperty("CTARCODE")]
        public object CTARCODE { get; set; }
        [JsonProperty("PLACECODE")]
        public object PLACECODE { get; set; }
        [JsonProperty("PLANCODE")]
        public object PLANCODE { get; set; }
        [JsonProperty("STREETCODE")]
        public object STREETCODE { get; set; }
        [JsonProperty("EXTRCODE")]
        public object EXTRCODE { get; set; }
        [JsonProperty("SEXTCODE")]
        public object SEXTCODE { get; set; }
        [JsonProperty("PLAINCODE")]
        public object PLAINCODE { get; set; }
        [JsonProperty("CODE")]
        public object CODE { get; set; }
        [JsonProperty("CURRSTATUS")]
        public object CURRSTATUS { get; set; }
        [JsonProperty("ACTSTATUS")]
        public object ACTSTATUS { get; set; }
        [JsonProperty("LIVESTATUS")]
        public object LIVESTATUS { get; set; }
        [JsonProperty("CENTSTATUS")]
        public object CENTSTATUS { get; set; }
        [JsonProperty("OPERSTATUS")]
        public object OPERSTATUS { get; set; }
        [JsonProperty("IFNSFL")]
        public object IFNSFL { get; set; }
        [JsonProperty("IFNSUL")]
        public object IFNSUL { get; set; }
        [JsonProperty("OKATO")]
        public object OKATO { get; set; }
        [JsonProperty("OKTMO")]
        public object OKTMO { get; set; }
        [JsonProperty("POSTALCODE")]
        public object POSTALCODE { get; set; }
        [JsonProperty("STARTDATE")]
        public object STARTDATE { get; set; }
        [JsonProperty("ENDDATE")]
        public object ENDDATE { get; set; }
        [JsonProperty("UPDATEDATE")]
        public object UPDATEDATE { get; set; }
        [JsonProperty("DIVTYPE")]
        public object DIVTYPE { get; set; }
        [JsonProperty("NORMDOC")]
        public string NORMDOC { get; set; }
        [JsonProperty("TERRIFNSFL")]
        public object TERRIFNSFL { get; set; }
        [JsonProperty("TERRIFNSUL")]
        public object TERRIFNSUL { get; set; }
        [JsonProperty("FULLNAME")]
        public object FULLNAME { get; set; }
    }
}
