using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Pessoa
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required, StringLength(200)]
        public string Nome { get; set; }

        [Required, StringLength(20)]
        public string Rg { get; set; }

        [Required, StringLength(14)]
        public string Cpf { get; set; }

        [Required, StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }

        [Required]
        public Endereco Endereco_Id { get; set; }
    }
}