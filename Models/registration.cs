using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bbnl.Models
{
    public class loginmodel
    {
        [Required(ErrorMessage = "Enter UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

       // [Required(ErrorMessage = "Enter Captcha")]
        public string Captcha { get; set; }

        public string StateId { get; set; }

    }

    public class PSUUserLogin
    {
        [Required(ErrorMessage = "Enter UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Enter Captcha")]
        public string Captcha { get; set; }

        public string state { get; set; }

    }

    public class PSUUser
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Select State")]
        public string state { get; set; }

        public string Captcha { get; set; }
        public string Password { get; set; }

    }

    public class upladfile
    {
       public IFormFile file { get; set; }
 public string folder { get; set; }
    }
    public class registrationmodel
    {
        [Required(ErrorMessage = "Enter Company Name")]
        public string companyname { get; set; }
        [Required(ErrorMessage = "Enter Address 1")]
        public string add1 { get; set; }
        [Required(ErrorMessage = "Enter Address 2")]
        public string add2 { get; set; }
        [Required(ErrorMessage = "select State")]
        public string state { get; set; }
        [Required(ErrorMessage = "select District")]
        public string dist { get; set; }
      
        //public string servicestate { get; set; }
        //[Required(ErrorMessage = "select District")]
        //public string servicedist { get; set; }
        //[Required(ErrorMessage = "select Block")]
        //public string serviceblock { get; set; }
        public string mode { get; set; }
        public string iisstate { get; set; }

        
        [Required(ErrorMessage = "select State")]
        public string servicestate { get; set; }
        [Required(ErrorMessage = "select District")]
        public string servicedist { get; set; }
        [Required(ErrorMessage = "select Block")]
        public string serviceblock { get; set; }
        //[Required(ErrorMessage = "select GP")]
        public string servicegp { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string mobile { get; set; }
        [Required(ErrorMessage = "Select Type")]
        
        public string companytype { get; set; }
        [Required(ErrorMessage = "Enter Licence No.")]
        public string licenceno { get; set; }
        [Required(ErrorMessage = "Enter Signature Name")]
        public string signaturename { get; set; }
        public string dotfilepath { get; set; }
        public string gstinfilepath { get; set; }
        public string poafilepath { get; set; }
        public string poifilepath { get; set; }
        public string compdocfilepath { get; set; }
        public string panfilepath { get; set; }
        public string aadharfilepath { get; set; }
        public string aggrementfilepath { get; set; }
        public string states_name { get; set; }
        public string districts_name { get; set; }
        [Required(ErrorMessage = "Enter PAN")]
        public string pan { get; set; }
        [Required(ErrorMessage = "Enter GSTIN")]
        public string gstin { get; set; }
        [Required(ErrorMessage = "Enter TAN")]
        public string tan { get; set; }
        [Required(ErrorMessage = "Enter Aadhaar Number")]
        public string authorisedaadhar { get; set; }

        public string dotfile { get; set; }
        public string gstinfile { get; set; }
        public string poafile { get; set; }
        public string poifile { get; set; }
        public string compdoc { get; set; }
        public string panfile { get; set; }
        public string aadharfile { get; set; }
        public string aggrementfile { get; set; }

    }

    public class registrationmodelwithoutfile
    {
        public string regno { get; set; }
        [Required(ErrorMessage = "Enter Company Name")]
        public string companyname { get; set; }
        [Required(ErrorMessage = "Enter Address 1")]
        public string add1 { get; set; }
        [Required(ErrorMessage = "Enter Address 2")]
        public string add2 { get; set; }

        public string iisstate { get; set; }
        [Required(ErrorMessage = "select State")]

        public string state { get; set; }
        [Required(ErrorMessage = "select District")]
        public string dist { get; set; }
        public string servicegp { get; set; }
        [Required(ErrorMessage = "select State")]
        public string servicestate { get; set; }
        [Required(ErrorMessage = "select District")]
        public string servicedist { get; set; }
        [Required(ErrorMessage = "select Block")]
        public string serviceblock { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string mobile { get; set; }
        [Required(ErrorMessage = "Select Type")]

        public string companytype { get; set; }
        [Required(ErrorMessage = "Enter Licence No.")]
        public string licenceno { get; set; }
        [Required(ErrorMessage = "Enter Signature Name")]
        public string signaturename { get; set; }
        public string dotfilepath { get; set; }
        public string gstinfilepath { get; set; }
        public string poafilepath { get; set; }
        public string poifilepath { get; set; }
        public string compdocfilepath { get; set; }
        public string panfilepath { get; set; }
        public string aadharfilepath { get; set; }
        public string aggrementfilepath { get; set; }
        public string pan { get; set; }
        public string gstin { get; set; }
        public string tan { get; set; }
        public string authorisedaadhar { get; set; }

    }
    public class stateModel
    {
        public string states_id { get; set; }

       
        public string states_name { get; set; }

        
    }

        public class distModel
    {
        public string states_id { get; set; }

        [Display(Name = "State Name")]
        public string states_name { get; set; }
        
        [Display(Name = "District Code")]
        public string districts_id { get; set; }
       
        [Display(Name = "District Name")]
        public string districts_name { get; set; }
        public int block_count { get; set; }
        public int? abd { get; set; }
        public int? districts_census_code { get; set; }
    }

    public class blockModel
    {
        public string states_id { get; set; }
        [Display(Name = "State Name")]
        public string states_name { get; set; }
        public string districts_id { get; set; }
        [Display(Name = "District Name")]
        public string districts_name { get; set; }
        [Display(Name = "Block Code")]
        public string blocks_id { get; set; }
        [Display(Name = "Block Name")]
        public string blocks_name { get; set; }
    }

    public class gpModel
    {
        public string states_id { get; set; }
        public string states_name { get; set; }
        public string districts_id { get; set; }
        public string districts_name { get; set; }
        public string blocks_id { get; set; }
        public string blocks_name { get; set; }
        public string gp_id { get; set; }
        public string gp_name { get; set; }
        public string up_status { get; set; }
        public string down_resion { get; set; }
    }

    public class OTP
    {
        [Required(ErrorMessage = "Enter OTP")]
        public string otp { get; set; }
    }

    public class managedistModel
    {
        public List<distModel> distModels { get; set; }
        //public abdcount abdcount { get; set; }
    }
    public class manageblockModel
    {
        public List<blockModel> blockModels { get; set; }
        public countModel countmodel { get; set; }
    }
    public class managegpModel
    {
        public List<gpModel> gpModels { get; set; }
        //public abdcount abdcount { get; set; }
    }
    public class gpfile
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Upload File")]
        public IFormFile filetoupload { get; set; }
    }

    public class countModel
    {
        public string state_count { get; set; }
        public string districts_count { get; set; }
        public string block_count { get; set; }
        public string gp_count { get; set; }
        public string gpup_count { get; set; }
        public string gpdown_count { get; set; }


    }


    public enum gpEnum
    {
        DOWN = 1,
        UP = 0
        
    }
    public sealed class gpMap : ClassMap<gpModel>
    {
        public gpMap()
        {
            Map(x => x.gp_id).Name("GP Code");
            Map(x => x.up_status).Name("Status");
        }
    }
}
