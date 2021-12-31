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
        Task CretaPatientAsync(PatientVM patientVM);
        Task<PatientVM> UpdatePatientAsync(PatientVM patientVM);
        Task<PatientVM> RemovePatientAsync(PatientVM patientVM);
    }
}
