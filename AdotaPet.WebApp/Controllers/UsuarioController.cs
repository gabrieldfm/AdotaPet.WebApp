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

        // GET: Usuario
        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View(new Usuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario login, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var vLogin = db.Usuario.Where(p => p.Login.Equals(login.Login)).FirstOrDefault();
                /*Verificar se a variavel vLogin está vazia. 
                Isso pode ocorrer caso o usuário não existe. 
                Caso não exista ele vai cair na condição else.*/
                if (vLogin != null)
                {
                    /*Código abaixo verifica se o usuário que retornou na variavel tem está 
                      ativo. Caso não esteja cai direto no else*/
                    if (Equals(vLogin.Ativo, "S"))
                    {
                        /*Código abaixo verifica se a senha digitada no site é igual a 
                        senha que está sendo retornada 
                         do banco. Caso não cai direto no else*/
                        if (Equals(vLogin.Senha, login.Senha))
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
                            /*código abaixo cria uma session para armazenar o nome do usuário*/
                            Session["Nome"] = vLogin.Nome;
                            /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                            Session["Login"] = vLogin.Login;
                            /*retorna para a tela inicial do Home*/
                            return RedirectToAction("Index", "Home");
                        }
                        /*Else responsável da validação da senha*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Senha informada Inválida!!!");
                            /*Retorna a tela de login*/
                            return View(new Usuario());
                        }
                    }
                    /*Else responsável por verificar se o usuário está ativo*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!!!");
                        /*Retorna a tela de login*/
                        return View(new Usuario());
                    }
                }
                /*Else responsável por verificar se o usuário existe*/
                else
                {
                    /*Escreve na tela a mensagem de erro informada*/
                    ModelState.AddModelError("", "Login informado inválido!!!");
                    /*Retorna a tela de login*/
                    return View(new Usuario());
                }
            }

            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login 
            com as mensagem dos campos*/
            return View(login);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
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

        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Login,Senha,Perfil,Ativo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Perfil = "Usuario";
                usuario.Ativo = 'S';
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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
