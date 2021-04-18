using Newtonsoft.Json;
using ParibuApiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ParibuApiServices.ModelData
{
    public class CoinBusinessOperation : ICoinData
    {
        private const string serviceUrl = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/";
        private const string apiKey = "49208bd4-f756-4eec-886a-6ef3c85bcca7";
        public CoinInfo GetCoinList(FiatType fiatType, int maxSize)
        {
            CoinInfo result = new CoinInfo();
            string methodName = "listings/latest";
            var URL = new UriBuilder(string.Concat(serviceUrl,methodName));

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = maxSize.ToString();
            queryString["convert"] = fiatType == FiatType.EUR ? "EUR": fiatType == FiatType.USD ? "USD" : "TRY";
            //queryString["symbol"] = "BTC";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", apiKey);
            client.Headers.Add("Accepts", "application/json");
            string serviceResponse = client.DownloadString(URL.ToString());
            result = JsonConvert.DeserializeObject<CoinInfo>(serviceResponse);
            return result;

        }
    }
}
