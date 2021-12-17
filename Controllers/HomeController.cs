using bbnl.Models;
using bbnl.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace bbnl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly common Repos;
        private readonly registrationRepo Reposreg;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            Repos = new common(configuration);
            Reposreg = new registrationRepo(configuration);
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        public IActionResult gp()
        {
            //string countdetails = Repos.getcount();
            //countModel count= JsonConvert.DeserializeObject<countModel>(countdetails);

            //ViewData["statecount"] = count.state_count;
            //ViewData["distcount"] = count.districts_count;
            //ViewData["blockcount"] = count.block_count;
            //ViewData["gpcount"] = count.gp_count;
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
