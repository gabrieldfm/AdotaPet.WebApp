using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPet.WebApp.Models.Entities
{
    public class GerenciamentoDenuncia
    {
        [Required]
        public int Id { get; set; }

        [Required][Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }

        [Required]
        [StringLength(250)][Display(Name = "Breve descrição da denúncia")]
        public string Denuncia { get; set; }

        [Required][StringLength(250)]
        public string Denunciante { get; set; }

        [Required][StringLength(14)]
        public string Telefone { get; set; }

        [Required][StringLength(10)]
        public string Status { get; set; }
    }
}