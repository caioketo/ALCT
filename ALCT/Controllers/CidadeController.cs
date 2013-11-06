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
    public class CidadeController : Controller
    {
        private ALCTContext db = new ALCTContext();

        //
        // GET: /Cidade/

        public ActionResult Index()
        {
            var cidades = db.Cidades.Include(c => c.Estado);
            return View(cidades.ToList());
        }

        //
        // GET: /Cidade/Details/5

        public ActionResult Details(int id = 0)
        {
            CidadeModel cidademodel = db.Cidades.Find(id);
            if (cidademodel == null)
            {
                return HttpNotFound();
            }
            return View(cidademodel);
        }

        //
        // GET: /Cidade/Create

        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoId", "Descricao");
            return View();
        }

        //
        // POST: /Cidade/Create

        [HttpPost]
        public ActionResult Create(CidadeModel cidademodel)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidademodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoId", "Descricao", cidademodel.EstadoID);
            return View(cidademodel);
        }

        //
        // GET: /Cidade/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CidadeModel cidademodel = db.Cidades.Find(id);
            if (cidademodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoId", "Descricao", cidademodel.EstadoID);
            return View(cidademodel);
        }

        //
        // POST: /Cidade/Edit/5

        [HttpPost]
        public ActionResult Edit(CidadeModel cidademodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidademodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoId", "Descricao", cidademodel.EstadoID);
            return View(cidademodel);
        }

        //
        // GET: /Cidade/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CidadeModel cidademodel = db.Cidades.Find(id);
            if (cidademodel == null)
            {
                return HttpNotFound();
            }
            return View(cidademodel);
        }

        //
        // POST: /Cidade/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CidadeModel cidademodel = db.Cidades.Find(id);
            db.Cidades.Remove(cidademodel);
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