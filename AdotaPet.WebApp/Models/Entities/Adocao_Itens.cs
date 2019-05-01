using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Adocao_Itens
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public Adocao Adocao_Id { get; set; }

        [Required]
        public Animal Animal_Id { get; set; }
    }
}