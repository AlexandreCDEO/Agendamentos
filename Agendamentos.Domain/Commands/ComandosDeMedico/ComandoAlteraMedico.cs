using Agendamentos.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Agendamentos.Domain.Commands.ComandosDeMedico;

public class ComandoAlteraMedico : Notifiable, ICommand
{
    public ComandoAlteraMedico()
    {
        
    }
    
    public ComandoAlteraMedico(Guid codigo, string telefone)
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
            .IsNotNullOrEmpty(Telefone, "Telefone", "Telefone inválido")
            .HasLen(Codigo.ToString(), 36, "Codigo", "Codigo identificador do médico inválido")
        );
    }
}