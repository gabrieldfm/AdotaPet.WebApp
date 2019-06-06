using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class LarTemporario
    {
        [Required]
        public int Id { get; set; }

        [Required][Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }

        [Required]
        public Pessoa Pessoa_Id { get; set; }

        [Required]
        public Animal Animal_Id { get; set; }

        [StringLength(200)][Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Required][Display(Name = "Número")]
        public int Numero { get; set; }

        [Required, StringLength(200)]
        public string Bairro { get; set; }

        [Required, StringLength(200)]
        public string Logradouro { get; set; }

        [Required, StringLength(30)][Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required, StringLength(200)]
        public string Cidade { get; set; }

        [Required, StringLength(2)]
        public string UF { get; set; }

        [StringLength(200)][Display(Name = "Comp.")]
        public string Complemento { get; set; }
    }
}