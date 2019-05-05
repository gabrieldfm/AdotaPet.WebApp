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
    public class AnimalController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Animal
        public ActionResult Index()
        {
            return View(db.Animal.ToList());
        }

        // GET: Animal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nome,Porte")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animal.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nome,Porte")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animal.Find(id);
            db.Animal.Remove(animal);
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
