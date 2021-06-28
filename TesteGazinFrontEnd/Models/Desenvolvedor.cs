using System;
using System.ComponentModel.DataAnnotations;

namespace TesteGazinFrontEnd.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome válido (máximo 50 caracteres)")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int? Idade { get; set; }

        [StringLength(100)]
        [Display(Name = "Hobby")]
        public string Hobby { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
