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
        public int Numero { get; set; }

        [Required, StringLength(200)]
        public string Bairro { get; set; }

        [Required, StringLength(200)]
        public string Logradouro { get; set; }

        [Required, StringLength(30)]
        public string Cep { get; set; }

        [Required, StringLength(200)]
        public string Cidade { get; set; }

        [Required, StringLength(2)]
        public string UF { get; set; }

        [StringLength(200)]
        public string Complemento { get; set; }
    }
}