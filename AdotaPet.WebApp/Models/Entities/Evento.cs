using System;
using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Evento
    {
        [Required]
        public int Id { get; set; }

        public int Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Dt evento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_evento { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }
    }
}