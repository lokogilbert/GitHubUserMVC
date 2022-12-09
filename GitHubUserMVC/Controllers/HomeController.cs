using GitHubUserMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using GitHubUserMVC.Extensions;
using System;

namespace GitHubUserMVC.Controllers
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string user_text)
        {
            if (!string.IsNullOrEmpty(user_text))
            {
                // User search by username
                var response = await ClientClass.client.GetAsync("users/" + user_text);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    // You have to install Newtonsoft.Json to use JsonConvert
                    GitHubUserViewModel? user = JsonConvert.DeserializeObject<GitHubUserViewModel>(data);

                    if (user != null)
                    {
                        TempData.Put("user", user);
                        return RedirectToAction("Details", "User");
                    }
                }

                // User search by id
                response = await ClientClass.client.GetAsync("user/" + user_text);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    // You have to install Newtonsoft.Json to use JsonConvert
                    GitHubUserViewModel? user = JsonConvert.DeserializeObject<GitHubUserViewModel>(data);

                    if (user != null)
                    {
                        // User is stored in a tempdata variable to avoid through redirection
                        TempData.Put("user", user);
                        return RedirectToAction("Details", "User");
                    }
                }

                ViewBag.ErrorMessage = "User not found or matched";
            }
            return View();
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