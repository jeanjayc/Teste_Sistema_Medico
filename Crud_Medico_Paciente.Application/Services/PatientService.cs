using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<PatientVM> CretaPatientAsync(PatientVM patient)
        {
            throw new NotImplementedException();
        }

        public Task<PatientVM> GetPatientByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientVM>> GetPatientsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<PatientVM> UpdatePatientAsync(PatientVM patient)
        {
            throw new NotImplementedException();
        }

        public Task<PatientVM> RemovePatientAsync(PatientVM patient)
        {
            throw new NotImplementedException();
        }
        
    }
}
