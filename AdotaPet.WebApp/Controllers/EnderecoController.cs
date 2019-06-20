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
    public class EnderecoController : Controller
    {

        private ApplicationContext db = new ApplicationContext();

        // GET: Endereco
        public ActionResult Index()
        {
            return View(db.Endereco.ToList());
        }

        // GET: Endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Bairro,Logradouro,Cep,Cidade,UF,Complemento")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        //API DOS CORREIOS
       /* [HttpPost]
        public JsonResult ObterCep(string cep)
        {
            try
            {
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
            }
            catch(Exception ex)
            {

                var obj = new
                {
                    codigo = 500,
                    mensagem = ex.Message.ToString() 
                };
                return Json(obj, JsonRequestBehavior.AllowGet); 
            } 

        } */

        // GET: Endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Bairro,Logradouro,Cep,Cidade,UF,Complemento")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            db.Endereco.Remove(endereco);
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
