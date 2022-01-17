using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Application.Utils;
using Crud_Medico_Paciente.Domain.Entities;
using Crud_Medico_Paciente.Domain.Interfaces;
using Microsoft.Extensions.Logging;
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
        private readonly NotificationContext _notificationContext;
        private readonly ILogger<PatientService> _logger;
        public PatientService(IPatientRepository patientRepository, 
            IMapper mapper, 
            NotificationContext notificationContext, 
            ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _notificationContext = notificationContext;
            _logger = logger;
        }

        public async Task<Patient> CretaPatientAsync(PatientVM patientVM)
        {
            try
            {
                var patientEntity = _mapper.Map<Patient>(patientVM);

                if (_patientRepository.GetPatientByCpfAsync(patientEntity.CPF).Result.CPF.Any())
                {
                    _notificationContext.AddNotification("Patient", "Já existe um paciente cadastrado com este CPF");
                }

                if (_notificationContext.HasNotification) return default;
                await _patientRepository.CretaPatientAsync(patientEntity);

                return patientEntity;

            }
            catch (Exception e)
            {
                _logger.LogError(e, " Houve erro ao cadastrar o paciente");
                return default;
            }
        }

        public Task<PatientVM> GetPatientByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientVM>> GetPatientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PatientVM> GetPatientByCpf(string cpf)
        {
            var patientEntity = await _patientRepository.GetPatientByCpfAsync(cpf);
            var result = _mapper.Map<PatientVM>(patientEntity);
            return result;
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
