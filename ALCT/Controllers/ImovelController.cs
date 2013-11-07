using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALCT.Models;

namespace ALCT.Controllers
{
    public class ImovelController : Controller
    {
        private ALCTContext db = new ALCTContext();

        //
        // GET: /Imovel/

        public ActionResult Index()
        {
            var imoveis = db.Imoveis.Include(i => i.Cidade).Include(i => i.Planta);
            return View(imoveis.ToList());
        }

        //
        // GET: /Imovel/Details/5

        public ActionResult Details(int id = 0)
        {
            ImovelModel imovelmodel = db.Imoveis.Find(id);
            if (imovelmodel == null)
            {
                return HttpNotFound();
            }
            return View(imovelmodel);
        }

        public ActionResult Paredes(int id = 0)
        {
            ImovelModel imovelmodel = db.Imoveis.Find(id);
            if (imovelmodel == null)
            {
                return HttpNotFound();
            }
            return View(imovelmodel);
        }

        [HttpPost]
        public JsonResult Paredes(ImovelModel imovelmodel)
        {
            foreach (ParedeModel parede in imovelmodel.Paredes)
            {
                parede.ImovelID = imovelmodel.ImovelId;
                db.Paredes.Add(parede);
            }
            db.SaveChanges();
            return Json(new { Success = 1, ex = "OK" });
        }

        //
        // GET: /Imovel/Create

        public ActionResult Create()
        {
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeId", "Descricao");
            ViewBag.ImagemID = new SelectList(db.ImagemModels, "ImagemId", "Caminho");
            return View();
        }

        //
        // POST: /Imovel/Create

        [HttpPost]
        public JsonResult Create(ImovelModel imovelmodel)
        {
            imovelmodel.Contato = db.Contatos.Add(imovelmodel.Contato);
                
            if (ModelState.IsValid)
            {
                db.Imoveis.Add(imovelmodel);
                db.SaveChanges();
                return Json(new { Success = 1, ex = "" });
            }
            return Json(new { Success = 0, ex = "Erro" });
        }

        //
        // GET: /Imovel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ImovelModel imovelmodel = db.Imoveis.Find(id);
            if (imovelmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeId", "Descricao", imovelmodel.CidadeID);
            ViewBag.ImagemID = new SelectList(db.ImagemModels, "ImagemId", "Caminho", imovelmodel.ImagemID);
            return View(imovelmodel);
        }

        //
        // POST: /Imovel/Edit/5

        [HttpPost]
        public ActionResult Edit(ImovelModel imovelmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imovelmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeId", "Descricao", imovelmodel.CidadeID);
            ViewBag.ImagemID = new SelectList(db.ImagemModels, "ImagemId", "Caminho", imovelmodel.ImagemID);
            return View(imovelmodel);
        }

        //
        // GET: /Imovel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ImovelModel imovelmodel = db.Imoveis.Find(id);
            if (imovelmodel == null)
            {
                return HttpNotFound();
            }
            return View(imovelmodel);
        }

        //
        // POST: /Imovel/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ImovelModel imovelmodel = db.Imoveis.Find(id);
            db.Imoveis.Remove(imovelmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}