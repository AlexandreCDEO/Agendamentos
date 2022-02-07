using Agendamentos.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Agendamentos.Domain.Commands.ComandosDePaciente;

public class ComandoAlteraPaciente: Notifiable, ICommand
{
    public ComandoAlteraPaciente()
    {
        
    }
    public ComandoAlteraPaciente(Guid codigo, string telefone)
    {
        Codigo = codigo;
        Telefone = telefone;
    }

    public Guid Codigo { get; set; }
    public string Telefone { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasLen(Codigo.ToString(), 36, "Codigo", "Codigo identificador do Paciente inválido")
            .IsNotNullOrEmpty(Telefone, "Telefone", "Telefone inválido")
        
        );
    }
}