using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Application.Utils;
using Crud_Medico_Paciente.Domain.Entities;
using Crud_Medico_Paciente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly NotificationContext _notificationContext;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper, NotificationContext notificationContext)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }
        public async Task<Doctor> CretaDoctorAsync(DoctorVM doctorVM)
        {
            var doctorEntity = _mapper.Map<Doctor>(doctorVM);

            //aqui é feito a verificação se já existe um doctor com o crm cadastrado
            if (_doctorRepository.GetDoctorByCrm(doctorVM.CRMUF).Result.Any())
            {
                _notificationContext.AddNotification("Doctor", "Já existe um Medico cadastrado com o CRM informado");
            }

            if (_notificationContext.HasNotification)
            {
                return default;
            }

            await _doctorRepository.CretaDoctorAsync(doctorEntity);
            return doctorEntity;
        }

        public async Task<IEnumerable<DoctorVM>> GetDoctorsVM()
        {
            var doctorsEntity = await _doctorRepository.GetDoctorsAsync();
            return _mapper.Map<IEnumerable<DoctorVM>>(doctorsEntity);
        }

        public async Task<DoctorVM> GetDoctorVMById(Guid id)
        {
            var doctorEntity = await _doctorRepository.GetDoctorByIdAsync(id);
            return _mapper.Map<DoctorVM>(doctorEntity);
        }

        public async Task<Doctor> GetPatientsByDoctor(Guid id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }

        public async Task<Doctor> UpdateDoctorAsync(DoctorVM doctor)
        {
            var doctorEntity = _mapper.Map<Doctor>(doctor);

            return await _doctorRepository.UpdateDoctorAsync(doctorEntity);

        }

        public async Task RemoveDoctorAsync(DoctorVM doctor)
        {
            var doctorEntity = await _doctorRepository.GetPatientsByDoctor(doctor.Id);

            if (doctorEntity.Patients.Any())
            {
                _notificationContext.AddNotification("Doctor", "Esse médico não pode ser excluido, pois tem pacientes vinculados a ele");
            }

            await _doctorRepository.RemoveDoctorAsync(doctorEntity);
        }
    }
}
