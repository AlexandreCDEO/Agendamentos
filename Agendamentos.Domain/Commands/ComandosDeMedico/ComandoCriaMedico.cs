using Agendamentos.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Agendamentos.Domain.Commands.ComandosDeMedico;

public class ComandoCriaMedico :Notifiable, ICommand
{
    public ComandoCriaMedico()
    {
        
    }
    
    public ComandoCriaMedico(string nome, string crm, string telefone)
    {
        Nome = nome;
        Crm = crm;
        Telefone = telefone;
    }
    
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
        );
    }
}
