using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Endereco
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Cep { get; set; }
        
    }
}