using Agendamentos.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Agendamentos.Domain.Commands.Medico;

public class ComandoAlteraMedico : Notifiable, ICommand
{
    public ComandoAlteraMedico()
    {
        
    }
    
    public ComandoAlteraMedico(Guid codigo, string nome, string crm, string telefone)
    {
        Codigo = codigo;
        Nome = nome;
        Crm = crm;
        Telefone = telefone;
    }

    public Guid Codigo { get; set; }
    public string Nome { get; set; }
    public string Crm { get; set; }
    public string Telefone { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(Nome, "Nome", "Nome inválido")
            .IsNotNullOrEmpty(Telefone, "Telefone", "Telefone inválido")
            .HasExactLengthIfNotNullOrEmpty(Crm, 6,"Crm", "Crm inválido")
            .HasLen(Codigo.ToString(), 36, "Codigo", "Codigo identificador do médico inválido")
        );
    }
}