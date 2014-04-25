﻿using System;
using System.Xml;
using BirdEye.Common.Configure;
using BirdEye.Common.Entity;
using BirdEye.Common.Enum;

namespace BirdEye.Web.Repository
{
    public class UserRepository
    {
        private XmlDocument userDoc;
        private string dataPath;

        internal UserRepository()
        {
            this.dataPath = "c://BirdEye_data//user.xml";
            this.userDoc = new XmlDocument();
            this.userDoc.Load(dataPath);
        }

        internal bool CreateUser(CommonUser user)
        {
            XmlElement e = this.userDoc.CreateElement(ConstantHelper.Node);
            e.SetAttribute(ConstantHelper.AccountId, user.AccountId);
            e.SetAttribute(ConstantHelper.UserName, user.UserName);
            e.SetAttribute(ConstantHelper.Password, user.Password);
            e.SetAttribute(ConstantHelper.Email, user.Email);
            e.SetAttribute(ConstantHelper.HaveSetUserName, user.HaveSetUserName.ToString());
            e.SetAttribute(ConstantHelper.PasswordQuestion, user.PasswordQuestion);
            e.SetAttribute(ConstantHelper.PasswordAnswer, user.PasswordAnswer);

            this.userDoc.SelectSingleNode(ConstantHelper.User).AppendChild(e);

            this.userDoc.Save(this.dataPath);
            return true;
        }

        internal bool ValidateUser(string accountid, string pwd, out string username)
        {
            XmlNode node = this.userDoc.SelectSingleNode(ConstantHelper.User);

            foreach (XmlNode item in node.ChildNodes)
            {
                XmlElement xe = (XmlElement)item;
                if (xe.GetAttribute(ConstantHelper.AccountId).ToUpper() == accountid.ToUpper() && xe.GetAttribute(ConstantHelper.Password).ToUpper() == pwd.ToUpper())
                {
                    username = xe.GetAttribute(ConstantHelper.UserName);
                    return true;
                }
            }

            username = string.Empty;
            return false;
        }

        internal bool ValidateUser(string accountid, string pwd, out string username, out bool haveSetUserName)
        {
            XmlNode node = this.userDoc.SelectSingleNode(ConstantHelper.User);

            foreach (XmlNode item in node.ChildNodes)
            {
                XmlElement xe = (XmlElement)item;
                if (xe.GetAttribute(ConstantHelper.AccountId).ToUpper() == accountid.ToUpper() && xe.GetAttribute(ConstantHelper.Password).ToUpper() == pwd.ToUpper())
                {
                    username = xe.GetAttribute(ConstantHelper.UserName);
                    haveSetUserName = Convert.ToBoolean(xe.GetAttribute(ConstantHelper.HaveSetUserName));
                    return true;
                }
            }

            username = string.Empty;
            haveSetUserName = false;
            return false;
        }

        internal CommonUser GetUser(string id)
        {
            XmlNode node = this.userDoc.SelectSingleNode(ConstantHelper.User);

            CommonUser user = null;
            foreach (XmlNode item in node.ChildNodes)
            {
                XmlElement xe = (XmlElement)item;
                if (xe.GetAttribute(ConstantHelper.AccountId).ToUpper() == id.ToUpper())
                {
                    user = new CommonUser
                    {
                        AccountId = xe.GetAttribute(ConstantHelper.AccountId),
                        UserName = xe.GetAttribute(ConstantHelper.UserName),
                        Email = xe.GetAttribute(ConstantHelper.Email),
                        Comment = xe.GetAttribute(ConstantHelper.Comment),
                        PasswordQuestion = xe.GetAttribute(ConstantHelper.PasswordQuestion),
                        PasswordAnswer = xe.GetAttribute(ConstantHelper.PasswordAnswer),
                        HaveSetUserName = Convert.ToBoolean(xe.GetAttribute(ConstantHelper.HaveSetUserName))
                    };
                }
            }
            return user;
        }

        internal string GetUserNameById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(ConstantHelper.AccountId);
                }

                XmlNode node = this.userDoc.SelectSingleNode(ConstantHelper.User);

                foreach (XmlNode item in node.ChildNodes)
                {
                    XmlElement xe = (XmlElement)item;
                    string currentId = xe.GetAttribute(ConstantHelper.AccountId).ToUpper();
                    if (currentId == id.ToUpper())
                    {
                        return xe.GetAttribute(ConstantHelper.UserName);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message; ;
            }

            return id;
        }

        internal UpdateUserStatus UpdateUser(CommonUser user)
        {
            try
            {
                XmlNode node = this.userDoc.SelectSingleNode(ConstantHelper.User);

                foreach (XmlNode item in node.ChildNodes)
                {
                    XmlElement xe = (XmlElement)item;
                    string currentId = xe.GetAttribute(ConstantHelper.AccountId).ToUpper();
                    if (currentId == user.AccountId.ToUpper())
                    {
                        // Check whether current User name is single or not
                        foreach (var sub in node.ChildNodes)
                        {
                            XmlElement e = (XmlElement)sub;
                            if (e.GetAttribute(ConstantHelper.UserName).ToUpper() == user.UserName.ToUpper()
                                && e.GetAttribute(ConstantHelper.AccountId).ToUpper() != currentId)
                            {
                                return UpdateUserStatus.MultipleUserName;
                            }
                        }

                        xe.SetAttribute(ConstantHelper.UserName, user.UserName);
                        xe.SetAttribute(ConstantHelper.Email, user.Email);
                        xe.SetAttribute(ConstantHelper.Comment, user.Comment);
                        xe.SetAttribute(ConstantHelper.HaveSetUserName, bool.TrueString);
                        this.userDoc.Save(this.dataPath);

                        return UpdateUserStatus.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                return UpdateUserStatus.ServerError;
            }

            return UpdateUserStatus.InvalidAccountId;
        }

        #region To Do

        internal bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            XmlNode node = this.userDoc.SelectSingleNode(ConstantHelper.User);

            foreach (var item in node.ChildNodes)
            {
                XmlElement xe = (XmlElement)item;
                if (xe.GetAttribute(ConstantHelper.UserName).ToUpper() == username.ToUpper() && xe.GetAttribute(ConstantHelper.Password).ToUpper() == oldPassword.ToUpper())
                {
                    xe.SetAttribute(ConstantHelper.Password, newPassword);
                    this.userDoc.Save(this.dataPath);
                    return true;
                }
            }

            return false;
        }

        internal bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        internal bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public bool EnablePasswordReset { get; set; }

        public bool EnablePasswordRetrieval { get; set; }

        #endregion
    }
}
