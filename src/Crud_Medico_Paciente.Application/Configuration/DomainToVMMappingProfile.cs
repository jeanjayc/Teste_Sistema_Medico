using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.ViewModels;
using Crud_Medico_Paciente.Domain.Entities;

namespace Crud_Medico_Paciente.Application.Configuration
{
    public class DomainToVMMappingProfile : Profile
    {
        public DomainToVMMappingProfile()
        {
            CreateMap<Doctor, DoctorOutputModel>().ReverseMap();
            CreateMap<Doctor, DoctorInputModel>().ReverseMap();
            CreateMap<Patient, PatientInputModel>().ReverseMap();
            CreateMap<Patient, PatientOutputModel>().ReverseMap();
        }
    }
}
