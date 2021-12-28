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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task CretaDoctorAsync(DoctorVM doctorVM)
        {
            var doctorEntity = _mapper.Map<Doctor>(doctorVM);

            if(doctorVM.CRMUF == doctorEntity.CRMUF && doctorVM.Id != doctorEntity.Id)
            {
                throw new ArgumentException("Já existe um Medico cadastrado com o CRM informado");
            }
            await _doctorRepository.CretaDoctorAsync(doctorEntity);
        }

        public Task<IEnumerable<DoctorVM>> GetDoctorsVM()
        {
            throw new NotImplementedException();
        }

        public Task<DoctorVM> GetDoctorVMById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorVM> GetPatientsByDoctor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorVM> UpdateDoctorAsync(DoctorVM doctor)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorVM> RemoveDoctorAsync(DoctorVM doctor)
        {
            throw new NotImplementedException();
        }
    }
}
