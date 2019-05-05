using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Animal
    {
        [Required]
        public int Id { get; set; }

        public int Codigo { get; set; }

        [Required, StringLength(200)]
        public string Nome { get; set; }

        [Required]
        public short Porte { get; set; }

        [Required]
        public char Vacina { get; set; }

        [Required]
        public char Vermifugado { get; set; }

        [Required]
        public char Sexo { get; set; }
       
        public DataType Castrado { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }

        [Required]
        public Doenca Doenca_Id { get; set; }

        [Required]
        public Raca Raca_Id { get; set; }
    }
}