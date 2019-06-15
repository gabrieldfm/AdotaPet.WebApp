using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPet.WebApp.Models
{
    public class AdocaoDTO
    {
        public int Id { get; set; }

        public int codigoPessoa { get; set; }

        
        public int codigoAnimal { get; set; }

        public string nomeAnimal { get; set; }

        public string nomePessoa { get; set; }

    }
}