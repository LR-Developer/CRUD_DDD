using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_DDD.MVC.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [MaxLength(100,ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(3,ErrorMessage = "Mínimo {0} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de Nascimento.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Nascimento")]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "Selecione uma opção.")]
        [DisplayName("Gênero")]
        public string Gender { get; set; }
    }
}