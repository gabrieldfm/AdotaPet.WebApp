using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdotaPet.WebApp.Models;
using AdotaPet.WebApp.Models.Entities;

namespace AdotaPet.WebApp.Biblioteca
{
    public class Geral
    {
        AdotaPetWebAppContext db = new AdotaPetWebAppContext();
        public int obterProximoCodigo(string classe)
        {
            return db.Database.SqlQuery<int>("SELECT MAX(codigo) FROM "+classe).ToList()[0] + 1; ;
        }
    }
}