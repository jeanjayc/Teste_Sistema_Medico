using Crud_Medico_Paciente.Api.ViewModels;
using Crud_Medico_Paciente.Application.ViewModels;
using Crud_Medico_Paciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorInputModel>> GetDoctorsVM();
        Task<DoctorOutputModel> GetDoctorVMById(Guid id);
        Task<Doctor> CretaDoctorAsync(DoctorInputModel doctorVM);
        Task<Doctor> UpdateDoctorAsync(DoctorInputModel doctorVM);
        Task<IEnumerable<DoctorOutputModel>> GetPatientsByDoctor(string nameDoctor);
        Task RemoveDoctorAsync(Guid id);
    }
}
