﻿using Crud_Medico_Paciente.Api.ViewModels;
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
        Task<IEnumerable<DoctorVM>> GetDoctorsVM();
        Task<DoctorVM> GetDoctorVMById(Guid id);
        Task<Doctor> CretaDoctorAsync(DoctorVM doctorVM);
        Task<DoctorVM> UpdateDoctorAsync(DoctorVM doctorVM);
        Task<DoctorVM> GetPatientsByDoctor(Guid id);
        Task<DoctorVM> RemoveDoctorAsync(DoctorVM doctorVM);
    }
}