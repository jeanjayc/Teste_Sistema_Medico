using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Domain.Entities;
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
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task CretaPatientAsync(PatientVM patientVM)
        {
            var patientEntity = _mapper.Map<Patient>(patientVM);

            if (patientVM.CPF == patientEntity.CPF && patientVM.Id != patientEntity.Id)
            {
                throw new ArgumentException("Já existe um paciente cadastrado com este CPF");
            }
            await _patientRepository.CretaPatientAsync(patientEntity);
        }

        public Task<PatientVM> GetPatientByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientVM>> GetPatientsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<PatientVM> UpdatePatientAsync(PatientVM patientVM)
        {
            throw new NotImplementedException();
        }

        public Task<PatientVM> RemovePatientAsync(PatientVM patientVM)
        {
            throw new NotImplementedException();
        }
        
    }
}
