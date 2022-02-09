using Agendamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamentos.Infra.ContextoDeDados.Mappings;

public class PacienteMapping : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Paciente");
        builder.HasKey(x => x.Codigo);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasColumnName("Cpf")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Telefone)
            .IsRequired()
            .HasColumnName("Telefone")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.DataNascimento)
            .IsRequired()
            .HasColumnName("DataNascimento")
            .HasColumnType("SMALLDATETIME");

        builder.HasIndex(x => x.Cpf, "IX_Paciente_Cpf")
            .IsUnique();
    }
}