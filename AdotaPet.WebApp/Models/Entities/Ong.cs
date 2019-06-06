using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Ong
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Razão social:")]
        public string Razao_Social { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Nome fantasia:")]
        public string Nome_Fantasia { get; set; }

        [Required, StringLength(18)]
        public string Cnpj { get; set; }

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