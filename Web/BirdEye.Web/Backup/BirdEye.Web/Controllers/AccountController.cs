﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using BirdEye.Web.Models;
using BirdEye.Web.Manager;
using BirdEye.Common.Entity;
using BirdEye.Common.Configure;
using BirdEye.Common.Enum;

namespace BirdEye.Web.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string username;
                if (new UserManager().ValidateUser(model.AccountId, model.Password, out username))
                {
                    FormsAuthentication.SetAuthCookie(model.AccountId, model.RememberMe);
                    Session[ConstantHelper.CurrentUser] = model.AccountId;

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "账户名或密码不对");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                bool createStatus = new UserManager().CreateUser(new CommonUser
                {
                    AccountId = model.AccountId,
                    UserName = model.AccountId,
                    Password = model.Password,
                    Comment = string.Empty,
                    Email = model.Email,
                    HaveSetUserName = false,
                });

                if (createStatus)
                {
                    FormsAuthentication.SetAuthCookie(model.AccountId, false /* createPersistentCookie */);
                    Session[ConstantHelper.CurrentUser] = model.AccountId;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(MembershipCreateStatus.InvalidUserName));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize]
        public ActionResult PersonCenter()
        {
            return View();
        }

        [Authorize]
        public ActionResult BasicData()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyInterest()
        {
            return View();
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        public JsonResult Save(PersonInfo updateUser)
        {
            CommonUser user = new CommonUser();
            user.UserName = updateUser.UserName;
            user.Email = updateUser.Email;
            user.Comment = updateUser.Comment;
            user.AccountId = User.Identity.Name;

            UpdateUserStatus status = new UserManager().UpdateUser(user);

            switch (status)
            {
                case UpdateUserStatus.InvalidEmailFormat:
                    return Json(UpdateUserStatus.InvalidEmailFormat.ToString());
                case UpdateUserStatus.MultipleUserName:
                    return Json(UpdateUserStatus.MultipleUserName.ToString());
                case UpdateUserStatus.InvalidAccountId:
                    return Json(UpdateUserStatus.InvalidAccountId.ToString());
                case UpdateUserStatus.ServerError:
                    return Json(UpdateUserStatus.ServerError.ToString());
            }

            Session[ConstantHelper.CurrentUser] = user.UserName;
            return Json(updateUser);
        }

        public JsonResult GetWelcomeUserName()
        {
            if (Session[ConstantHelper.CurrentUser] == null)
            {
                string username = new UserManager().GetUserNameById(User.Identity.Name);
                Session[ConstantHelper.CurrentUser] = username;
            }

            return Json(Session[ConstantHelper.CurrentUser].ToString());
        }

        [HttpGet]
        public JsonResult InitialBasicData()
        {
            PersonInfo info = new PersonInfo();
            if (Request.IsAuthenticated)
            {
                string username = User.Identity.Name;
                CommonUser u = new UserManager().GetUser(username);
                if (u != null)
                {
                    info.UserName = u.HaveSetUserName ? u.UserName : string.Empty;
                    info.Email = u.Email;
                    info.Comment = u.Comment;
                }
            }

            return Json(info, JsonRequestBehavior.AllowGet);
        }
      
        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
