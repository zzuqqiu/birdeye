using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BirdEye.Web.Infrastructure;

namespace BirdEye.Web.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}