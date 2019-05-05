using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdotaPet.WebApp.Models;
using AdotaPet.WebApp.Models.Entities;

namespace AdotaPet.WebApp.Biblioteca
{
    public static class Geral
    {
        public static int obterProximoCodigo(string classe)
        {
            //var teste = new ApplicationContext()..Count();
            return new AdotaPetWebAppContext().Database.SqlQuery<int>("SELECT MAX(codigo) FROM "+classe).ToList()[0] + 1; ;
        }
    }
}