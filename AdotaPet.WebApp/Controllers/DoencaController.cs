using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdotaPet.WebApp.Biblioteca;
using AdotaPet.WebApp.Models;
using AdotaPet.WebApp.Models.Entities;

namespace AdotaPet.WebApp.Controllers
{
    public class DoencaController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Doenca
        public ActionResult Index()
        {
            return View(db.Doenca.ToList());
        }

        // GET: Doenca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doenca doenca = db.Doenca.Find(id);
            if (doenca == null)
            {
                return HttpNotFound();
            }
            return View(doenca);
        }

        // GET: Doenca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doenca/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descricao")] Doenca doenca)
        {
            if (ModelState.IsValid)
            {
                doenca.Codigo = ObterProximoCodigo();
                db.Doenca.Add(doenca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doenca);
        }

        // GET: Doenca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doenca doenca = db.Doenca.Find(id);
            if (doenca == null)
            {
                return HttpNotFound();
            }
            return View(doenca);
        }

        // POST: Doenca/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descricao")] Doenca doenca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doenca).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doenca);
        }

        // GET: Doenca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doenca doenca = db.Doenca.Find(id);
            if (doenca == null)
            {
                return HttpNotFound();
            }
            return View(doenca);
        }

        // POST: Doenca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doenca doenca = db.Doenca.Find(id);
            db.Doenca.Remove(doenca);
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

        protected int ObterProximoCodigo()
        {
            return new ApplicationContext().Doenca.Where(d => d.Codigo > 0).Select(d => d.Codigo).Max()+ 1;
        }
            
    }
}
