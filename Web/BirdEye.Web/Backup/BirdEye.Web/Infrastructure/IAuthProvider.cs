using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirdEye.Web.Infrastructure
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
