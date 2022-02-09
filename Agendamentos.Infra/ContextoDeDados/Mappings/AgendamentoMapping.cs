using Agendamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamentos.Infra.ContextoDeDados.Mappings;

public class AgendamentoMapping : IEntityTypeConfiguration<Agendamento>
{
    public void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        builder.ToTable("Agendamento");
        builder.HasKey(x => x.Codigo);
        
        builder.Property(x => x.InicioAtendimento)
            .IsRequired()
            .HasColumnName("InicioAtendimento")
            .HasColumnType("SMALLDATETIME");

        builder.Property(x => x.FimAtendimento)
            .IsRequired()
            .HasColumnName("FimAtendimento")
            .HasColumnType("SMALLDATETIME");

        builder.Property(x => x.DataCadastro)
            .IsRequired()
            .HasColumnName("DataCadastro")
            .HasColumnType("SMALLDATETIME");

        builder.HasOne(x => x.Medico)
            .WithMany(x => x.Agendamentos)
            .HasConstraintName("FK_Agendamento_Medico")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Paciente)
            .WithMany(x => x.Agendamentos)
            .HasConstraintName("FK_Agendamento_Paciente")
            .OnDelete(DeleteBehavior.Cascade);


    }
}