using Agendamentos.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Agendamentos.Domain.Commands.ComandosdeAgendamento;

public class ComandoCriaAgendamento : Notifiable, ICommand
{
    public ComandoCriaAgendamento()
    {
        
    }
    public ComandoCriaAgendamento(Guid codigoPaciente, Guid codigoMedico, DateTime inicioAtendimento, DateTime fimAtendimento)
    {
        CodigoPaciente = codigoPaciente;
        CodigoMedico = codigoMedico;
        InicioAtendimento = inicioAtendimento;
        FimAtendimento = fimAtendimento;
    }

    public Guid CodigoPaciente { get; set; }
    public Guid CodigoMedico { get; set; }
    public DateTime InicioAtendimento { get; set; }
    public DateTime FimAtendimento { get;  set; }
    
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotEmpty(CodigoPaciente, "CodigoPaciente", "Codigo do paciente inválido")
            .IsNotEmpty(CodigoMedico, "CodigoMedico","Codigo do Medico inválido")
            .IsNotNull(InicioAtendimento, "InicioAtendimento", "Horario de inicio do atendimento inválido")
            .IsNotNull(FimAtendimento, "FimAtendimento", "Horario do final do atendimento inválido")
        
        );
    }
}