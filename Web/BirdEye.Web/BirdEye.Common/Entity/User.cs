using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirdEye.Common.Entity
{
    public class CommonUser
    {
        public string Comment { get; set; }
        
        public DateTime CreationDate { get; set;}
        
        public string Email { get; set; }
        
        public bool IsApproved { get; set; }
        
        public bool IsLockedOut { get; set;}
        
        public bool IsOnline { get; set;}
        
        public DateTime LastActivityDate { get; set; }
        
        public DateTime LastLockoutDate { get; set; }
        
        public DateTime LastLoginDate { get; set; }
        
        public DateTime LastPasswordChangedDate { get;set; }
      
        public string PasswordQuestion { get; set;}

        public string PasswordAnswer { get; set; }
        
        public object ProviderUserKey { get; set;}

        public string UserName { get; set;}

        public string AccountId { get; set; }

        public string Password { get; set; }

        public bool HaveSetUserName { get; set; }

		public string HeadPortrait { get; set; }

		public object ObHeadPortrait { get; set; }
    }
}
