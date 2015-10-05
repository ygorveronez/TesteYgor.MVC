using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteYgor.Domain.Models;
using TesteYgor.Domain.Repositories;

namespace TesteYgor.MVC.Controllers
{
    [Authorize]
    public class TransportadoraController : BaseController
    {
        //
        // GET: /Transportadora/

        private TransportadoraRepository rep = new TransportadoraRepository();

        public ActionResult Index()
        {
            var lista = rep.SelectEntities().ToList();
            return View(lista);
        }

        public ActionResult Classificar()
        {
            ViewBag.UserId = User.Id;
            var lista = rep.SelectEntities().OrderByDescending(o => o.Avaliacoes.Count).ToList();
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Transportadora entity)
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
            Transportadora entity = rep.SelectEntity(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        public ActionResult Edit(Transportadora entity)
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
            Transportadora entity = rep.SelectEntity(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Transportadora entity)
        {
            rep.DeleteEntity(entity);
            return RedirectToAction("Index");
        }



        public JsonResult ClassificarTrasnportadora()
        {
            AvaliacaoTransportadora entity = new AvaliacaoTransportadora();
            entity.Transportadora_Id = int.Parse(Request.Form["Transportadora_Id"]);
            entity.Avaliacao = int.Parse(Request.Form["Avaliacao"]);
            entity.Usuario_Id = User.Id;
            entity.DataAvaliacao = DateTime.Now;
            rep.AvaliarTransportadora(entity);

            Transportadora transportadora = rep.SelectEntity(int.Parse(Request.Form["Transportadora_Id"]));

            var media = ((float)transportadora.Avaliacoes.Sum(s => s.Avaliacao) / (float)(transportadora.Avaliacoes.Count() == 0 ? 1 : transportadora.Avaliacoes.Count()));

            return Json(media);
        }
    }
}
