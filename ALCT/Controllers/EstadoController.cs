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
    public class EstadoController : Controller
    {
        private ALCTContext db = new ALCTContext();

        //
        // GET: /Estado/

        public ActionResult Index()
        {
            return View(db.Estados.ToList());
        }

        //
        // GET: /Estado/Details/5

        public ActionResult Details(int id = 0)
        {
            EstadoModel estadomodel = db.Estados.Find(id);
            if (estadomodel == null)
            {
                return HttpNotFound();
            }
            return View(estadomodel);
        }

        //
        // GET: /Estado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Estado/Create

        [HttpPost]
        public ActionResult Create(EstadoModel estadomodel)
        {
            if (ModelState.IsValid)
            {
                db.Estados.Add(estadomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadomodel);
        }

        //
        // GET: /Estado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EstadoModel estadomodel = db.Estados.Find(id);
            if (estadomodel == null)
            {
                return HttpNotFound();
            }
            return View(estadomodel);
        }

        //
        // POST: /Estado/Edit/5

        [HttpPost]
        public ActionResult Edit(EstadoModel estadomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadomodel);
        }

        //
        // GET: /Estado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EstadoModel estadomodel = db.Estados.Find(id);
            if (estadomodel == null)
            {
                return HttpNotFound();
            }
            return View(estadomodel);
        }

        //
        // POST: /Estado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoModel estadomodel = db.Estados.Find(id);
            db.Estados.Remove(estadomodel);
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