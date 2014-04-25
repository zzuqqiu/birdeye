using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BirdEye.Common.Entity;
using System.Xml;

namespace BirdEye.Server.Manager
{
    public class UserManager
    {
        private XmlDocument userDoc;
        private string dataPath;

        public UserManager()
        {
            this.dataPath = "c://BirdEye_data//user.xml";
            this.userDoc = new XmlDocument();
            this.userDoc.Load(dataPath);
        }

        public bool CreateUser(User user)
        {
            XmlElement e = this.userDoc.CreateElement("Node");
            e.SetAttribute("UserName", user.UserName);
            e.SetAttribute("Password", user.Password);
            e.SetAttribute("Email", user.Email);
            e.SetAttribute("PasswordQuestion", user.PasswordQuestion);
            e.SetAttribute("PasswordAnswer", user.PasswordAnswer);

            this.userDoc.SelectSingleNode("User").AppendChild(e);

            this.userDoc.Save(dataPath);
            return true;
        }

        public bool ValidateUser(string userName, string pwd)
        {
            XmlNode node = this.userDoc.SelectSingleNode("User");

            foreach (XmlNode item in node.ChildNodes)
            {
                XmlElement xe=(XmlElement)item;
                if (xe.GetAttribute("UserName") == userName && xe.GetAttribute("Password") == pwd)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
