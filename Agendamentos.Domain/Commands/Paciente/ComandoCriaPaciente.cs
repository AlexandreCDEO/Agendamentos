using Agendamentos.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Agendamentos.Domain.Commands.Paciente;

public class ComandoCriaPaciente : Notifiable, ICommand
{
    public ComandoCriaPaciente()
    {
        
    }
    
    public ComandoCriaPaciente(string nome, string telefone, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        DataNascimento = dataNascimento;
    }
    
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(Nome, "Nome", "Nome Inválido")
            .IsNotNullOrEmpty(Telefone, "Telefone", "Telefone Inválido")
            .IsNotNullOrEmpty(Cpf, "Cpf", "Cpf Inválido")
            .HasLen(Cpf,11, "Cpf", "Cpf inválido")
            .IsNotNull(DataNascimento, "Data de Nascimento", "Data de nascimeneto inválida")
        );
    }
}