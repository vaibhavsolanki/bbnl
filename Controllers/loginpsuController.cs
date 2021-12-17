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
    public class loginpsuController : Controller
    {
        private readonly common Repos;
        private readonly loginRepo logrepo;

        public loginpsuController(IConfiguration configuration)
        {
            Repos = new common(configuration);
            logrepo = new loginRepo(configuration);

        }
        public ActionResult Captchapsu(string prefix = null, bool noisy = true)
        {
            var Rand = new Random((int)DateTime.Now.Ticks);
            //int a = Rand.Next(10, 99);
            //int b = Rand.Next(0, 9);
            //var captcha = string.Format("{0} + {1} = ? ", a, b);
            int length = 6;
            const string pool = "abcdefghjkmnpqrstuvwyxzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var builder = new StringBuilder();
            Random random = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }
            var captcha = builder.ToString();
            HttpContext.Session.SetString("Captchapsu", captcha);
            //Session["Captcha"] = captcha;
            FileContentResult img = null;
            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));
                if (noisy)
                {
                    int i, r, x, y;
                    var Pen = new Pen(Color.Yellow);
                    for (i = 1; i < 1; i++)
                    {
                        Pen.Color = Color.FromArgb(
                            (Rand.Next(0, 255)),
                            (Rand.Next(0, 255)),
                            (Rand.Next(0, 255)));
                        r = Rand.Next(0, (130 / 3));
                        x = Rand.Next(0, 130);
                        y = Rand.Next(0, 30);

                        gfx.DrawEllipse(Pen, x - r, y - r, r, r);
                    }
                }
                var fontchoices = new List<string>() { "Tahoma", "Comic Sans MS" };
                gfx.DrawString(captcha, new Font(fontchoices[new Random().Next(0, 2)], 15), Brushes.Gray, 2, 3);
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }
            return img;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PSUUserLogin lm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string Captcha = HttpContext.Session.GetString("Captchapsu");
                    //if (Captcha == lm.Captcha)
                    if(1==1)
                    {
                        PSUUserLogin loginm = logrepo.LoginpsuCheck(lm.UserId, lm.Password);
                        if (loginm.UserId == "" || loginm.UserId == null && loginm.Password == "" || loginm.Password == null)
                        {
                            ModelState.AddModelError("UserId", "Invalid UserId");
                        }
                        else
                        {
                            if (loginm.Password == lm.Password)
                            {
                                HttpContext.Session.SetString("UserId", loginm.UserId);
                                HttpContext.Session.SetString("Password", loginm.Password);
                                HttpContext.Session.SetString("StateId", loginm.state);
                                HttpContext.Session.SetString("usertype", "psu");
                                return RedirectToAction("Index", "adminPsu");
                            }
                            ModelState.AddModelError("Password", "Invalid Password");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Captcha", "Invalid Captcha");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return View();
        }
    }
}
