using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bbnl.repository
{
    public class common
    {
        private string connectionString;


        public common(IConfiguration configuration)
        {

            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
        public string getalldist()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            //            string query = "select distinct " + '"' + "Districts" + '"' + ".districts_id," + '"' + "Districts" + '"' + ".districts_name, " + '"' + "Districts" + '"' + ".districts_census_code, abddiagram_tbl.district_id as abd " +
            //                " from" + '"' + "Districts" + '"' + " left join (select distinct district_id from abddiagram_tbl where status=1 and state_id =" + stateid + ") as" + '"' + "abddiagram_tbl" + '"' +
            //"on " + '"' + "Districts" + '"' + ".districts_id =" + '"' + "abddiagram_tbl" + '"' + ".district_id where" + '"' + "Districts" + '"' + ".states_id = " + stateid +
            //" order by districts_name";

            string query = "select distinct districts_id,districts_name,states_id,states_name from" + '"' + "Districts" + '"' + "   order by districts_name";// where states_id = '" + stateid+ "'
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }
        public string getdist(string stateid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
//            string query = "select distinct " + '"' + "Districts" + '"' + ".districts_id," + '"' + "Districts" + '"' + ".districts_name, " + '"' + "Districts" + '"' + ".districts_census_code, abddiagram_tbl.district_id as abd " +
//                " from" + '"' + "Districts" + '"' + " left join (select distinct district_id from abddiagram_tbl where status=1 and state_id =" + stateid + ") as" + '"' + "abddiagram_tbl" + '"' +
//"on " + '"' + "Districts" + '"' + ".districts_id =" + '"' + "abddiagram_tbl" + '"' + ".district_id where" + '"' + "Districts" + '"' + ".states_id = " + stateid +
//" order by districts_name";

            string query= "select distinct districts_id,districts_name,states_id,states_name from" + '"'+"Districts"+'"'+ " where states_id = '" + stateid + "'  order by districts_name";// 
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }

        public string getblock(string distid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "select distinct sta_dis_blk_new.blocks_id,sta_dis_blk_new.blocks_name from sta_dis_blk_new  where districts_id='" + distid + "'  order by blocks_name";//
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }
        public string getallblock()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "select distinct sta_dis_blk_new.blocks_id,sta_dis_blk_new.blocks_name,sta_dis_blk_new.districts_id from sta_dis_blk_new   order by blocks_name";// where districts_id='"+ distid+"'
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }

        public string getgp(string block, string type)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "";
            //if (type == "All" || type == "gp")
            //{
                query = "select distinct gp_id,gp_name,states_id,states_name,districts_id,districts_name,blocks_id,blocks_name, gp_status,up_status,down_resion from gp_table where blocks_id=" +
                    "'" + block + "' order by gp_name";
            //}
            //else
            //{
            //    query = "select distinct gp_id,gp_name,states_id,states_name,districts_id,districts_name,blocks_id,blocks_name, gp_status from gp_table where blocks_id=" +
            //   "'" + block + "' and gp_status=" + Convert.ToInt32(type) + " order by gp_name";
            //}
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }

        public string getstate()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "select * from " + '"' + "States" + '"' + " order by states_name";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }


        public string saveFile(IFormFile formFile, string folder)
        {
            var dotfiledata = formFile;
            if (dotfiledata != null && dotfiledata.Length > 0)
            {
                var fileName = Path.GetFileName(dotfiledata.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(dotfiledata.FileName);
                var extension = Path.GetExtension(dotfiledata.FileName);
                string vardatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");
                var newfilenamewithextension = vardatetime + filenamewithoutextension + extension;
                string foldername = "wwwroot/" + folder;
                var path = Path.Combine(Directory.GetCurrentDirectory(), foldername, newfilenamewithextension);
                if (!Directory.Exists(foldername))
                {
                    Directory.CreateDirectory(foldername);
                }
                FileInfo file = new FileInfo(Path.Combine(path));
                var stream = new FileStream(path, FileMode.Create);
                dotfiledata.CopyTo(stream);
                stream.Close();
                return folder + "/" + newfilenamewithextension;
            }
            return null;
        }


        public string getl14(int block_id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "SELECT * FROM abddiagram_tbl where block_id="+block_id+" and type='2' and status =1";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }

        public string getcount()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "select count (*) as state_count , ( select count (*)  from " +'"'+"Districts"+'"'+") as districts_count, " +
                "(select count(*)  from sta_dis_blk_new) as block_count,(select count(*)  from gp_table) as gp_count, " +
                "( select count (*)  from gp_table where up_status=0 or up_status is null) as gpup_count, " +
                "( select count (*)  from gp_table where up_status=1) as gpdown_count from " + '"'+"States"+'"';
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }

        public string countwrtstate(string stateid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "select count(*) as districts_count, (select count(*) from sta_dis_blk_new where states_id='" + stateid+"') as block_count, " +
                "(select count(*)  from gp_table where states_id='" + stateid + "') as gp_count, " +
                "(select count (*)  from gp_table where (up_status=0 or up_status is null) and states_id='" + stateid + "') as gpup_count, " +
                "( select count (*)  from gp_table where up_status=1 and states_id='" + stateid + "') as gpdown_count from " + '"'+"Districts"+'"'+ " where states_id = '" + stateid + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }

        public string countwrtdist(string distid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query = "select count(*)   as gp_count, (select count (*)  from gp_table where (up_status=0 or up_status is null) and districts_id='"+distid+"') as gpup_count, " +
                "( select count (*)  from gp_table where up_status=1 and districts_id='" + distid + "') as gpdown_count from gp_table where districts_id = '" + distid + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.Close();
            return JsonConvert.SerializeObject(dt);
        }
    }
}
