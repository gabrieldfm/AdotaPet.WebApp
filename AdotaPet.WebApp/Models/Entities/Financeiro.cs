using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Financeiro
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(200)] [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required] [Display(Name = "Data da movimentação")]
        public DateTime Data_movimentacao { get; set; }

        [Required] [Display(Name = "Tipo da movimentação")]
        public char Entrada_saida { get; set; }

        [Required] [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Required]
        public Ong Ong_Id { get; set; }
    }
}