//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using BirdEye.Web.Models;
//using BirdEye.Common.Entity;
//using BirdEye.Web.Manager;

//namespace BirdEye.Web.Infrastructure
//{
//    public class SiteMember : LogOnModel
//    {
//    }

//    public class MyMembershipProvider : MembershipProvider
//    {
//        private string providerName = "MyMembershipProvider";

//        public override bool ValidateUser(string username, string password)
//        {
//            return new UserManager().ValidateUser(username, password);
//        }

//        public override string ApplicationName
//        {
//            get
//            {
//                return this.providerName;
//            }
//            set
//            {
//                this.providerName = value;
//            }
//        }

//        public override bool ChangePassword(string username, string oldPassword, string newPassword)
//        {
//            return new UserManager().ChangePassword(username, oldPassword, newPassword);
//        }

//        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
//        {
//            return new UserManager().ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
//        }

//        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
//        {
//            User user = new User
//            {
//                UserName=username,
//                Password=password,
//                Email=email,
//                PasswordAnswer=passwordAnswer,
//                PasswordQuestion = passwordQuestion
//            };

//            UserManager manager = new UserManager();
//            bool result = manager.CreateUser(user);

//            status = result ? MembershipCreateStatus.Success : MembershipCreateStatus.UserRejected;

//            return null;
//        }

//        public override bool DeleteUser(string username, bool deleteAllRelatedData)
//        {
//            return new UserManager().DeleteUser(username, deleteAllRelatedData);
//        }

//        public override bool EnablePasswordReset
//        {
//            get { return new UserManager().EnablePasswordReset; }
//        }

//        public override bool EnablePasswordRetrieval
//        {
//            get { return new UserManager().EnablePasswordRetrieval; }
//        }
//    }
//}