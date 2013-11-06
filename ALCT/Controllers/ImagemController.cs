using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALCT.Models;
using ALCT.Util;

namespace ALCT.Controllers
{
    public class ImagemController : Controller
    {
        private ALCTContext db = new ALCTContext();

        //
        // GET: /Imagem/

        public ActionResult Index()
        {
            return View(db.ImagemModels.ToList());
        }

        //
        // GET: /Imagem/Details/5

        public ActionResult Details(int id = 0)
        {
            ImagemModel imagemmodel = db.ImagemModels.Find(id);
            if (imagemmodel == null)
            {
                return HttpNotFound();
            }
            return View(imagemmodel);
        }

        //
        // GET: /Imagem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Imagem/Create

        [HttpPost]
        public ActionResult Create(ImagemModel imagemmodel)
        {
            if (ModelState.IsValid)
            {
                db.ImagemModels.Add(imagemmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagemmodel);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files["file"];
            JsonNetResult jsonNetResult = new JsonNetResult();
            ImagemModel imagemmodel = new ImagemModel();
            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                      + file.FileName);
                imagemmodel.Caminho = file.FileName;
                imagemmodel = db.ImagemModels.Add(imagemmodel);
                db.SaveChanges();
                jsonNetResult.Data = imagemmodel;
            }
            else
            {
                jsonNetResult.Data = null;
            }

            return jsonNetResult;
        }

        //
        // GET: /Imagem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ImagemModel imagemmodel = db.ImagemModels.Find(id);
            if (imagemmodel == null)
            {
                return HttpNotFound();
            }
            return View(imagemmodel);
        }

        //
        // POST: /Imagem/Edit/5

        [HttpPost]
        public ActionResult Edit(ImagemModel imagemmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagemmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagemmodel);
        }

        //
        // GET: /Imagem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ImagemModel imagemmodel = db.ImagemModels.Find(id);
            if (imagemmodel == null)
            {
                return HttpNotFound();
            }
            return View(imagemmodel);
        }

        //
        // POST: /Imagem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagemModel imagemmodel = db.ImagemModels.Find(id);
            db.ImagemModels.Remove(imagemmodel);
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