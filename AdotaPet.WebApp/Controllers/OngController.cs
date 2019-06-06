using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdotaPet.WebApp.Models;
using AdotaPet.WebApp.Models.Entities;

namespace AdotaPet.WebApp.Controllers
{
    public class OngController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Index()
        {
            return View(db.Ong.ToList());
        }

        // GET: Ong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ong ong = db.Ong.Find(id);
            if (ong == null)
            {
                return HttpNotFound();
            }
            return View(ong);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ong/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ong ong)
        {
            if (ModelState.IsValid)
            {
                db.Ong.Add(ong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ong);
        }

        // GET: Ong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ong ong = db.Ong.Find(id);
            if (ong == null)
            {
                return HttpNotFound();
            }
            return View(ong);
        }

        // POST: Ong/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Razao_Social,Nome_Fantasia,Cnpj")] Ong ong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ong).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ong);
        }

        // GET: Ong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ong ong = db.Ong.Find(id);
            if (ong == null)
            {
                return HttpNotFound();
            }
            return View(ong);
        }

        // POST: Ong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ong ong = db.Ong.Find(id);
            db.Ong.Remove(ong);
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
