using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Login { get; set; }

        [Required, StringLength(200)]
        public string Senha { get; set; }

        [StringLength(15)]
        public string Perfil { get; set; }

        public char Ativo { get; set; }

    }
}