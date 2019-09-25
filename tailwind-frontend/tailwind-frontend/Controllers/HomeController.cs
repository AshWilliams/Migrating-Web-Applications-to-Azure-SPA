using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using tailwind_frontend.Models;

namespace tailwind_frontend.Controllers
{
    public class HomeController : Controller
    {
        private static IConfiguration configuration;

        public HomeController(IConfiguration iconfiguration)
        {
            configuration = iconfiguration;
        }
        public IActionResult Index()
        {
            string EndPoint = configuration.GetSection("endPoint").Value;
            ViewBag.EndPoint = EndPoint;
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
