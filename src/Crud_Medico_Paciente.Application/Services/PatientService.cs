using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Application.Utils;
using Crud_Medico_Paciente.Application.ViewModels;
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

        public async Task<Patient> CretaPatientAsync(PatientInputModel patientVM)
        {
            try
            {
                var patientEntity = _mapper.Map<Patient>(patientVM);

                if (_patientRepository.GetPatientByCpfAsync(patientEntity.CPF).Result.Any())
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

        public async Task<PatientOutputModel> GetPatientByIdAsync(Guid id)
        {
            var patientEntity = await _patientRepository.GetPatientByIdAsync(id);
            return _mapper.Map<PatientOutputModel>(patientEntity);
        }

        public async Task<IEnumerable<PatientOutputModel>> GetPatientsAsync()
        {
            var patientEntity =  await _patientRepository.GetPatientsAsync();
            return _mapper.Map<IEnumerable<PatientOutputModel>>(patientEntity);
        }

        public async Task<PatientOutputModel> GetPatientByCpf(string cpf)
        {
            var patientEntity = await _patientRepository.GetPatientByCpfAsync(cpf);
            var result = _mapper.Map<PatientOutputModel>(patientEntity);
            return result;
        }
        public async Task UpdatePatientAsync(PatientInputModel patientVM)
        {
            var patientEntity = _mapper.Map<Patient>(patientVM);
            await _patientRepository.UpdatePatientAsync(patientEntity);
        }

        public async Task<PatientOutputModel> RemovePatientAsync(Guid id)
        {
            var patientEntity = await _patientRepository.GetPatientByIdAsync(id);

            await _patientRepository.RemovePatientAsync(patientEntity);

            return _mapper.Map<PatientOutputModel>(patientEntity);

        }
    }
}
