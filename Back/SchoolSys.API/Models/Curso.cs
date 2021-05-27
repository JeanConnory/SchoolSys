using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolSys.API.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }

        public int QtdHoras { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}