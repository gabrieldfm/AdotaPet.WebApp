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
using Microsoft.EntityFrameworkCore;

namespace AdotaPet.WebApp.Controllers
{
    public class AdocaoController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Adocao
        public ActionResult Index()
        {
            return View(db.Adocao.ToList());
        }

        // GET: Adocao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adocao adocao = db.Adocao.Find(id);
            if (adocao == null)
            {
                return HttpNotFound();
            }
            return View(adocao);
        }

        // GET: Adocao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adocao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Data_Cadastro,Data_Finalizacao")] Adocao adocao)
        {
            if (ModelState.IsValid)
            {
                db.Adocao.Add(adocao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adocao);
        }

        // GET: Adocao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adocao adocao = db.Adocao.Find(id);
            if (adocao == null)
            {
                return HttpNotFound();
            }
            return View(adocao);
        }

        // POST: Adocao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Data_Cadastro,Data_Finalizacao")] Adocao adocao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adocao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adocao);
        }

        // GET: Adocao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adocao adocao = db.Adocao.Find(id);
            if (adocao == null)
            {
                return HttpNotFound();
            }
            return View(adocao);
        }

        // POST: Adocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adocao adocao = db.Adocao.Find(id);
            db.Adocao.Remove(adocao);
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
        public JsonResult ObterPessoas()
        {
            return Json(db.Pessoa.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObterAnimais()
        {
            return Json(db.Animal.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
        }
        protected int ObterProximoCodigo()
        {
            return db.Adocao.Count() > 0 ? new ApplicationContext().Adocao.Where(d => d.Codigo > 0).Select(d => d.Codigo).Max() + 1 : 1;
        }
        public JsonResult Salvar(String data_finalizacao, String pessoa_Id)
        {
            Adocao adocao = new Adocao();

            adocao.Codigo = ObterProximoCodigo();
            adocao.Data_Cadastro = new DateTime();
            adocao.Data_Finalizacao = Convert.ToDateTime(data_finalizacao);
            adocao.Pessoa_Id = db.Pessoa.Find(Convert.ToInt32(pessoa_Id));
            adocao.Ong_Id = db.Ong.Find(1);
            db.Adocao.Add(adocao);
            db.SaveChanges();
            return Json(adocao, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdicionarItens(string adocao_Id, string animal_Id,string pessoa_Id)
        {
            Adocao_Itens adocaoItem = new Adocao_Itens();
            adocaoItem.Adocao_Id = db.Adocao.Find(Convert.ToInt32(adocao_Id));
            adocaoItem.Adocao_Id.Pessoa_Id = db.Pessoa.Find(Convert.ToInt32(pessoa_Id));
            adocaoItem.Animal_Id = db.Animal.Find(Convert.ToInt32(animal_Id));
            db.Adocao_Itens.Add(adocaoItem);
            db.SaveChanges();
            /*
            var obj = db.("SELECT Adocao_Itens.Id,Pessoa.Codigo as codigoPessoa, Pessoa.Nome as nomePessoa,Animal.Codigo codigoAnimal, Animal.Nome nomeAnimal FROM Pessoa INNER JOIN Adocao ON(Pessoa.id = Adocao.Pessoa_IdId) " +
                                                    "INNER JOIN Adocao_Itens ON(Adocao.Id = Adocao_Itens.Adocao_IdId) " +
                                                    "INNER JOIN Animal on(Animal.Id = Adocao_Itens.Animal_IdId) " +
                                                    "where Adocao_Itens.Adocao_IdId = 12 ").where("" );
*/
            var obj = new List<AdocaoDTO>();
            var itens = new List<Adocao_Itens>();
            itens = db.Adocao_Itens.Where(a => a.Adocao_Id.Id == Convert.ToInt32(adocao_Id)).ToList();
            foreach (Adocao_Itens item in itens)
            {
                var codPessoa = adocaoItem.Adocao_Id.Pessoa_Id.Codigo;
                var noPessoa = adocaoItem.Adocao_Id.Pessoa_Id.Nome;
                var codAnimal = adocaoItem.Animal_Id.Codigo;
                var noAnimal = adocaoItem.Animal_Id.Nome;
                obj.Add(new AdocaoDTO { Id = item.Id, codigoPessoa = codPessoa, codigoAnimal = codAnimal, nomePessoa = noPessoa, nomeAnimal = noAnimal });

            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}
