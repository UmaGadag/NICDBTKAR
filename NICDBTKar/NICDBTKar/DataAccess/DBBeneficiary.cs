using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace NICDBTKar.DataAccess
{
    public class DBBeneficiary
    {

        public static bool SaveBeneficiary(int Id,string BeneficiaryName,string Address,string AadhaarNumber, string DepartmentName,string SchemeName)
        {
            string strcon = ConfigurationManager.ConnectionStrings["NICDBTKar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertUpdateBENEFICIARY_DETAILS", con);
                con.Open();
                cmd.Parameters.AddWithValue("@BeneficiaryID", Id);
                cmd.Parameters.AddWithValue("@BeneficiaryName", BeneficiaryName);
                cmd.Parameters.AddWithValue("@Address",Address);
                cmd.Parameters.AddWithValue("@AadhaarNumber",AadhaarNumber);
                cmd.Parameters.AddWithValue("@DepartmentName",DepartmentName);
                cmd.Parameters.AddWithValue("@SchemeName",SchemeName );
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                int i = cmd.ExecuteNonQuery();
                //clientGuid = Convert.ToString(cmd.Parameters["@Guid"].Value);
                return true;
            }
            return false;
        }

        public static DataTable Department()
        {
            string strcon = ConfigurationManager.ConnectionStrings["NICDBTKar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("Select 0[DepartmentID],'--Select Department--'[DepartmentName] UNION Select DepartmentID,DepartmentName from DEPARTMENT_MASTER", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable Beneficiarydetail(String search)
        {
            string strcon = ConfigurationManager.ConnectionStrings["NICDBTKar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("sp_BENEFICIARY_DETAILS_BNA", con);
                con.Open();
                cmd.Parameters.AddWithValue("@search", search);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public static DataTable Scheme(int DepartmentID)
        {
            string strcon = ConfigurationManager.ConnectionStrings["NICDBTKar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("Select 0[SchemeID],'--Select Scheme--'[SchemeName] UNION Select SchemeID,SchemeName from SCHEMES_MASTER  Where DepartmentID=@DeprtmentId", con);
               cmd.Parameters.AddWithValue("@DeprtmentId", DepartmentID);
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}