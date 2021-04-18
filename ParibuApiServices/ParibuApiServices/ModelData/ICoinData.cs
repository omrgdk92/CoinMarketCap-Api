using ParibuApiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.ModelData
{
    public interface ICoinData
    {
        CoinInfo GetCoinList(FiatType fiatType= FiatType.USD, int maxSize=5000);
    }
}
