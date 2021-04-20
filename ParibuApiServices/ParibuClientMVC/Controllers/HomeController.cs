using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParibuClientMVC.Helper;
using ParibuClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace ParibuClientMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Coin coinResult = new Coin();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44310/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("coin/2/50");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Coin>();
                        readTask.Wait();
                        coinResult = readTask.Result;
                    }
                    else
                    {
                        LogOperation.InsertLog(new StackTrace().GetFrame(1).GetMethod().Name, string.Concat("Coinbase servisinden response hatalı döndü", result.ReasonPhrase), DateTime.Now);
                        ModelState.AddModelError(string.Empty, "Coinbase Server error. Please contact administrator.");
                    }
                }
                return View(coinResult);
            }
            catch (Exception ex)
            {
                LogOperation.InsertLog(new StackTrace().GetFrame(1).GetMethod().Name, string.Concat("Coinbase servisi çağrılırken hata oluştu", ex.Message), DateTime.Now);
                return RedirectToAction("Error", "Home");
            }

        }
        public ActionResult CoinInfo()
        {
            Coin coinResult = new Coin();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44310/api/");
                    var responseTask = client.GetAsync("coin/2/50");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Coin>();
                        readTask.Wait();
                        coinResult = readTask.Result;
                        if (coinResult.datas != null)
                        {
                            coinResult.datas.ForEach(s => s.last_updated = DateTime.Now.ToString());
                        }
                    }
                    else
                    {
                        LogOperation.InsertLog(new StackTrace().GetFrame(1).GetMethod().Name, string.Concat("Coinbase servisinden response hatalı döndü", result.ReasonPhrase), DateTime.Now);
                        ModelState.AddModelError(string.Empty, "Coinbase Server error. Please contact administrator.");
                    }
                }
                return View(coinResult.datas);

            }
            catch (Exception ex)
            {
                LogOperation.InsertLog(new StackTrace().GetFrame(1).GetMethod().Name, string.Concat("Coinbase servisi çağrılırken hata oluştu", ex.Message), DateTime.Now);
                return RedirectToAction("Error", "Home");
            }
        }
        public ActionResult Search(string symbol)
        {
            List<Data> coinResult = new List<Data>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44310/api/");
                    var responseTask = client.GetAsync("coin/2/5000/" + symbol.ToUpper());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<Data>>();
                        readTask.Wait();
                        coinResult = readTask.Result;
                        if (coinResult != null)
                        {
                            coinResult.ForEach(s => s.last_updated = DateTime.Now.ToString());
                        }
                    }
                    else
                    {
                        LogOperation.InsertLog(new StackTrace().GetFrame(1).GetMethod().Name, string.Concat("Coinbase servisinden response hatalı döndü", result.ReasonPhrase), DateTime.Now);
                        ModelState.AddModelError(string.Empty, "Coinbase Server error. Please contact administrator.");
                    }
                }
                return View("CoinInfo", coinResult);
            }
            catch (Exception ex)
            {
                LogOperation.InsertLog(new StackTrace().GetFrame(1).GetMethod().Name, string.Concat("Coinbase servisi çağrılırken hata oluştu", ex.Message), DateTime.Now);
                return RedirectToAction("Error", "Home");
            }

           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
