using AdotaPet.WebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdotaPet.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        [AllowAnonymous]
        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View(new Usuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string senha, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var vLogin = db.Usuario.Where(p => p.Login.Equals(login)).FirstOrDefault();
                if (vLogin != null)
                {
                    if (Equals(vLogin.Ativo, 'S'))
                    {
                        if (Equals(vLogin.Senha, senha))
                        {
                            FormsAuthentication.SetAuthCookie(vLogin.Login, false);
                            if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            Session["Nome"] = vLogin.Nome;
                            Session["Login"] = vLogin.Login;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Senha informada Inválida!!!");
                            return View(new Usuario());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!!!");
                        return View(new Usuario());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login informado inválido!!!");
                    return View(new Usuario());
                }
            }

            return View(login);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Perfil = "Usuario";
                usuario.Ativo = 'S';
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Login,Senha,Perfil,Ativo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
