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
    public class InstanciasController : Controller
    {
        private SecretariaGobiernoContext db = new SecretariaGobiernoContext();

        // GET: Instancias
        public ActionResult Index()
        {
            var instancias = db.Instancias.Include(i => i.Establecimiento).Include(i => i.Estado);
            return View(instancias.ToList());
        }

        // GET: Instancias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instancia instancia = db.Instancias.Find(id);
            ViewBag.Observacion = db.Observacions.Where(s => s.InstanciaID == id).Select(p => p.Anotacion);
            if (instancia == null)
            {
                return HttpNotFound();
            }
            return View(instancia);
        }

        // GET: Instancias/Create
        public ActionResult Create()
        {
            ViewBag.EstablecimientoID = new SelectList(db.Establecimientos, "EstablecimientoID", "Nombre");
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "Nombre");
            return View();
        }

        // POST: Instancias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstanciaID,Folios,Actualizacion,EstablecimientoID,EstadoID")] Instancia instancia)
        {
            if (ModelState.IsValid)
            {
                db.Instancias.Add(instancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstablecimientoID = new SelectList(db.Establecimientos, "EstablecimientoID", "Nombre", instancia.EstablecimientoID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "Nombre", instancia.EstadoID);
            return View(instancia);
        }

        // GET: Instancias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instancia instancia = db.Instancias.Find(id);
            if (instancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstablecimientoID = new SelectList(db.Establecimientos, "EstablecimientoID", "Nombre", instancia.EstablecimientoID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "Nombre", instancia.EstadoID);
            return View(instancia);
        }

        // POST: Instancias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstanciaID,Folios,Actualizacion,EstablecimientoID,EstadoID")] Instancia instancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstablecimientoID = new SelectList(db.Establecimientos, "EstablecimientoID", "Nombre", instancia.EstablecimientoID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "Nombre", instancia.EstadoID);
            return View(instancia);
        }

        // GET: Instancias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instancia instancia = db.Instancias.Find(id);
            if (instancia == null)
            {
                return HttpNotFound();
            }
            return View(instancia);
        }

        // POST: Instancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instancia instancia = db.Instancias.Find(id);
            db.Instancias.Remove(instancia);
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
