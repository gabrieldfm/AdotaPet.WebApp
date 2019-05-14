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
    public class RacaController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        protected int ObterProximoCodigo()
        {
            return db.Raca.Count() > 0 ? new ApplicationContext().Raca.Where(x => x.Codigo > 0).Select(x => x.Codigo).Max() + 1 : 1;
        }
        // GET: Raca
        public ActionResult Index()
        {
            return View(db.Raca.ToList());
        }

        // GET: Raca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Raca.Find(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        // GET: Raca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raca/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descricao,Observacao,Ong_Id")] Raca raca)
        {
            if (ModelState.IsValid)
            {               
                raca.Codigo = ObterProximoCodigo();
                db.Raca.Add(raca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raca);
        }

        // GET: Raca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Raca.Find(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        // POST: Raca/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descricao,Observacao,Ong_Id")] Raca raca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raca).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raca);
        }

        // GET: Raca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Raca.Find(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        // POST: Raca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raca raca = db.Raca.Find(id);
            db.Raca.Remove(raca);
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
        [HttpPost]
        public JsonResult obterCodigo()
        {           
            return Json(ObterProximoCodigo(), JsonRequestBehavior.AllowGet);
        }
    }
}
