using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Endereco
    {
        [Required]
        public int Id { get; set; }

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