using Crud_Medico_Paciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(Guid id);
        Task<Doctor> CretaDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task<Doctor> GetPatientsByDoctor(Guid id);
        Task<Doctor> RemoveDoctorAsync(Doctor doctor);
    }
}
