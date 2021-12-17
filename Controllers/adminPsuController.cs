using bbnl.Models;
using bbnl.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbnl.Controllers
{
    public class adminPsuController : Controller
    {
        private readonly common Repos;
        private readonly loginRepo logrepo;
        private readonly registrationRepo Reposreg;
        public adminPsuController(IConfiguration configuration)
        {
            Repos = new common(configuration);
            logrepo = new loginRepo(configuration);
            Reposreg = new registrationRepo(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
                return View();
            }
            return RedirectToAction("index", "loginpsu");
        }

        [HttpGet]
        public IActionResult showdata()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
               List<registrationmodel> rsm = new List<registrationmodel>();
                var stateid = HttpContext.Session.GetString("StateId");
                var usertype = HttpContext.Session.GetString("usertype");
                rsm = Reposreg.getdatabystateid(stateid, usertype);
                return View(rsm);
            }
            return RedirectToAction("index", "loginpsu");
        }       

    }
}
