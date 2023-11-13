using NICDBTKar.DataAccess;
using System;
using System.Collections.Generic;
using NICDBTKar.DataAccess;
using System.Net.NetworkInformation;
using System.Web;
using System.Data;

namespace NICDBTKar.Business
{
    public class BSBeneficiary
    {
        string BeneficiaryName;
        string Address;
        string AadhaarNumber;
        string department;
        string Scheme;

        

        public bool SaveBeneficiary(string BeneficiaryName,string Address,string AadhaarNumber,string department,string Scheme) // No Parameter  
        {
            
            bool str = DBBeneficiary.SaveBeneficiary(BeneficiaryName, Address, AadhaarNumber, department, Scheme);
            return str;
        }
        public static DataTable LoadDepartment()
        {
            DataTable dt = DBBeneficiary.Department();
            return dt;
        }
        public static DataTable LoadScheme()
        {
            DataTable dt = DBBeneficiary.Scheme();
            return dt;
        }
        public static DataTable LoadBeneficiaryDetail(string search) // No Parameter  
        {

            DataTable dt = DBBeneficiary.Beneficiarydetail(search);
            return dt;
        }
    }
}