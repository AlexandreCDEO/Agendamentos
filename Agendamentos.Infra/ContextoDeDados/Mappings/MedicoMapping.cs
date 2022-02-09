using Agendamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamentos.Infra.ContextoDeDados.Mappings;

public class MedicoMapping : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("Medico");
        builder.HasKey(x => x.Codigo);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Telefone)
            .IsRequired()
            .HasColumnName("Telefone")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.Crm)
            .IsRequired()
            .HasColumnName("Crm")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10);

        builder.HasIndex(x => x.Crm, "IX_Medico_Crm")
            .IsUnique();

    }
}