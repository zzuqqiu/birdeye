using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BirdEye.Web.Models
{
    public class PersonInfo
    {
        public string Comment { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

		public string HeadPortrait { get; set; }

		public object ObHeadPortrait { get; set; }
    }
}