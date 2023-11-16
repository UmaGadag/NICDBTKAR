using NICDBTKar.Business;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NICDBTKar.DBTKar
{
    public partial class BeneficiaryDetails : System.Web.UI.Page
    {
        public string updates;
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Request.QueryString["Update"];
            
            if ( str != null)
            { 
                txtsearch.Visible = true;
                btnsearch.Visible = true;
            }
            else
            {
                txtsearch.Visible = false;
                btnsearch.Visible = false;

            }

            if (!Page.IsPostBack)
            {
                DataTable dt = BSBeneficiary.LoadDepartment();
                if (dt.Rows.Count > 0)
                {
                    ddlDepartment.DataSource = dt;
                    ddlDepartment.DataTextField = dt.Columns["DepartmentName"].ColumnName.ToString();
                    ddlDepartment.DataValueField = dt.Columns["DepartmentID"].ColumnName.ToString();
                    ddlDepartment.DataBind();
                }

            }

            if(Page.IsPostBack)
            {
               

            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddldep = (DropDownList)sender;
            initialddlscheme(ddlDepartment.SelectedIndex);

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string HashAadhar = string.Empty;
                if (lblError.Text ==null)
                {

                
                if (txtAadhaar.Text == string.Empty)
                {
                    lblError.Text = "Please enter your Aadhaar Number.";
                    lblError.Visible = true;
                    return;
                }
                else if (txtAadhaar.Text.Length > 12 || txtAadhaar.Text.Length < 12)
                {
                    lblError.Text = "Aadhaar Number should be 12 digit.";
                    lblError.Visible = true;
                    return;

                }
                else
                {
                    bool isValidnumber = aadharcard.validateVerhoeff(txtAadhaar.Text);
                    if (isValidnumber)
                    {
                        lblError.ForeColor = Color.Green;
                        lblError.Text = "Aadhaar Validation Success";
                        lblError.Visible = true;
                        HashAadhar = sha256(txtAadhaar.Text);
                    }
                    else
                    {

                        lblError.Text = "Invalid Aadhaar Number";
                        lblError.Visible = true;
                        return;
                    }

                }
                }

                if (txtBname.Text == string.Empty)
                {
                    lblError.Text = "Please enter Beneficiary name";
                    lblError.Visible = true;
                    return;
                }
                if (txtAddress.Text == string.Empty)
                {
                    lblError.Text = "Please enter Address name";
                    lblError.Visible = true;
                    return;
                }

                if (txtAadhaar.Text == string.Empty)
                {
                    lblError.Text = "Please enter Aadhaar Number";
                    lblError.Visible = true;
                    return;
                }
                if (ddlDepartment.SelectedIndex == 0)
                {
                    lblError.Text = "Please select Department";
                    lblError.Visible = true;
                    return;
                }
                if (ddlScheme.SelectedIndex == 0)
                {
                    lblError.Text = "Please select Scheme";
                    lblError.Visible = true;
                    return;
                }
                BSBeneficiary bSBeneficiary = new BSBeneficiary();
                string str = Request.QueryString["Update"];
                int id = 0;
                if (str != null)
                {
                    
                    id = Convert.ToInt32(lblError.Text);
                }
                else
                {
                    id = 0;

                }
                if (bSBeneficiary.SaveBeneficiary(id,txtBname.Text, txtAddress.Text, HashAadhar, ddlDepartment.SelectedItem.Text, ddlScheme.SelectedItem.Text) == true)
                {
                    lblError.Text="Record inserted successfully....";
                    clear();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void search_Click(object sender, EventArgs e)
        {
            
            string HashAadhar=string.Empty;
            decimal myDec;
            var Result = decimal.TryParse(txtsearch.Text, out myDec);
            if (Result ==true)
                { 
            BSBeneficiary bSBeneficiary = new BSBeneficiary();
                HashAadhar = sha256(txtAadhaar.Text);
                HashAadhar = "673883c4b1786ac54812f34f619e6196b8eb0eb2626e3d443445daa9057a4010";
            }
            else
            {
                HashAadhar=txtsearch.Text;
            }
            DataTable dt = BSBeneficiary.LoadBeneficiaryDetail(HashAadhar);
            if (dt.Rows.Count > 0)
            {
                txtBname.Text = dt.Rows[0]["BeneficiaryName"].ToString();
                txtAddress.Text= dt.Rows[0]["Address"].ToString();
                ddlDepartment.SelectedIndex= Convert.ToInt32 (dt.Rows[0]["DepartmentID"]);
                initialddlscheme(ddlDepartment.SelectedIndex);
                lblError.Text = dt.Rows[0]["BeneficiaryID"].ToString();
            }
            }
         

        
        static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        private void initialddlscheme(int dept)
        {
            DataTable dt = BSBeneficiary.LoadScheme(dept);
            if (dt.Rows.Count > 0)
            {
                ddlScheme.DataSource = dt;
                ddlScheme.DataTextField = dt.Columns["SchemeName"].ColumnName.ToString();
                ddlScheme.DataValueField = dt.Columns["SchemeID"].ColumnName.ToString();
                ddlScheme.DataBind();
            }
            txtsearch.Visible= false;
            btnsearch.Visible= false;
        }
        private void clear()
        {
            txtAadhaar.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtBname.Text= string.Empty;
            ddlDepartment.SelectedIndex = 0;
            ddlScheme.SelectedIndex = 0;
        }

    }
}