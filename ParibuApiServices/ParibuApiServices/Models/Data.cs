using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.Models
{
    [Serializable]
    [JsonObject]
    public class Data
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("quote")]
        public Quote Quote { get; set; }
        [JsonProperty("last_updated")]
        public string UpdateTime { get; set; }
    }
}
