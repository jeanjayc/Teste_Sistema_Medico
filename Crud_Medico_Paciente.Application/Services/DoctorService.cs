using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Application.Notificacoes;
using Crud_Medico_Paciente.Domain.Entities;
using Crud_Medico_Paciente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Services
{
    public class DoctorService : BaseService, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper, INotificador notificador): base(notificador)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<bool> CretaDoctorAsync(DoctorVM doctorVM)
        {
            var doctorEntity = _mapper.Map<Doctor>(doctorVM);

            if(doctorVM.CRMUF == doctorEntity.CRMUF)
            {
                Notificar("Já existe um Medico cadastrado com o CRM informado");
                return false;
            }
            await _doctorRepository.CretaDoctorAsync(doctorEntity);
            return true;    
        }

        public async Task<IEnumerable<DoctorVM>> GetDoctorsVM()
        {
            var doctorsEntity = await _doctorRepository.GetDoctorsAsync();
            return _mapper.Map<IEnumerable<DoctorVM>>(doctorsEntity);
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
