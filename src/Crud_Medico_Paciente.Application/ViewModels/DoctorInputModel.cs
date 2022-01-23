using System;
using System.ComponentModel.DataAnnotations;

namespace Crud_Medico_Paciente.Application.ViewModels
{
    public class DoctorInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }
        [MinLength(6)]
        [MaxLength(6)]
        public string CRM { get; set; }
        [MinLength(9)]
        [MaxLength(9)]
        public string CRMUF { get; set; }
    }
}
