using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class RecebimentoDoacoes
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data de recebimento")]
        public DateTime Data_recebimento { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Item")]
        public string Item { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }
    }
}