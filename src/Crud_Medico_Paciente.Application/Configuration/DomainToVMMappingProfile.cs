using AutoMapper;
using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Domain.Entities;

namespace Crud_Medico_Paciente.Application.Configuration
{
    public class DomainToVMMappingProfile : Profile
    {
        public DomainToVMMappingProfile()
        {
            CreateMap<Doctor, DoctorVM>().ReverseMap();
            CreateMap<Patient, PatientVM>().ReverseMap();
        }
    }
}
