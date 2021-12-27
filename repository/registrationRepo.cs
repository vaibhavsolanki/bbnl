using bbnl.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bbnl.repository
{
    public class registrationRepo
    {
        private string connectionString;


        public registrationRepo(IConfiguration configuration)
        {

            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }



        public List<registrationmodel> getdatabystateid(string StateId,string usertype)
        {
           List<registrationmodel> rmodel = new List<registrationmodel>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                string result = "";
                string query = "";
                if (usertype == "psu") { 
                   query = "select companyname,add1,add2,state,dist, s.states_name, d.districts_name,email,mobile,companytype,licenceno,signaturename,dotfilepath," +
                    " gstinfilepath,poafilepath,poifilepath,compdocfilepath, g.gp_name as servicegp from bbnl_tbl b left join " + '"'+"States"+'"'+" s on b.state::integer = s.states_id"+ 
                    " left join "+'"'+"Districts"+'"'+ " d on b.dist::integer = d.districts_id left join gp_table g on g.gp_id::integer=b.servicegp::integer where state='" + StateId + "' order by date::date desc";
                }
                if (usertype == "admin")
                {
                    query = "select companyname,add1,add2,state,dist, s.states_name, d.districts_name,email,mobile,companytype,licenceno,signaturename,dotfilepath," +
                     " gstinfilepath,poafilepath,poifilepath,compdocfilepath, g.gp_name as servicegp from bbnl_tbl b left join " + '"' + "States" + '"' + " s on b.state::integer = s.states_id" +
                     " left join " + '"' + "Districts" + '"' + " d on b.dist::integer = d.districts_id left join gp_table g on g.gp_id::integer=b.servicegp::integer order by date::date desc";
                }
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //rmodel.companyname = Convert.ToString(dt.Rows[0]["companyname"]);
                    //rmodel.add1 = Convert.ToString(dt.Rows[0]["add1"]);
                    //rmodel.add2 = Convert.ToString(dt.Rows[0]["add2"]);
                    //rmodel.state = Convert.ToString(dt.Rows[0]["state"]);                   
                    //rmodel.dist = Convert.ToString(dt.Rows[0]["dist"]);
                    //rmodel.email = Convert.ToString(dt.Rows[0]["email"]);
                    //rmodel.mobile = Convert.ToString(dt.Rows[0]["mobile"]);
                    //rmodel.companytype = Convert.ToString(dt.Rows[0]["companytype"]);
                    //rmodel.signaturename = Convert.ToString(dt.Rows[0]["signaturename"]);
                    //rmodel.dotfilepath = Convert.ToString(dt.Rows[0]["dotfilepath"]);
                    //rmodel.gstinfilepath = Convert.ToString(dt.Rows[0]["gstinfilepath"]);
                    //rmodel.poifilepath = Convert.ToString(dt.Rows[0]["poafilepath"]);
                    //rmodel.poafilepath = Convert.ToString(dt.Rows[0]["poifilepath"]);
                    //rmodel.compdocfilepath = Convert.ToString(dt.Rows[0]["compdocfilepath"]);
                   result= JsonConvert.SerializeObject(dt);
                   rmodel= JsonConvert.DeserializeObject<List<registrationmodel>>(result);
                }
                conn.Close();
                return rmodel;
            }
        }

        public int GetMaxIdPsuUser()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {

                string query = "select max(id) from bbnl_psu_user";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                int FinalMaxId;
                if (dt.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0][0])))
                    {
                        FinalMaxId = 1;
                    }
                    else
                    {
                        string MaxInvoiceNo = Convert.ToString(dt.Rows[0][0]);

                        FinalMaxId = Convert.ToInt32(MaxInvoiceNo) + 1;
                    }
                }
                else
                {
                    FinalMaxId = 1;
                }
                conn.Close();
                return FinalMaxId;
            }
        }
        public int insertpsuUser(PSUUser model)
        {
            string query = "insert into bbnl_psu_user (regno, " +
                "Name, " +
                "state, " +
                "Email, " +
                "Mobile, " +
                "status, " +
                 "password, " +
                "date) " +
                "VALUES(@regno, " +
                "@Name, " +
                "@state, " +
                "@email, " +
                "@mobile, " +               
                "@status, " +
                "@password, " +
                "@date) ";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            int MaxId = GetMaxIdPsuUser();
            var maxregno = MaxId.ToString("D7");
            cmd.Parameters.AddWithValue("@regno", maxregno);
            cmd.Parameters.AddWithValue("@Name", DbNullIfNull(model.Name));
            cmd.Parameters.AddWithValue("@state", DbNullIfNull(model.state));
            cmd.Parameters.AddWithValue("@email", DbNullIfNull(model.email));
            cmd.Parameters.AddWithValue("@mobile", DbNullIfNull(model.mobile));
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@password", "Default@321");
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
            conn.Open();
            int z = cmd.ExecuteNonQuery();
            conn.Close();
            return 1;
        }
        public (string,string)  registerdata(string regno)
        {
            
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    // string storedprocname = "BBNLSoftware_SP_GenerateInvoice";
                    // var currentfinYear = getfinancialYer();

                    //string query = "select * from bbnl_tbl where regno='"+regno+"'";

                    NpgsqlCommand cmd = new NpgsqlCommand("getregdata", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("p_regno", regno);
                    //cmd.Parameters.AddWithValue("p_district", 1);

                   // cmd.CommandType = CommandType.Text;

                    //  cmd1.CommandTimeout = 0;

                    conn.Open();

                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(dt);
                    return (dt.Rows[0][0].ToString(),dt.Rows[0][0].ToString());

                }
            }
            catch (Exception ex)
            {

            }
           // return ret;
            return ("","");
        }
        public string statepmulisthead(string state)
        {
            string ret="";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                   

                    NpgsqlCommand cmd = new NpgsqlCommand("getstatepmulist", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_state", state);
                   

                    conn.Open();

                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(dt);
                    ret = dt.Rows[0][0].ToString();
                    //return (dt.Rows[0][0].ToString(), dt.Rows[0][0].ToString());

                }
            }
            catch (Exception ex)
            {

            }
            // return ret;
            return ret;
        }

        public string insertreg(registrationmodelwithoutfile model)
        {
            model.date = DateTime.Now.ToString("dd-MM-yyyy");
            string query = "insert into bbnl_tbl (regno, " +
                "companyname, " +
                "add1, " +
                "add2, " +
                   "iisstate, " +
                "state, " +
                "dist, " +
                "servicegp, " +
                 "servicestate, " +
                  "servicedistrict, " +
                   "serviceblock, " +
                "email, " +
                "mobile, " +
                "companytype, " +
                "licenceno, " +
                "signaturename, pan,tan,gstin,authorisedaadhar,panfilepath,aoafilepath,aggrementfilepath," +
                "dotfilepath, " +
                "gstinfilepath, " +
                "poafilepath, " +
                "poifilepath, " +
                "compdocfilepath, " +
                "status, " +
                "date) " +
                "VALUES(@regno, " +
                "@companyname, " +
                "@add1, " +
                "@add2, " +
                 "@iisstate, " +
                "@state, " +
                "@dist, " +
                "@servicegp, " +
                "@servicestate, " +
                      "@servicedistrict, " +
                         "@serviceblock, " +
                "@email, " +
                "@mobile, " +
                "@companytype, " +
                "@licenceno, " +
                "@signaturename,@pan,@tan,@gstin,@authorisedaadhar,@panfilepath,@aadharfilepath,@aggrementfilepath," +
                "@dotfilepath, " +
                "@gstinfilepath, " +
                "@poafilepath, " +
                "@poifilepath, " +
                "@compdocfilepath, " +
                "@status, " +
                "@date) ";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            string MaxId = GetMaxIdState(model.state,model.dist);
            var maxregno = MaxId;//MaxId.ToString("D7");
            model.regno = MaxId;
            cmd.Parameters.AddWithValue("@regno", maxregno);

            cmd.Parameters.AddWithValue("@companyname", DbNullIfNull(model.companyname));
            cmd.Parameters.AddWithValue("@add1", DbNullIfNull(model.add1));
            cmd.Parameters.AddWithValue("@add2", DbNullIfNull(model.add2));
            cmd.Parameters.AddWithValue("@iisstate", DbNullIfNull(model.iisstate));
            cmd.Parameters.AddWithValue("@state", DbNullIfNull(model.state));
            cmd.Parameters.AddWithValue("@dist", DbNullIfNull(model.dist));
            cmd.Parameters.AddWithValue("@servicegp", DbNullIfNull(model.servicegp));
            cmd.Parameters.AddWithValue("@servicestate", DbNullIfNull(model.servicestate));
            cmd.Parameters.AddWithValue("@servicedistrict", DbNullIfNull(model.servicedist));
            cmd.Parameters.AddWithValue("@serviceblock", DbNullIfNull(model.serviceblock));

            cmd.Parameters.AddWithValue("@email", DbNullIfNull(model.email));
            cmd.Parameters.AddWithValue("@mobile", DbNullIfNull(model.mobile));
            cmd.Parameters.AddWithValue("@companytype", DbNullIfNull(model.companytype));
            cmd.Parameters.AddWithValue("@licenceno", DbNullIfNull(model.licenceno));
            cmd.Parameters.AddWithValue("@signaturename", DbNullIfNull(model.signaturename));


            cmd.Parameters.AddWithValue("@pan", DbNullIfNull(model.pan));
            cmd.Parameters.AddWithValue("@tan", DbNullIfNull(model.tan));
            cmd.Parameters.AddWithValue("@gstin", DbNullIfNull(model.gstin));
            cmd.Parameters.AddWithValue("@authorisedaadhar", DbNullIfNull(model.authorisedaadhar));
            cmd.Parameters.AddWithValue("@panfilepath", DbNullIfNull(model.panfilepath));
            cmd.Parameters.AddWithValue("@aadharfilepath", DbNullIfNull(model.aadharfilepath));
            cmd.Parameters.AddWithValue("@aggrementfilepath", DbNullIfNull(model.aggrementfilepath));
            cmd.Parameters.AddWithValue("@dotfilepath", DbNullIfNull(model.dotfilepath));
            cmd.Parameters.AddWithValue("@gstinfilepath", DbNullIfNull(model.gstinfilepath));
            cmd.Parameters.AddWithValue("@poafilepath", DbNullIfNull(model.poafilepath));
            cmd.Parameters.AddWithValue("@poifilepath", DbNullIfNull(model.poifilepath));
            cmd.Parameters.AddWithValue("@compdocfilepath", DbNullIfNull(model.compdocfilepath));
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());


            conn.Open();
            int z = cmd.ExecuteNonQuery();
            conn.Close();
         // (model.state,model.dist) =registerdata(model.regno);
            return JsonConvert.SerializeObject(model);
        }


        public List<PSUUser> getpsuuser()
        {
            List<PSUUser> rmodel = new List<PSUUser>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                string result = "";
                string query = "select u.name,u.email,u.mobile,s.states_name as state from bbnl_psu_user u left join "+'"'+ "States"+'"'+" s on s.states_id=u.state::integer";
                
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   
                    result = JsonConvert.SerializeObject(dt);
                    rmodel = JsonConvert.DeserializeObject<List<PSUUser>>(result);
                }
                conn.Close();
                return rmodel;
            }
        }

        public static object DbNullIfNull(object obj)
        {
            return string.IsNullOrEmpty(Convert.ToString(obj)) ? DBNull.Value : obj;
        }
        public string GetMaxIdState(string state,string district)
        {
            string ret = "";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    // string storedprocname = "BBNLSoftware_SP_GenerateInvoice";
                    // var currentfinYear = getfinancialYer();

                    //string query = "select max(id) from bbnl_tbl";

                    NpgsqlCommand cmd = new NpgsqlCommand("genmaxid", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("p_callval", 1);

                    cmd.Parameters.AddWithValue("p_state",state);
                    cmd.Parameters.AddWithValue("p_district",district);

                    //  cmd1.CommandTimeout = 0;

                    conn.Open();

                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(dt);
                    ret = dt.Rows[0][0].ToString();

                }
            }
            catch(Exception ex)
            {

            }
                return ret;
        }


            public int GetMaxId()
        {


            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                // string storedprocname = "BBNLSoftware_SP_GenerateInvoice";
                // var currentfinYear = getfinancialYer();

                string query = "select max(id) from bbnl_tbl";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;

                //  cmd1.CommandTimeout = 0;

                conn.Open();

                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                int FinalMaxId;


                if (dt.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0][0])))
                    {
                        FinalMaxId = 1;
                    }
                    else
                    {
                        string MaxInvoiceNo = Convert.ToString(dt.Rows[0][0]);

                        FinalMaxId = Convert.ToInt32(MaxInvoiceNo) + 1;
                    }

                }



                else

                {
                    FinalMaxId = 1;

                }



                conn.Close();
                return FinalMaxId;
            }
        }

       public bool isvalidemail(string email)
        {

            
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
               
             string query = "select * from bbnl_tbl where email='"+email+"'";
                
               
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                return true;
            }

                   
        }

        public bool isvalidmobile(string mobile)
        {


            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {

                string query = "select * from bbnl_tbl where mobile='" + mobile+"'";


                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                return true;
            }


        }


        public bool isvalidpsuemail(string email)
        {


            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {

                string query = "select * from bbnl_psu_user where email='" + email + "'";


                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                return true;
            }


        }

        public bool isvalidpsumobile(string mobile)
        {


            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {

                string query = "select * from bbnl_psu_user where mobile='" + mobile + "'";


                NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                cmd1.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                return true;
            }


        }

        public int ReadgpCSVFile(string location)
        {

            int x = 0;
            try
            {
               

                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    
                    csv.Context.RegisterClassMap<gpMap>();
                    var records = csv.GetRecords<gpModel>().ToList();
                    foreach (var gp in records)
                    {
                        if (Enum.IsDefined(typeof(gpEnum), gp.up_status.ToUpper()))
                        {

                        }
                        else
                        {
                            x++;
                        }
                    }
                    if (x == 0)
                    {
                        return updategp(records);
                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int updategp(List<gpModel> gps)
        {
            //foreach (var gp in gps)
            //{
            //    if (Enum.IsDefined(typeof(gpEnum), gp.gp_status))
            //    {
            //        gp.gp_status = (string)Enum.Parse(typeof(gpEnum), gp.gp_status);
            //    }
            //}
            int i = 0;
            foreach (gpModel gp in gps)
            {
                string query = "update gp_table set up_status= " + (int)Enum.Parse(typeof(gpEnum), gp.up_status.ToUpper()) +
                    " where gp_id= '" + gp.gp_id + "'";
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            //return i;
            return i;
        }

    }
}
