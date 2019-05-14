using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Ong
    {
        [Required]
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
        [Display(Name = "Usuário:")]
        public virtual Usuario Usuario_Id { get; set; }

        [Required]
        [Display(Name = "Endereço:")]
        public virtual Endereco Endereco_Id { get; set; }
        
    }
}