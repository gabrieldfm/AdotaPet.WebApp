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
    public class GerenciamentoDenunciaController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        //OBTEM O PRÓXIMO CÓDIGO
        protected int ObterProximoCodigo()
        {
            return db.GerenciamentoDenuncia.Count() > 0 ? new ApplicationContext().GerenciamentoDenuncia.Where(d => d.Codigo > 0).Select(d => d.Codigo).Max() + 1 : 1;
        }

        // GET: GerenciamentoDenuncia
        public ActionResult Index()
        {
            return View(db.GerenciamentoDenuncia.ToList());
        }

        // GET: GerenciamentoDenuncia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GerenciamentoDenuncia gerenciamentoDenuncia = db.GerenciamentoDenuncia.Find(id);
            if (gerenciamentoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(gerenciamentoDenuncia);
        }

        // GET: GerenciamentoDenuncia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GerenciamentoDenuncia/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Denuncia,Denunciante,Telefone,Status, Ong_IdId")] GerenciamentoDenuncia gerenciamentoDenuncia)
        {
            if (ModelState.IsValid)
            {
                gerenciamentoDenuncia.Codigo = ObterProximoCodigo();
                Ong ong = db.Ong.Find(Session["Ong"]);
                gerenciamentoDenuncia.Ong_Id = ong; 
                db.GerenciamentoDenuncia.Add(gerenciamentoDenuncia);
                db.SaveChanges();
               // return RedirectToAction("Index");
            }

            return View(gerenciamentoDenuncia);
        }

        // GET: GerenciamentoDenuncia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GerenciamentoDenuncia gerenciamentoDenuncia = db.GerenciamentoDenuncia.Find(id);
            if (gerenciamentoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(gerenciamentoDenuncia);
        }

        // POST: GerenciamentoDenuncia/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Denuncia,Denunciante,Telefone,Status")] GerenciamentoDenuncia gerenciamentoDenuncia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gerenciamentoDenuncia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerenciamentoDenuncia);
        }

        // GET: GerenciamentoDenuncia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GerenciamentoDenuncia gerenciamentoDenuncia = db.GerenciamentoDenuncia.Find(id);
            if (gerenciamentoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(gerenciamentoDenuncia);
        }

        // POST: GerenciamentoDenuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GerenciamentoDenuncia gerenciamentoDenuncia = db.GerenciamentoDenuncia.Find(id);
            db.GerenciamentoDenuncia.Remove(gerenciamentoDenuncia);
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
