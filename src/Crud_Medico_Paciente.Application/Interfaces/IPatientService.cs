using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.ViewModels;
using Crud_Medico_Paciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientOutputModel>> GetPatientsAsync();
        Task<PatientOutputModel> GetPatientByIdAsync(Guid id);
        Task<PatientOutputModel> GetPatientByCpf(string cpf);
        Task<Patient> CretaPatientAsync(PatientInputModel patientVM);
        Task UpdatePatientAsync(PatientInputModel patientVM);
        Task<PatientOutputModel> RemovePatientAsync(Guid id);

    }
}
