﻿using bbnl.Models;
using bbnl.repository;
//using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PuppeteerSharp;
using PuppeteerSharp.Media;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Web.UI;

namespace bbnl.Controllers
{
    public class registration : Controller
    {
        private readonly common Repos;
        private readonly registrationRepo Reposreg;
        private readonly string _host;
        private readonly string _from;
        private readonly string _pwd;
        private readonly string _port; 
        private readonly string _alias;
        private readonly string _username;
        private readonly string _bcc;
        private readonly string _ssl;
        private readonly string _defaultcred;

        public registration(IConfiguration configuration)
        {
            Repos = new common(configuration);
            Reposreg = new registrationRepo(configuration);
            var smtpSection = configuration.GetSection("SmtpConfig");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _from = smtpSection.GetSection("From").Value;
                _pwd = smtpSection.GetSection("Password").Value;
                _port = smtpSection.GetSection("PORT").Value;
                _alias = smtpSection.GetSection("Alias").Value;
                _username = smtpSection.GetSection("username").Value;
                _bcc = smtpSection.GetSection("BCC").Value;
                _ssl = smtpSection.GetSection("UseSSL").Value;
                _defaultcred= smtpSection.GetSection("DefaultCredential").Value; 
            }

        }
        public IActionResult form()
        {
            string statedetails = Repos.getstate();
            ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
            ViewData["servicestateList"]= JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
            ViewData["distList"] = new List<distModel>();
            ViewData["servicedistList"]= new List<distModel>();
            ViewData["serviceblockList"]= new List<blockModel>();
            ViewData["servicegpList"]= new List<gpModel>();
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile([FromForm]upladfile sendData)
        {
            //var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            //fileName = httpPostedFile.FileName;
          string path= Repos.saveFile(sendData.file, sendData.folder);
            return Ok(path);
        }
            [HttpPost]
        public IActionResult form(registrationmodel model)
        {
            ModelState.Remove("servicegp");
            if (model.companytype == "NONE")
            {
                ModelState.Remove("tan");
                ModelState.Remove("gstin");
                ModelState.Remove("licenceno");
            }
            if (model.servicestate == "all")
            {
                ModelState.Remove("servicedist");
                ModelState.Remove("serviceblock");
            }
            if (model.servicedist == "all")
            {

                ModelState.Remove("serviceblock");
            }
            if (ModelState.IsValid)
            {


                model.dotfilepath = model.dotfile ;
                model.gstinfilepath = model.gstinfile;
                model.poafilepath = model.poafile ;
                model.poifilepath = model.poifile;
                model.compdocfilepath = model.compdoc;
                model.panfilepath=model.panfile;
                model.aadharfilepath= model.aadharfile;
                model.aggrementfilepath = model.aggrementfile;


                registrationmodelwithoutfile registrationmodelwithoutfile = JsonConvert.DeserializeObject<registrationmodelwithoutfile>(JsonConvert.SerializeObject(model));
                //registrationmodelwithoutfile = model;
                var regmodeldata = JsonConvert.SerializeObject(registrationmodelwithoutfile);
                HttpContext.Session.SetString("regmodel", regmodeldata);

                //var result = Reposreg.insertreg(model);
               var isemailexist= Reposreg.isvalidemail(model.email);
                var ismobileexist = Reposreg.isvalidmobile(model.mobile);
                if (isemailexist && ismobileexist && model.mode =="submit")
                {
                    
                    sendmail(model.email);
                    //sendmailnic(model.email);
                }

                else
                {
                    if(isemailexist && ismobileexist)
                    {
                        model.mode = "validate";
                    }
                    else
                    {
                        model.mode = "save";
                        TempData["error"] = "Email ID/Mobile No. Already Exist";
                    }
                    setdata(model);
                    //string statedetails = Repos.getstate();
                    //// model.state = "";
                    //ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);

                    //string distdetails = Repos.getdist(Convert.ToString(string.IsNullOrEmpty(model.state) ? "0" : model.state));
                    //ViewData["distList"] = JsonConvert.DeserializeObject<List<distModel>>(distdetails);
                   
                    return View();
                }


            }
            else
            {
                setdata(model);
               // string statedetails = Repos.getstate();
               //// model.state = "";
               // ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
               // ViewData["servicestateList"] = ViewData["stateList"];


               // string distdetails= string.IsNullOrEmpty(model.state) ? "0" : Repos.getdist(Convert.ToString(model.state));
               // string servicedistdetails = string.IsNullOrEmpty(model.servicestate) ? "0" :  Repos.getdist(Convert.ToString(model.servicestate));
               // string serviceblockdetails = string.IsNullOrEmpty(model.servicedist) ? "0" : Repos.getblock(Convert.ToString(model.servicedist));
               // string servicegpdetails = string.IsNullOrEmpty(model.serviceblock) ? "0" : Repos.getgp(Convert.ToString(model.serviceblock),"GP");

               // ViewData["distList"] = JsonConvert.DeserializeObject<List<distModel>>(distdetails);
               // ViewData["servicedistList"] = servicedistdetails=="0"? new List<distModel>(): JsonConvert.DeserializeObject<List<distModel>>(servicedistdetails);
               // ViewData["serviceblockList"] = serviceblockdetails == "0" ? new List<blockModel>() : JsonConvert.DeserializeObject<List<blockModel>>(serviceblockdetails);
               // ViewData["servicegpList"] = servicegpdetails == "0" ? new List<gpModel>() : JsonConvert.DeserializeObject<List<gpModel>>(servicegpdetails);
                return View();
            }
            
            return RedirectToAction("otp");
        }

        //[HttpPost]
        //public ActionResult SetdistData(string value)
        //{
        //    ViewData["Message"] = value;
        //    return new EmptyResult();
        //}

        public IActionResult otp()
        {
            return View();

        }

        [HttpPost]
        public IActionResult otp(OTP otpmodel)
        {
            var otp = HttpContext.Session.GetString("sendOTP");
            if (ModelState.IsValid)
            {
                if (otpmodel.otp==otp)
                {

                
                var regdata = HttpContext.Session.GetString("regmodel");
                    registrationmodelwithoutfile model = JsonConvert.DeserializeObject<registrationmodelwithoutfile>(regdata);

                //model.dotfilepath = model.dotfile == null ? "" : Repos.saveFile(model.dotfile, "DOT");
                //model.gstinfilepath = model.gstinfile == null ? "" : Repos.saveFile(model.gstinfile, "GSTIN");
                //model.poafilepath = model.poafile == null ? "" : Repos.saveFile(model.poafile, "POA");
                //model.poifilepath = model.poifile == null ? "" : Repos.saveFile(model.poifile, "POI");
                //model.compdocfilepath = model.compdoc == null ? "" : Repos.saveFile(model.compdoc, "COM");

                var result = Reposreg.insertreg(model);
                    HttpContext.Session.SetString("regmodel",result);
                    ModelState.Clear();
                    return RedirectToAction("success");
                }

                else
                {
                    TempData["error"] = "Please Enter Correct OTP";
                }
            }
            ModelState.Clear();
            return View();

        }

       public void sendmailnic(string email)
        {
            HttpContext.Session.Remove("sendOTP");
            string numbers = "0123456789";
            Random random = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int tempval = random.Next(0, numbers.Length);
                otp += tempval;
            }
            HttpContext.Session.SetString("sendOTP", otp);
            using (MailMessage mail = new MailMessage())
            {

                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFromAddress = "contact.bbnl@nic.in";
                string emailPassword = "Bbnl@106/Bbnl@206";

                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(email);
                mail.Subject = "BBNL-OTP";
                mail.Body = otp +" is the OTP for verification of your email ID";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.UseDefaultCredentials = Convert.ToBoolean(_defaultcred);
                    smtp.Credentials = new NetworkCredential(emailFromAddress, emailPassword);
                    smtp.EnableSsl = Convert.ToBoolean(_ssl);
                    smtp.Send(mail);
                }
            }
        }

        public void sendmail(string email)
        {
            HttpContext.Session.Remove("sendOTP");
            string numbers = "0123456789";
            Random random = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int tempval = random.Next(0, numbers.Length);
                otp += tempval;
            }
            HttpContext.Session.SetString("sendOTP", otp);
            using (SmtpClient client = new SmtpClient(_host))
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_from, _alias);
                    mailMessage.To.Add(email);
                    mailMessage.Body = otp + " is the OTP for verification of your email ID";
                    mailMessage.Subject = "BBNL-OTP";
                    mailMessage.IsBodyHtml = true;
                    if (!string.IsNullOrWhiteSpace(_bcc))
                    {
                        string[] bccarr = _bcc.Split(',');
                        if (bccarr.Length > 0)
                        {
                            foreach (string bc in bccarr)
                                mailMessage.Bcc.Add(new MailAddress(bc));
                        }
                    }
                   
                    client.Port = Convert.ToInt32(_port);
                    client.Host = _host;
                    client.EnableSsl = Convert.ToBoolean(_ssl);
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_username, _pwd);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mailMessage);
                }
            }
        }


    

        public IActionResult success()
        {
            //sendsuccessmail();
            ExportToPDF();
            return View();

        }


        private void ExportToPDF()
        {
            var regdata = HttpContext.Session.GetString("regmodel");
            registrationmodelwithoutfile model = JsonConvert.DeserializeObject<registrationmodelwithoutfile>(regdata);
            HttpContext.Session.Remove("sendOTP");

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                   
                    //sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    //sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                    //sb.Append("<tr><td colspan = '2'></td></tr>");
                    //sb.Append("<tr><td><b>Order No:</b> 100</td><td><b>Date: </b>" + DateTime.Now + " </td></tr>");
                    //sb.Append("<tr><td><b>From :</b> " + "Company Name" + " </td><td><b>To: </b>" + " Some Company " + " </td></tr>");
                    //sb.Append("</table>");

                    //sb.Append("<table border = '1'>");
                    //sb.Append("<tr>");
                    //foreach (DataColumn column in dt.Columns)
                    //{
                    //    sb.Append("<th>");
                    //    sb.Append(column.ColumnName);
                    //    sb.Append("</th>");
                    //}
                    //sb.Append("</tr>");
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    sb.Append("<tr>");
                    //    foreach (DataColumn column in dt.Columns)
                    //    {
                    //        sb.Append("<td>");
                    //        sb.Append(row[column]);
                    //        sb.Append("</td>");
                    //    }
                    //    sb.Append("</tr>");
                    //}
                    //sb.Append("</table>");
                    var sb = htmlstring(model);

                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        MailMessage mm = new MailMessage(_from, model.email);
                        mm.Body = "Registration Success";
                        mm.Subject = "BBNL";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "registration.pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = _host;
                        smtp.EnableSsl = Convert.ToBoolean(_ssl);
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = _username;
                        NetworkCred.Password = _pwd;
                        smtp.UseDefaultCredentials = Convert.ToBoolean(_defaultcred);
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt32(_port);
                        smtp.Send(mm);
                    }
                }
            }
        }


        [HttpGet]
        public IActionResult Pdf()
        {
            var regdata = HttpContext.Session.GetString("regmodel");
            registrationmodelwithoutfile model = JsonConvert.DeserializeObject<registrationmodelwithoutfile>(regdata);
            HttpContext.Session.Remove("sendOTP");
            MemoryStream ms = new MemoryStream();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    var pdfstring = htmlstring(model);

                    StringReader sr = new StringReader(pdfstring.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                       
                        ms.Write(bytes, 0, bytes.Length);
                        ms.Position = 0;

                    }
                }
            }

          

            return File(fileStream: ms, contentType: "application/pdf", fileDownloadName: "registration" + ".pdf");
        }

        public StringBuilder htmlstring(registrationmodelwithoutfile model)
        {
           

            StringBuilder sb = new StringBuilder();

            sb.Append("<table border = '1'>" +
        "<tr><td> Registration No. </td><td>" + model.regno + "</td></tr>" +
"<tr><td> Name of the Service Provider </td><td>" + model.companyname + "</td></tr>" +
"<tr><td> Authorized License No </td><td>" + model.licenceno + "</td></tr>" +
"<tr><td> Name of Authorized Signatory </td><td>" + model.signaturename + "</td></tr>" +
"<tr><td> Aadhaar Number of Authorized Signatory </td><td>" + model.authorisedaadhar + "</td></tr>" +
"<tr><td> PAN </td><td>" + model.pan + "</td></tr>" +
"<tr><td> TAN </td><td>" + model.tan + "</td></tr>" +
"<tr><td> GSTIN </td><td>" + model.gstin + "</td></tr>" +
"<tr><td> Email ID </td><td>" + model.email + "</td></tr>" +
"<tr><td> Contact Mobile No. </td><td>" + model.mobile + "</td></tr>" +
"<tr><td> Address </td><td>" + model.add1 + " " + model.add2 + "</td></tr>" +
"</table> ");

            return sb;
        }



        public void setdata(registrationmodel model)
        {
            string statedetails = Repos.getstate();
            ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
            ViewData["servicestateList"] = ViewData["stateList"];
            ViewData["state"] = model.servicestate;
            ViewData["district"] = model.servicedist;
            ViewData["block"] = model.serviceblock;
            ViewData["mode"] = model.mode;
            ViewData["dotfilepath"] = model.dotfile;
            ViewData["gstinfilepath"] = model.gstinfile;
            ViewData["poafilepath"] = model.poafile;
            ViewData["poifilepath"] = model.poifile;
            ViewData["compdocfilepath"] = model.compdoc;
            ViewData["panfilepath"] = model.panfile;
            ViewData["aadharfilepath"] = model.aadharfile;
            ViewData["aggrementfilepath"] = model.aggrementfile;
            // model.state = "";
        
            //ViewData["stateList"] = JsonConvert.DeserializeObject<List<stateModel>>(statedetails);
            //ViewData["servicestateList"] = ViewData["stateList"];


            string distdetails = string.IsNullOrEmpty(model.state) ? "0" : Repos.getdist(Convert.ToString(model.state));
            //string servicedistdetails = string.IsNullOrEmpty(model.servicestate) ? "0" : Repos.getdist(Convert.ToString(model.servicestate));
            //string serviceblockdetails = string.IsNullOrEmpty(model.servicedist) ? "0" : Repos.getblock(Convert.ToString(model.servicedist));
            //string servicegpdetails = string.IsNullOrEmpty(model.serviceblock) ? "0" : Repos.getgp(Convert.ToString(model.serviceblock), "GP");

            ViewData["distList"] = distdetails == "0" ? new List<distModel>() : JsonConvert.DeserializeObject<List<distModel>>(distdetails);
        //    ViewData["servicedistList"] = servicedistdetails == "0" ? new List<distModel>() : JsonConvert.DeserializeObject<List<distModel>>(servicedistdetails);
        //    ViewData["serviceblockList"] = serviceblockdetails == "0" ? new List<blockModel>() : JsonConvert.DeserializeObject<List<blockModel>>(serviceblockdetails);
        //    ViewData["servicegpList"] = servicegpdetails == "0" ? new List<gpModel>() : JsonConvert.DeserializeObject<List<gpModel>>(servicegpdetails);
        }
    }
}