using NICDBTKar.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace NICDBTKar.DBTKar
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtUsername.Text == string.Empty)
                {
                    lblError.Text = "please enter username";
                    return;
                }
                if (txtpsw.Text == string.Empty)
                {
                    lblError.Text = "please enter password";
                    return;
                }
                if (BSUser.login(txtUsername.Text, txtpsw.Text) == true)
                {

                    Response.Redirect("Default.aspx", false);
                    clear();
                }


                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        private void clear()
        {
            txtpsw.Text= string.Empty;
            txtUsername.Text= string.Empty;
        }
    }
}