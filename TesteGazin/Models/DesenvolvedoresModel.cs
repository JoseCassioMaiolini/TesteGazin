using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteGazinAPI.Models
{
    [Table("Desenvolvedores")]
    public class DesenvolvedoresModel
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
        public DateTime? DataNascimento { get; set; }
    }
}
