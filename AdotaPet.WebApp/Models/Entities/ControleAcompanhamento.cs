using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPet.WebApp.Models.Entities
{
    public class ControleAcompanhamento
    {
        [Required]
        public int Id { get; set; }

        public int Codigo { get; set; }

        public DateTime Data_Cadastro { get; set; }
        public Ong Ong_Id { get; set; }
        public Pessoa Pessoa_Id { get; set; }
        public string descricao { get; set; }
        public string status { get; set; }
     }
}