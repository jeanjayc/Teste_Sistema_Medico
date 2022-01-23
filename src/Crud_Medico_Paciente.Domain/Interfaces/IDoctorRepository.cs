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
        Task<Doctor> GetDoctorByName(string name);
        Task<Doctor> CretaDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetDoctorByCrm(string crm);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetPatientsByDoctor(string name);
        Task<Doctor> RemoveDoctorAsync(Doctor doctor);
    }
}
