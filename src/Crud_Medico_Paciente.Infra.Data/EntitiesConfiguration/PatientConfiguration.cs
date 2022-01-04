using Crud_Medico_Paciente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud_Medico_Paciente.Infra.Data.EntitiesConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.BirthDate).HasColumnType("date").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("CHAR(14)").IsRequired();

            builder.ToTable("Patients");
        }
    }
}
