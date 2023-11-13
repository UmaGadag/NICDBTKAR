using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace NICDBTKar.DataAccess
{
    public class DBUser
    {
        public string name, pass;
        public static bool login(string Username,string Password)
        {
            string strcon = ConfigurationManager.ConnectionStrings["NICDBTKar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("Select * from USER_MASTER Where UserName=@Username And Password=@Password", con);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                }
            }
        }

    }