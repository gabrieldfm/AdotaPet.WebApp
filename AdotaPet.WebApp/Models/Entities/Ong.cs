using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Ong
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Razao_Social { get; set; }

        [Required]
        public string Nome_Fantasia { get; set; }

        [Required]
        public Usuario Usuario_Id { get; set; }

       [Required]
        public Endereco Endereco_Id { get; set; }
        
    }
}