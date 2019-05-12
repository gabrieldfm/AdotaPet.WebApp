using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Doenca
    {
        [Required]
        public int Id { get; set; }        
        
        public int Codigo { get; set; }

        [Required, StringLength(200)]
        public string Descricao { get; set; }

        [StringLength(200)]
        public string Grupo { get; set; }

        public Ong Ong_Id { get; set; }
    }
}