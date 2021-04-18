using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuClientMVC.Models
{
    public class Coin
    {
        public Status status { get; set; }
        public List<Data> datas { get; set; }
    }
    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public Quote quote { get; set; }
        public string last_updated { get; set; }
    }
    public class FiatBase {
        public double price { get; set; }
        public object volume24H { get; set; }
        public double percentChange24H { get; set; }
    }
    public class Usd:FiatBase
    {
       
    }
    public class Try : FiatBase
    {

    }
    public class Eur : FiatBase
    {

    }

    public class Quote
    {
        public Usd usd { get; set; }
        public Try @try { get; set; }
        public Eur eur { get; set; }
    }
    public class Status
    {
        public DateTime Tarih { get; set; }
    }
}
