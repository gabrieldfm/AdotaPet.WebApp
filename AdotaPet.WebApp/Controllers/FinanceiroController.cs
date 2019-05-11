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
    public class FinanceiroController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Financeiro
        public ActionResult Index()
        {
            return View(db.Financeiro.ToList());
        }

        // GET: Financeiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiro.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // GET: Financeiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financeiro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Entrada_saida,Data_movimentacao,Valor")] Financeiro financeiro)
        {
            if (!ModelState.IsValid)
            {

                financeiro.Ong_Id = db.Ong.Find(1);
                db.Financeiro.Add(financeiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financeiro);
        }

        // GET: Financeiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiro.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Entrada_saida,Data_movimentacao,Valor")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financeiro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financeiro);
        }

        // GET: Financeiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiro.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Financeiro financeiro = db.Financeiro.Find(id);
            db.Financeiro.Remove(financeiro);
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
