using Crud_Medico_Paciente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud_Medico_Paciente.Infra.Data.EntitiesConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.CRMUF).HasColumnType("CHAR(9)").IsRequired();
            builder.Property(p => p.CRM).HasColumnType("CHAR(6)").IsRequired();

            // 1 : N => Doctor : Patients
            builder.HasMany(d => d.Patients)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId);

            builder.ToTable("Doctor");
        }
    }
}
