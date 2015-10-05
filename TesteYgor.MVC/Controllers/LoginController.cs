using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TesteYgor.Domain.Models;

namespace TesteYgor.MVC.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login entity)
        {
            if (ModelState.IsValid)
            {

                if (Membership.ValidateUser(entity.Email, entity.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "e-Mail ou senha inválidos");
                }
            }

            return View(entity);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
