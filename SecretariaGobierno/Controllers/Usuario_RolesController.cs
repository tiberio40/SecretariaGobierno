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
    public class Usuario_RolesController : Controller
    {
        private SecretariaGobiernoContext db = new SecretariaGobiernoContext();

        // GET: Usuario_Roles
        public ActionResult Index()
        {
            var usuario_Roles = db.Usuario_Roles.Include(u => u.RolesUsuarios).Include(u => u.Usuario);
            return View(usuario_Roles.ToList());
        }

        // GET: Usuario_Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Roles usuario_Roles = db.Usuario_Roles.Find(id);
            if (usuario_Roles == null)
            {
                return HttpNotFound();
            }
            return View(usuario_Roles);
        }

        // GET: Usuario_Roles/Create
        public ActionResult Create()
        {
            ViewBag.RolesUsuarioID = new SelectList(db.RolesUsuarios, "RolesUsuarioID", "Nombre");
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres");
            return View();
        }

        // POST: Usuario_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuario_RolesID,Valor,RolesUsuarioID,UserName")] Usuario_Roles usuario_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_Roles.Add(usuario_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolesUsuarioID = new SelectList(db.RolesUsuarios, "RolesUsuarioID", "Nombre", usuario_Roles.RolesUsuarioID);
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres", usuario_Roles.UserName);
            return View(usuario_Roles);
        }

        // GET: Usuario_Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Roles usuario_Roles = db.Usuario_Roles.Find(id);
            if (usuario_Roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolesUsuarioID = new SelectList(db.RolesUsuarios, "RolesUsuarioID", "Nombre", usuario_Roles.RolesUsuarioID);
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres", usuario_Roles.UserName);
            return View(usuario_Roles);
        }

        // POST: Usuario_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuario_RolesID,Valor,RolesUsuarioID,UserName")] Usuario_Roles usuario_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolesUsuarioID = new SelectList(db.RolesUsuarios, "RolesUsuarioID", "Nombre", usuario_Roles.RolesUsuarioID);
            ViewBag.UserName = new SelectList(db.Usuarios, "UserName", "Nombres", usuario_Roles.UserName);
            return View(usuario_Roles);
        }

        // GET: Usuario_Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Roles usuario_Roles = db.Usuario_Roles.Find(id);
            if (usuario_Roles == null)
            {
                return HttpNotFound();
            }
            return View(usuario_Roles);
        }

        // POST: Usuario_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario_Roles usuario_Roles = db.Usuario_Roles.Find(id);
            db.Usuario_Roles.Remove(usuario_Roles);
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
