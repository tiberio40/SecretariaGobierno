using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecretariaGobierno.Models;

namespace SecretariaGobierno.Controllers
{
    public class ObservacionsController : Controller
    {
        private SecretariaGobiernoContext db = new SecretariaGobiernoContext();

        // GET: Observacions
        public ActionResult Index(int? id)
        {
            var observacions = db.Observacions.Include(o => o.Instancia).Where(p => p.InstanciaID == id);
            return View(observacions.ToList());
        }

        // GET: Observacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observacion observacion = db.Observacions.Find(id);
            if (observacion == null)
            {
                return HttpNotFound();
            }
            return View(observacion);
        }

        // GET: Observacions/Create
        public ActionResult Create(int? id)
        {
            ViewBag.InstanciaID = new SelectList(db.Instancias, "InstanciaID", "InstanciaID");
            return View();
        }

        // POST: Observacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObservacionID,Anotacion,InstanciaID")] Observacion observacion, int id)
        {
            if (ModelState.IsValid)
            {
                observacion.InstanciaID = id;
                db.Observacions.Add(observacion);
                db.SaveChanges();
                return RedirectToAction("Details", "Instancias", new { id= id });
            }

            ViewBag.InstanciaID = new SelectList(db.Instancias, "InstanciaID", "InstanciaID", observacion.InstanciaID);
            return View(observacion);
        }

        // GET: Observacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observacion observacion = db.Observacions.Find(id);
            if (observacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstanciaID = new SelectList(db.Instancias, "InstanciaID", "InstanciaID", observacion.InstanciaID);
            return View(observacion);
        }

        // POST: Observacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObservacionID,Anotacion,InstanciaID")] Observacion observacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstanciaID = new SelectList(db.Instancias, "InstanciaID", "InstanciaID", observacion.InstanciaID);
            return View(observacion);
        }

        // GET: Observacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observacion observacion = db.Observacions.Find(id);
            if (observacion == null)
            {
                return HttpNotFound();
            }
            return View(observacion);
        }

        // POST: Observacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Observacion observacion = db.Observacions.Find(id);
            db.Observacions.Remove(observacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
