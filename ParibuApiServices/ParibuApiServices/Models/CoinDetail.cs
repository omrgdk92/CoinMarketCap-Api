using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.Models
{
    [Serializable]
    [JsonObject]
    public class CoinDetail
    {
        [JsonProperty("price")]
        public float Price { get; set; }
        [JsonProperty("volume_24h")]
        public float Volume24H { get; set; }
        [JsonProperty("percent_change_24h")]
        public float PercentChange24H { get; set; }
    }
}
