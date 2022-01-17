using Crud_Medico_Paciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task<Patient> GetPatientByCpfAsync(string cpf);
        Task<Patient> CretaPatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<Patient> RemovePatientAsync(Patient patient);
    }
}
