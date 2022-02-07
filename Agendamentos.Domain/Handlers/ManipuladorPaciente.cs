using Agendamentos.Domain.Commands;
using Agendamentos.Domain.Commands.Contracts;
using Agendamentos.Domain.Commands.Medico;
using Agendamentos.Domain.Commands.Paciente;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Handlers.Contracts;
using Agendamentos.Domain.Repositorios;
using Flunt.Notifications;

namespace Agendamentos.Domain.Handlers;

public class ManipuladorPaciente : Notifiable,
    IHandler<ComandoCriaPaciente>,
    IHandler<ComandoAlteraPaciente>
{
    private readonly IRepositorioPaciente _repositorio;

    public ManipuladorPaciente(IRepositorioPaciente repositorio)
    {
        _repositorio = repositorio;
    }
    public ICommandResult Handle(ComandoCriaPaciente command)
    {
        //Fast Fail Validate
        command.Validate();
        if (command.Invalid)
            return new ComandoResultadoGenerico(false, "Ops, Dados do paciente inválido", command.Notifications);
        
        //Cria o Paciente
        var paciente = new Paciente(command.Nome, command.Telefone, command.Cpf,command.DataNascimento);
        
        //Salva no banco
        _repositorio.Criar(paciente);
        
        //retorna o resultado
        return new ComandoResultadoGenerico(true, "Paciente cadastrado com sucesso", paciente);

    }


    public ICommandResult Handle(ComandoAlteraPaciente command)
    {
        //Fast Fail Validate
        command.Validate();
        if (command.Invalid)
            return new ComandoResultadoGenerico(false, "Ops, dados do paciente inválidos", command.Notifications);
        
        //busca paciente do banco
        var paciente = _repositorio.BuscarPorCodigo(command.Codigo);
        
        //Altera propriedades
        paciente.AlteraTelefone(command.Telefone);
        
        //salva no banco
        _repositorio.Alterar(paciente);
        
        //retorna o resultado
        return new ComandoResultadoGenerico(true, $"Dados do paciente {paciente.Nome} alterados com sucesso", paciente);
    }
}