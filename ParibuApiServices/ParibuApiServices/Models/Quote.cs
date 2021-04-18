using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.Models
{
    [JsonObject]
    [Serializable]
    public class Quote
    {
        [JsonProperty("USD")]
        public Usd USD { get; set; }
        [JsonProperty("TRY")]
        public Try TRY { get; set; }
        [JsonProperty("EUR")]
        public Eur EUR { get; set; }
    }
}
