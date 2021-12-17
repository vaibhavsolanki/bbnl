using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbnl.repository;
using Microsoft.Extensions.Configuration;
using bbnl.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace bbnl.Controllers
{
    public class detailsController : Controller
    {
        private readonly common Repos;
        private readonly registrationRepo Reposreg;

        public detailsController(IConfiguration configuration)
        {
            Repos = new common(configuration);
            Reposreg = new registrationRepo(configuration);

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult state([FromQuery(Name = "stateName")] string a, [FromQuery(Name = "data")] string data)
        {
            //var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");

            //var url = location.AbsoluteUri;
            // DataTable pkgdetails = Repos.getpackegewrtstate();

            var state = a.Split('_');

            string distdetails = Repos.getdist(Convert.ToString(string.IsNullOrEmpty(state[1]) ? "0" : state[1]));
            ViewData["distList"] = JsonConvert.DeserializeObject<List<distModel>>(distdetails);
            ViewData["state_name"] = state[0];
            return View();
            //return Redirect("/details/viewstate?stateName=" + a);

        }
        public IActionResult getdistrict(int id)
        {
            managedistModel managedist = new managedistModel();
            string dist_details = Repos.getdist(Convert.ToString(id));
           // string countdetails = Repos.countwrtstate(id);
            managedist.distModels = JsonConvert.DeserializeObject<List<distModel>>(dist_details);
           // managedist.abdcount = JsonConvert.DeserializeObject<List<abdcount>>(countdetails)[0];
            return Json(JsonConvert.SerializeObject(managedist));
        }
        public IActionResult getalldistrict()
        {
            managedistModel managedist = new managedistModel();
            string dist_details = Repos.getalldist();
            // string countdetails = Repos.countwrtstate(id);
            managedist.distModels = JsonConvert.DeserializeObject<List<distModel>>(dist_details);
            // managedist.abdcount = JsonConvert.DeserializeObject<List<abdcount>>(countdetails)[0];
            return Json(JsonConvert.SerializeObject(managedist));
        }
        public JsonResult getallblock()
        {
            manageblockModel manageblock = new manageblockModel();
            string block_details = Repos.getallblock();
            string countdetails = Repos.countwrtdist("1");
            manageblock.blockModels = JsonConvert.DeserializeObject<List<blockModel>>(block_details);
            manageblock.countmodel = JsonConvert.DeserializeObject<List<countModel>>(countdetails)[0];
            return Json(JsonConvert.SerializeObject(manageblock));

        }
        public JsonResult getblockwrtdist(int id)
        {
            manageblockModel manageblock = new manageblockModel();
            string block_details = Repos.getblock(Convert.ToString(id));
            string countdetails = Repos.countwrtdist(Convert.ToString(id));
            manageblock.blockModels = JsonConvert.DeserializeObject<List<blockModel>>(block_details);
            manageblock.countmodel = JsonConvert.DeserializeObject<List<countModel>>(countdetails)[0];
            return Json(JsonConvert.SerializeObject(manageblock));

        }
        public JsonResult getgpwrtblock(int block, string type)
        {

            string gp_details = Repos.getgp(Convert.ToString(block), type);
            //string countdetails = Repos.countwrtblock(block);
            managegpModel managegp = new managegpModel();
            //List<gpModel> gpModels
            managegp.gpModels = JsonConvert.DeserializeObject<List<gpModel>>(gp_details);
            //managegp.abdcount = JsonConvert.DeserializeObject<List<abdcount>>(countdetails)[0];
            return Json(JsonConvert.SerializeObject(managegp));

        }

        public string getl14(string block)
        {

            string details = Repos.getl14(string.IsNullOrEmpty(block)?0:Convert.ToInt32(block));
            //string countdetails = Repos.countwrtblock(block);
            //managegpModel managegp = new managegpModel();
            ////List<gpModel> gpModels
            //managegp.gpModels = JsonConvert.DeserializeObject<List<gpModel>>(gp_details);
            ////managegp.abdcount = JsonConvert.DeserializeObject<List<abdcount>>(countdetails)[0];
            return details;

        }

        [HttpGet]
        public string getcount()
        {
            string countdetails = Repos.getcount();
            //countModel count= JsonConvert.DeserializeObject<countModel>(countdetails);

            //ViewData["statecount"] = count.state_count;
            //ViewData["distcount"] = count.districts_count;
            //ViewData["blockcount"] = count.block_count;
            //ViewData["gpcount"] = count.gp_count;
            return countdetails;
        }

     
        public string countwrtstate(int id)
        {
            
            string countdetails = Repos.countwrtstate(Convert.ToString(id));

            return countdetails;
        }

        [HttpGet]
        public IActionResult showdata()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            if (DUserid != "" && DUserid != null)
            {
                List<registrationmodel> rsm = new List<registrationmodel>();
                var stateid = HttpContext.Session.GetString("StateId");
                    var usertype= HttpContext.Session.GetString("usertype");
                rsm = Reposreg.getdatabystateid(stateid, usertype);
                return View(rsm);
            }
            return Redirect("/");
        }
    }
}
