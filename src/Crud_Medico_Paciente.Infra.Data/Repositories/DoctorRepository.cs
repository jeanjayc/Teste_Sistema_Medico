using Crud_Medico_Paciente.Domain.Entities;
using Crud_Medico_Paciente.Domain.Interfaces;
using Crud_Medico_Paciente.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Infra.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Doctor> CretaDoctorAsync(Doctor doctor)
        {
            _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            return await _context.Doctors.FindAsync(id);
            
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetPatientsByDoctor(Guid id)
        {
            return await _context.Doctors
                .Include(p => p.Patients)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> RemoveDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
    }
}
