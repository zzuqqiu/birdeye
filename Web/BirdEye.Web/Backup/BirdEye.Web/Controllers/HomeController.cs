using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirdEye.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎光临鸟儿看!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult View371()
        {
            return View();
        }
    }
}
