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
            return await _context.Doctors
                .Include(p => p.Patients)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> GetDoctorByName(string name)
        {
            return await _context.Doctors.FindAsync(name);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetPatientsByDoctor(string name)
        {
            return await _context.Doctors
                .Include(p => p.Patients)
                .Where(d => d.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorByCrm(string crm)
        {
            var doctorEntity = await _context.Doctors.Where(d => d.CRMUF == crm).ToListAsync();
            return doctorEntity;
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
