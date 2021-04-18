using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParibuApiServices.ModelData;
using ParibuApiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ParibuApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private ICoinData _coinData;
        private const string serviceUrl = "";
        private const string apiKey = "49208bd4-f756-4eec-886a-6ef3c85bcca7";
        public CoinController(ICoinData coinData)
        {
            _coinData = coinData;
        }

        [HttpGet("{fiattype}/{maxsize}")]// GET /api/coin
        public IActionResult GetCoinList(FiatType fiatType, int maxSize)
        {
            return Ok(_coinData.GetCoinList(fiatType, maxSize));
        }
        [HttpGet("{fiattype}/{maxsize}/{symbol}")]// GET /api/coin
        public IActionResult GetCoinBySymbol(string symbol)
        {
            return Ok(_coinData.GetCoinList(FiatType.USD).Datas.Where(x=> x.Symbol==symbol));
        }
    }
}
