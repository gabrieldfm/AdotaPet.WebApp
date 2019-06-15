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
    public class ControleAcompanhamentoesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: ControleAcompanhamentoes
        public ActionResult Index()
        {
            return View(db.ControleAcompanhamento.ToList());
        }

        // GET: ControleAcompanhamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControleAcompanhamento controleAcompanhamento = db.ControleAcompanhamento.Find(id);
            if (controleAcompanhamento == null)
            {
                return HttpNotFound();
            }
            return View(controleAcompanhamento);
        }

        // GET: ControleAcompanhamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControleAcompanhamentoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Data_Cadastro,descricao,status")] ControleAcompanhamento controleAcompanhamento)
        {
            if (ModelState.IsValid)
            {
                db.ControleAcompanhamento.Add(controleAcompanhamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(controleAcompanhamento);
        }

        // GET: ControleAcompanhamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControleAcompanhamento controleAcompanhamento = db.ControleAcompanhamento.Find(id);
            if (controleAcompanhamento == null)
            {
                return HttpNotFound();
            }
            return View(controleAcompanhamento);
        }

        // POST: ControleAcompanhamentoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Data_Cadastro,descricao,status")] ControleAcompanhamento controleAcompanhamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controleAcompanhamento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(controleAcompanhamento);
        }

        // GET: ControleAcompanhamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControleAcompanhamento controleAcompanhamento = db.ControleAcompanhamento.Find(id);
            if (controleAcompanhamento == null)
            {
                return HttpNotFound();
            }
            return View(controleAcompanhamento);
        }

        // POST: ControleAcompanhamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControleAcompanhamento controleAcompanhamento = db.ControleAcompanhamento.Find(id);
            db.ControleAcompanhamento.Remove(controleAcompanhamento);
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
