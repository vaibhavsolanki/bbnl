using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbnl.Models;
using Microsoft.Extensions.Configuration;
using bbnl.repository;
using System.Text;
using System.IO;

namespace bbnl.Controllers
{
    public class gpuserController : Controller
    {
        private readonly common Repos;
        private readonly registrationRepo Reposreg;

        public gpuserController(IConfiguration configuration)
        {
            Repos = new common(configuration);
            Reposreg = new registrationRepo(configuration);

        }
        [HttpGet]
        public IActionResult Index()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            var usertype=HttpContext.Session.GetString("usertype");
            if (DUserid != "" && DUserid != null && usertype=="GP")
            {
                return View();
            }
            return RedirectToAction("gpLogin", "login");
        }


        [HttpGet]
        public IActionResult gpdetails()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            var usertype = HttpContext.Session.GetString("usertype");
            if (DUserid != "" && DUserid != null && usertype == "GP")
            {
                string statedetails = Repos.getstate();
                ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
                return View();
            }
            return RedirectToAction("gpLogin", "login");
        }


        public IActionResult exportgp(int id)
        {

            string gp_details = Repos.getgp(Convert.ToString(id), "GP");

            List<gpModel> gplist = JsonConvert.DeserializeObject<List<gpModel>>(gp_details);

            var comlumHeadrs = new string[]
          {
               "Sr. No",
                 "GP Code",
                 "GP Name",
                 "Status"
          };
            var gpcsv = new StringBuilder();
           
            int j = 1;
            var hg = (from gp in gplist
                      select new object[]
                      {
                                             j++,
                                            gp.gp_id,
                                            $"{gp.gp_name}",
                                            string.IsNullOrEmpty(gp.up_status)?"UP":Enum.GetName(typeof(gpEnum), Convert.ToInt32(gp.up_status))

                         

                      }).ToList();


            hg.ForEach(line =>
            {


                gpcsv.AppendLine(string.Join(",", line));

            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", comlumHeadrs)}\r\n{gpcsv.ToString()}");
            return File(buffer, "text/csv", $"GpDetails.csv");


        }

        [HttpGet]
        public IActionResult updategp()
        {
            var DUserid = HttpContext.Session.GetString("UserId");
            var usertype = HttpContext.Session.GetString("usertype");
            if (DUserid != "" && DUserid != null && usertype == "GP")
            {
                
                return View();
            }
            return RedirectToAction("gpLogin", "login");
        }

        [HttpPost]
        public IActionResult updategp(gpfile gpfile)
        {
            if (ModelState.IsValid)
            {
                if (gpfile.filetoupload != null)
                {
                    var filedata = gpfile.filetoupload;
                    var fileName = Path.GetFileName(filedata.FileName);
                    var filenamewithoutextension = Path.GetFileNameWithoutExtension(filedata.FileName);
                    var extension = Path.GetExtension(filedata.FileName);
                    string vardatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");
                    var newfilenamewithoutextension = vardatetime + filenamewithoutextension + extension;
                    string foldername = "wwwroot/GP/update";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), foldername, newfilenamewithoutextension);
                    if (!Directory.Exists(foldername))
                    {
                        Directory.CreateDirectory(foldername);
                    }
                    FileInfo file = new FileInfo(Path.Combine(path));
                    var stream = new FileStream(path, FileMode.Create);
                    filedata.CopyTo(stream);
                    stream.Close();
                    //var state = HttpContext.Session.GetString("state_id");
                    var sd = Reposreg.ReadgpCSVFile(path);
                    if (sd == 0)
                    {
                        TempData["LoginFail"] = "Unable To Update (Please Check State/GP Status in CSV)";
                    }
                }
            }
            else
            {
                TempData["LoginFail"] = "Please Select File";
            }
            return RedirectToAction("updategp");
        }
    }
}
