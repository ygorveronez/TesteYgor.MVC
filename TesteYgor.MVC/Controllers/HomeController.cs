using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteYgor.MVC.Filters;

namespace TesteYgor.MVC.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            
            ViewBag.Message = DateTime.Now.ToString();

            return View();
        }
    }
}
