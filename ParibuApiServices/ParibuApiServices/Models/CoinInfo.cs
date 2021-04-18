using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.Models
{
    [Serializable]
    [JsonObject]
    public class CoinInfo
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("data")]
        public List<Data> Datas { get; set; }
    }
}
