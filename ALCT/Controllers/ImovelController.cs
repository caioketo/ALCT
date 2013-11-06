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
            var imoveis = db.Imoveis.Include(i => i.Cidade);
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

        //
        // GET: /Imovel/Create

        public ActionResult Create()
        {
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeId", "Descricao");
            return View();
        }

        //
        // POST: /Imovel/Create

        [HttpPost]
        public ActionResult Create(ImovelModel imovelmodel)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Add(imovelmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeId", "Descricao", imovelmodel.CidadeID);
            return View(imovelmodel);
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