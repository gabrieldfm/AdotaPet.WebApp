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
        protected int ObterProximoCodigo()
        {
            return db.ControleAcompanhamento.Count() > 0 ? new ApplicationContext().ControleAcompanhamento.Where(d => d.Codigo > 0).Select(d => d.Codigo).Max() + 1 : 1;
        }
        public JsonResult Salvar(string pessoa_Id, string data_cadastro, string avaliacao, string descricao)
        {
            ControleAcompanhamento acompanhamento = new ControleAcompanhamento();
            acompanhamento.Codigo = ObterProximoCodigo();
            acompanhamento.Data_Cadastro = new DateTime();
            acompanhamento.Pessoa_Id = db.Pessoa.Find(Convert.ToInt32(pessoa_Id));
            acompanhamento.status = avaliacao;
            acompanhamento.descricao = descricao;
            db.ControleAcompanhamento.Add(acompanhamento);
            db.SaveChanges();

            return Json(db.ControleAcompanhamento.Where(d => d.Codigo > 0).Include(d => d.Pessoa_Id).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObterAcompanhamento()
        {
            return Json(db.ControleAcompanhamento.Where(d => d.Codigo > 0).Include(d => d.Pessoa_Id).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
