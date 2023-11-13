using NICDBTKar.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NICDBTKar.Business
{
    public class BSUser
    {
        string Username;
        string Password;
        public static bool login(string Username, string password) // No Parameter  
        {

            bool str = DBUser.login(Username,password);
            return str;
        }
    }
}