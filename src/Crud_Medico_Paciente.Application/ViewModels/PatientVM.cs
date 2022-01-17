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
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

        [ScaffoldColumn(false)]
        public string NameDoctor { get; set; }
        public Guid DoctorId { get; set; }
    }
}
