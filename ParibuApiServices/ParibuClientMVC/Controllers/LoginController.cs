using Microsoft.AspNetCore.Mvc;
using ParibuClientMVC.Helper;
using ParibuClientMVC.Models;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace ParibuClientMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Autherize(User user)
        {
            try
            {
                string jToken = string.Empty;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44310/user/authenticate");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<User>("authenticate", user);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        jToken = readTask.Result;
                    }
                    if (string.IsNullOrEmpty(jToken))
                    {
                        ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("CoinInfo", "Home");
                    }
                }

            }
            catch (Exception ex)
            {
                LogOperation.InsertLog("Login/Autherize", string.Concat("Coinbase servisi çağrılırken hata oluştu", ex.Message), DateTime.Now);
                return RedirectToAction("Error", "Home");
            }

        }

    }
}
