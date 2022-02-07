using Agendamentos.Domain.Commands;
using Agendamentos.Domain.Commands.ComandosdeAgendamento;
using Agendamentos.Domain.Commands.Contracts;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Handlers.Contracts;
using Agendamentos.Domain.Repositorios;
using Flunt.Notifications;

namespace Agendamentos.Domain.Handlers;

public class ManipuladorAgendamento : Notifiable,
    IHandler<ComandoCriaAgendamento>
{
    private readonly IRepositorioAgendamento _repositorioAgendamento;
    private readonly IRepositorioMedico _repositorioMedico;
    private readonly IRepositorioPaciente _repositorioPaciente;

    public ManipuladorAgendamento(
        IRepositorioAgendamento repositorioAgendamento,
        IRepositorioMedico repositorioMedico,
        IRepositorioPaciente repositorioPaciente
    )
    {
        _repositorioAgendamento = repositorioAgendamento;
        _repositorioMedico = repositorioMedico;
        _repositorioPaciente = repositorioPaciente;
    }
    public ICommandResult Handle(ComandoCriaAgendamento command)
    {
        //Fast Fail Validate
        command.Validate();
        if (command.Invalid)
            return new ComandoResultadoGenerico(false, "Ops, os dados para agendamento estão inválidos",
                command.Notifications);
        
        //recuperar medico do banco
        var medico = _repositorioMedico.BuscarPorCodigo(command.CodigoMedico);
        
        //recuperar paciente do banco
        var paciente = _repositorioPaciente.BuscarPorCodigo(command.CodigoPaciente);
        
        //verifica se o paciente tem horario livre para o agendamento
        if(paciente.AgendaLivre(command.InicioAtendimento) == false)
            AddNotification("Paciente.AgendaLivre", "Horario de agendamento indisponivel para o paciente");
        
        //verifica se o medico tem horario livre para o agendamento
        if(medico.AgendaLivre(command.InicioAtendimento) == false)
            AddNotification("medico.AgendaLivre", "Horario de agendamento indisponivel para o medico");
        
        //Cria o agendamento
        var agendamento = new Agendamento(command.InicioAtendimento, command.FimAtendimento, paciente, medico);
        
        //Verificar se o agendamento esta entre 8 e 18 horqs
        if(agendamento.HorarioValido() == false)
            AddNotification("agendamnto.HorarioValido", "O agendamento tem que estar entre 8 e 18 horas");
        
        //Verifica se o agendamento é em dia de semana
        if(agendamento.DiaDaSemanaValido() == false)
            AddNotification("agendamento.DiaDaSemanaValido", "O agendamento não pode ser no sabado e nem no domingo");
        
        //Verica se o tempo de consulta e exatamente 30 minutos;
        if(agendamento.TempoDeConsulta() == false)
            AddNotification("agendamento.TempoDeConsulta", "O agendamento deve ter exatamente 30 minutos");
        
        //verifica se o agendamento esta sendo feito com 24 horas de antecedencia
        if(agendamento.Antecedencia() == false)
            AddNotification("agendamento.antecedencia", "O agendamento deve ser feito com no minimo 24 horas de antecedencia");
        
        //relacionamentos
        medico.AdicionaAgendamento(agendamento);
        paciente.AdicionaAgendamento(agendamento);
        
        //Agrupa as Notificacoes
        AddNotifications(agendamento, medico, paciente);
        
        //Valida
        if (Invalid)
            return new ComandoResultadoGenerico(false, "Não foi possivel fazer o agendamento", Notifications);
        
        //Salva no banco
        _repositorioAgendamento.Criar(agendamento);
        _repositorioMedico.Alterar(medico);
        _repositorioPaciente.Alterar(paciente);
        
        //retorna o resultado
        return new ComandoResultadoGenerico(true, "Agendamento feito com sucesso", agendamento);




    }
}