using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }
    }
}