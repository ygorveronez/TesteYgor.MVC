using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteYgor.Domain.Models;
using TesteYgor.Domain.Repositories;

namespace TesteYgor.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : BaseController
    {

        private UsuarioRepository rep = new UsuarioRepository();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {   
            var lista = rep.SelectEntities().ToList();
            return View(lista);
        }

        public ActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario entity)
        {
            if (ModelState.IsValid)
            {
                rep.InsertEntity(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public ActionResult Edit(int id = 0)
        {   
            Usuario entity = rep.SelectEntity(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        public ActionResult Edit(Usuario entity)
        {   
            if (ModelState.IsValid)
            {
                rep.UpdateEntity(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public ActionResult Delete(int id = 0)
        {
            Usuario entity = rep.SelectEntity(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Usuario entity)
        {
            rep.DeleteEntity(entity);
            return RedirectToAction("Index");
        }

    }
}
