using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Usuario
    {
        [Key]
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

        public int OngId { get; set; }

        [ForeignKey(nameof(OngId))]
        [Display(Name = "Ong:")]
        public virtual Ong Ong { get; set; }

    }
}