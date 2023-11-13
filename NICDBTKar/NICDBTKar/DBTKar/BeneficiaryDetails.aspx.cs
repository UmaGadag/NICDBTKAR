using NICDBTKar.Business;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;

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

            if (!IsPostBack)
            {
                DataTable dt = BSBeneficiary.LoadDepartment();
                if (dt.Rows.Count > 0)
                {
                    ddlDepartment.DataSource = dt;
                    ddlDepartment.DataTextField = dt.Columns["DepartmentName"].ColumnName.ToString();
                    ddlDepartment.DataValueField = dt.Columns["DepartmentID"].ColumnName.ToString();
                    ddlDepartment.DataBind();
                }
                dt.Clear();
                dt = BSBeneficiary.LoadScheme();
                if (dt.Rows.Count > 0)
                {
                    ddlScheme.DataSource = dt;
                    ddlScheme.DataTextField = dt.Columns["SchemeName"].ColumnName.ToString();
                    ddlScheme.DataValueField = dt.Columns["SchemeID"].ColumnName.ToString();
                    ddlScheme.DataBind();
                }

            }
        }
        

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string HashAadhar = string.Empty;
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
                if (bSBeneficiary.SaveBeneficiary(txtBname.Text, txtAddress.Text, HashAadhar, ddlDepartment.SelectedItem.Text, ddlScheme.SelectedItem.Text) == true)
                {
                    Response.Write("Record inserted successfully....");
                    clear();
                    lblError.Visible=false;
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
                ddlDepartment.SelectedItem.Text= dt.Rows[0]["DepartmentName"].ToString();
                ddlScheme.SelectedItem.Text = dt.Rows[0]["SchemeName"].ToString();
                lblError.Text = dt.Rows[0]["BeneficiaryID"].ToString();
            }
            }
         

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            

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