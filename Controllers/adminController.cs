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
    public class adminController : Controller
    {
        private readonly common Repos;
        private readonly loginRepo logrepo;
        private readonly registrationRepo Reposreg;
        public adminController(IConfiguration configuration)
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
            return RedirectToAction("index", "login");
        }

        [HttpGet]
        public IActionResult addpsuUser()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
                string statedetails = Repos.getstate();
                ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
                return View();
            }
            return RedirectToAction("index", "login");
        }

        [HttpPost]
        public IActionResult addpsuUser(PSUUser model)
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
                if (ModelState.IsValid)
                {

                    var isvalidmobile = Reposreg.isvalidpsumobile(model.mobile);
                    var isvalidemail = Reposreg.isvalidpsuemail(model.email);
                    if (isvalidmobile && isvalidemail)
                    {
                        var result = Reposreg.insertpsuUser(model);
                        if (result == 1)
                        {
                            ModelState.Clear();
                            return RedirectToAction("success");
                        }
                    }
                    else
                    {
                        TempData["error"] = "Email ID/Mobile No. Already Exist";
                    }
                    string statedetails = Repos.getstate();
                    ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
                    return View();
                }
                else
                {
                    string statedetails = Repos.getstate();
                    ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
                    return View();
                }
            }
            return RedirectToAction("index", "login");
        }
        [HttpGet]
        public IActionResult psuUser()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
                //string statedetails = Repos.getstate();
                //ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
                List<PSUUser> rsm = new List<PSUUser>();

                rsm = Reposreg.getpsuuser();
                return View(rsm);

            }
            return RedirectToAction("index", "login");
        }
        public IActionResult success()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
                return View();
            }
            return RedirectToAction("index", "login");
        }
    }
}
