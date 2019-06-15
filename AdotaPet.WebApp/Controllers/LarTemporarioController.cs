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
    public class LarTemporarioController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: LarTemporario
        public ActionResult Index()
        {
            return View(db.LarTemporario.ToList());
        }
        // GET: LarTemporario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LarTemporario larTemporario = db.LarTemporario.Find(id);
            if (larTemporario == null)
            {
                return HttpNotFound();
            }
            return View(larTemporario);
        }

        // GET: LarTemporario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LarTemporario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Observacao,Numero,Bairro,Logradouro,Cep,Cidade,UF,Complemento")] LarTemporario larTemporario)
        {
            if (ModelState.IsValid)
            {
                db.LarTemporario.Add(larTemporario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(larTemporario);
        }

        //API DOS CORREIOS
        [HttpPost]
        public JsonResult ObterCep(string cep)
        {
            try
            {/*
                using (var ws = new BuscaEndereco.AtendeClienteClient())
                {
                    var resultado = ws.consultaCEP(cep);
                    var obj = new
                    {
                        codigo = 200,
                        cidade = resultado.cidade,
                        endereco = resultado.end,
                        complemento = resultado.complemento2,
                        bairro = resultado.bairro,
                        uf = resultado.uf
                    };
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
                */
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var obj = new
                {
                    codigo = 500,
                    mensagem = ex.Message.ToString()
                };
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: LarTemporario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LarTemporario larTemporario = db.LarTemporario.Find(id);
            if (larTemporario == null)
            {
                return HttpNotFound();
            }
            return View(larTemporario);
        }

        // POST: LarTemporario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Observacao,Numero,Bairro,Logradouro,Cep,Cidade,UF,Complemento")] LarTemporario larTemporario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(larTemporario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(larTemporario);
        }

        // GET: LarTemporario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LarTemporario larTemporario = db.LarTemporario.Find(id);
            if (larTemporario == null)
            {
                return HttpNotFound();
            }
            return View(larTemporario);
        }

        // POST: LarTemporario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LarTemporario larTemporario = db.LarTemporario.Find(id);
            db.LarTemporario.Remove(larTemporario);
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

        //OBTEM O PRÓXIMO CÓDIGO
        protected int ObterProximoCodigo()
        {
            return db.LarTemporario.Count() > 0 ? new ApplicationContext().LarTemporario.Where(d => d.Codigo > 0).Select(d => d.Codigo).Max() + 1 : 1;
        }

        //BUSCA OS ANIMAIS
        public JsonResult ObterAnimais()
        {
            return Json(db.Animal.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
        }

        //BUSCA AS ONGS
        public JsonResult ObterOngs()
        {
            return Json(db.Ong.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
        }

        //BUSCA OS RESPONSAVEIS
        public JsonResult ObterPessoas()
        {
            return Json(db.Pessoa.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
        }

        //SALVAR
        public JsonResult Salvar(string Ong_Id,  string Numero, string Pessoa_Id, string Animal_Id, string Observacao, string Bairro, string CEP, string Cidade,
            string Complemento, string Logradouro, string UF, string id)
        {
            LarTemporario lar = new LarTemporario();
            if (id != null)
            {
                lar = db.LarTemporario.Find(Convert.ToInt32(id));

            }
            lar.Codigo = ObterProximoCodigo();
            lar.Numero = Convert.ToInt32(Numero);
            lar.Observacao = Observacao;
            lar.Bairro = Bairro;
            lar.Cep = CEP;
            lar.Cidade = Cidade;
            lar.Complemento = Complemento;
            lar.Logradouro = Logradouro;
            lar.UF = UF;
            Pessoa pessoa = db.Pessoa.Find(Convert.ToInt32(Pessoa_Id));
            lar.Pessoa_Id = pessoa;
            Animal animal = db.Animal.Find(Convert.ToInt32(Animal_Id));
            lar.Animal_Id = animal;
            //refatorar para ong da sessão
            Ong ong = db.Ong.Find(Convert.ToInt32(Ong_Id));
            lar.Ong_Id = ong;
            if (id != null)
            {
                db.Entry(lar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                db.LarTemporario.Add(lar);
            }
            db.SaveChanges();
            return Json(lar, JsonRequestBehavior.AllowGet);
        }

        //EDITAR
        [HttpPost]
        public JsonResult Editar(string parametro)
        {
            int id = Convert.ToInt32(parametro);
            LarTemporario lar = db.LarTemporario.Find(id);
            Pessoa pessoa = db.Pessoa.FromSql("SELECT pessoa.* FROM pessoa INNER JOIN LarTemporario ON(pessoa.id = LarTemporario.Pessoa_IdId) WHERE LarTemporario.id = {0}", id).FirstOrDefault();
            lar.Pessoa_Id = pessoa;
            Animal animal = db.Animal.FromSql("SELECT animal.* FROM animal INNER JOIN LarTemporario ON(animal.id = LarTemporario.Animal_IdId) WHERE LarTemporario.id = {0}", id).FirstOrDefault();
            lar.Animal_Id = animal;
            return Json(lar, JsonRequestBehavior.AllowGet);
        }
    }
}
