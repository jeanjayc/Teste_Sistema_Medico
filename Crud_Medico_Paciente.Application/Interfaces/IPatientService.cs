using Crud_Medico_Paciente.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientVM>> GetPatientsAsync();
        Task<PatientVM> GetPatientByIdAsync(Guid id);
        Task<PatientVM> CretaPatientAsync(PatientVM patient);
        Task<PatientVM> UpdatePatientAsync(PatientVM patient);
        Task<PatientVM> RemovePatientAsync(PatientVM patient);
    }
}
