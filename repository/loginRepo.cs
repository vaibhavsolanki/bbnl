using bbnl.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace bbnl.repository
{
    public class loginRepo
    {
        private string connectionString;


        public loginRepo(IConfiguration configuration)
        {

            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        public loginmodel LoginCheck(string userid, string pass,string usertype)
        {
            loginmodel lm = new loginmodel();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
               // string query = "SELECT * FROM abddiagram_tbl where block_id=" + block_id + " and type='2' and status =1";
                string query = "select user_id,password,state from bbnl_user where user_id='" + userid + "' and password='" + pass + "' and user_type='"+ usertype +"'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lm.UserId = Convert.ToString(dt.Rows[0]["user_id"]);
                    lm.Password = Convert.ToString(dt.Rows[0]["password"]);
                    lm.StateId = Convert.ToString(dt.Rows[0]["state"]);
                }
                conn.Close();
            }
            return lm;
        }



        public PSUUserLogin LoginpsuCheck(string userid, string pass)
        {
            PSUUserLogin lm = new PSUUserLogin();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                // string query = "SELECT * FROM abddiagram_tbl where block_id=" + block_id + " and type='2' and status =1";
                string query = "select email,password,state from bbnl_psu_user where email='" + userid + "' and password='" + pass + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lm.UserId = Convert.ToString(dt.Rows[0]["email"]);
                    lm.Password = Convert.ToString(dt.Rows[0]["password"]);
                    lm.state = Convert.ToString(dt.Rows[0]["state"]);
                }
                conn.Close();
            }
            return lm;
        }
    }
}
