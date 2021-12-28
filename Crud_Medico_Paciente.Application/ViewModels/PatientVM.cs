using System;
using System.ComponentModel.DataAnnotations;

namespace Crud_Medico_Paciente.Api.ViewModels
{
    public class PatientVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo BirtDate é obrigatório")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "O campo BirtDate é obrigatório")]
        [MaxLength(14)]
        public string CPF { get; set; }
        public string NameDoctor { get; set; }
    }
}
