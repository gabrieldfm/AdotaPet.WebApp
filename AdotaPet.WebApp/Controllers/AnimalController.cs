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
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                //animal.Castrado = new System.ComponentModel.DataAnnotations.DataType();

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
        protected int ObterProximoCodigo()
        {
            return db.Animal.Count() > 0 ? new ApplicationContext().Animal.Where(d => d.Codigo > 0).Select(d => d.Codigo).Max() + 1 : 1;
        }        
         public JsonResult ObterDoencas()
         {
            return Json(db.Doenca.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
         }
        public JsonResult ObterRacas()
        {
            return Json(db.Raca.Where(d => d.Codigo > 0).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Salvar(String nome,String porte,String vacinado,String vermifugado,String sexo,String doenca_Id,String raca_Id,String castrado,string Ong_Id,string id)
        {
            Animal animal = new Animal();
            if (id != null)
            { 
                animal = db.Animal.Find(Convert.ToInt32(id));

            }
            animal.Codigo = ObterProximoCodigo();
            animal.Castrado = Convert.ToChar(castrado);
            animal.Nome = nome;
            animal.Porte = Convert.ToInt16(porte);
            animal.Vacina = Convert.ToChar(vacinado);
            animal.Vermifugado = Convert.ToChar(vermifugado);
            animal.Sexo = Convert.ToChar(sexo);
            Doenca doenca = db.Doenca.Find(Convert.ToInt32(doenca_Id));
            animal.Doenca_Id = doenca;
            Raca raca = db.Raca.Find(Convert.ToInt32(raca_Id));
            animal.Raca_Id = raca;
            //refatorar para ong da sessão
            Ong ong = db.Ong.Find(Convert.ToInt32(Ong_Id));
            animal.Ong_Id = ong;
            if (id != null)
            {
                db.Entry(animal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                db.Animal.Add(animal);
            }
            db.SaveChanges();

            return Json(animal, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Editar(string parametro )
        {
            int id = Convert.ToInt32(parametro);
            Animal animal = db.Animal.Find(id);
            Ong ong = db.Ong.FromSql("SELECT ong.* FROM ong INNER JOIN animal ON(ong.id = animal.Ong_IdId) WHERE animal.id = {0}", id).FirstOrDefault();
            animal.Ong_Id = ong;
            Raca raca = db.Raca.FromSql("SELECT raca.* FROM raca INNER JOIN animal ON(raca.id = animal.Raca_IdId) WHERE animal.id = {0}", id).FirstOrDefault();
            animal.Raca_Id = raca;
            Doenca doenca = db.Doenca.FromSql("SELECT doenca.* FROM doenca INNER JOIN animal ON(doenca.id = animal.Doenca_IdId) WHERE animal.id = {0}", id).FirstOrDefault();
            animal.Doenca_Id = doenca;
            return Json(animal, JsonRequestBehavior.AllowGet);
        }
    }
}
