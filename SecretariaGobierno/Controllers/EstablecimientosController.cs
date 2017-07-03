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
    public class EstablecimientosController : Controller
    {
        private SecretariaGobiernoContext db = new SecretariaGobiernoContext();

        // GET: Establecimientos
        public ActionResult Index()
        {
            var establecimientoes = db.Establecimientos.Include(e => e.Usuario);
            return View(establecimientoes.ToList());
        }

        // GET: Establecimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            if (establecimiento == null)
            {
                return HttpNotFound();
            }
            return View(establecimiento);
        }

        // GET: Establecimientos/Create
        public ActionResult Create()
        {
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres");
            return View();
        }

        // POST: Establecimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstablecimientoID,Nombre,Propietario,UserName")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                db.Establecimientos.Add(establecimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres", establecimiento.UserName);
            return View(establecimiento);
        }

        // GET: Establecimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            if (establecimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres", establecimiento.UserName);
            return View(establecimiento);
        }

        // POST: Establecimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstablecimientoID,Nombre,Propietario,UserName")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establecimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres", establecimiento.UserName);
            return View(establecimiento);
        }

        // GET: Establecimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            if (establecimiento == null)
            {
                return HttpNotFound();
            }
            return View(establecimiento);
        }

        // POST: Establecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            db.Establecimientos.Remove(establecimiento);
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
