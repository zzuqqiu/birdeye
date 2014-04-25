using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BirdEye.Common.Entity;
using BirdEye.Web.Manager;

namespace BirdEye.Web.Infrastructure
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //string userName = filterContext.HttpContext.Session["CurrentUser"] as string;
            
            //var controller = filterContext.RouteData.Values["controller"].ToString();
            //var action = filterContext.RouteData.Values["action"].ToString();
            //var isAllowed = this.IsAllowed(userName, controller, action);

            //if (!isAllowed)
            //{
            //    //filterContext.RequestContext.HttpContext.Response.Redirect("/Home/Index");
            //    //filterContext.RequestContext.HttpContext.Response.End();
            //}
        }

        private bool IsAllowed(string username, string controller, string action)
        {
            if (username == null)
            {
                return false;
            }
            return true;
        }

    }
}