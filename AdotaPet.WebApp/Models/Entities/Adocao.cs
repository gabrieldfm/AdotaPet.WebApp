using System;
using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Adocao
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        public DateTime Data_Cadastro { get; set; }

        [Required]
        public DateTime Data_Finalizacao { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }

        [Required]
        public Pessoa Pessoa_Id { get; set; }
    }
}