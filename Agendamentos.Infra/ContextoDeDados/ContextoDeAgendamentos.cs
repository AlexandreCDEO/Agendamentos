using Agendamentos.Domain.Entities;
using Agendamentos.Infra.ContextoDeDados.Mappings;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Infra.ContextoDeDados;

public class ContextoDeAgendamentos : DbContext
{
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=Agendamento;User ID=sa;Password=Password.1");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AgendamentoMapping());
        modelBuilder.ApplyConfiguration(new MedicoMapping());
        modelBuilder.ApplyConfiguration(new PacienteMapping());
        modelBuilder.Ignore<Notification>();

    }
}