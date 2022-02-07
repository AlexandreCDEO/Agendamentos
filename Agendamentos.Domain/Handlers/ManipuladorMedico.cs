using Agendamentos.Domain.Commands;
using Agendamentos.Domain.Commands.Contracts;
using Agendamentos.Domain.Commands.Medico;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Handlers.Contracts;
using Agendamentos.Domain.Repositorios;
using Flunt.Notifications;

namespace Agendamentos.Domain.Handlers;

public class ManipuladorMedico : Notifiable,
    IHandler<ComandoCriaMedico>,
    IHandler<ComandoAlteraMedico>
{
    private readonly IRepositorioMedico _repositorio;

    public ManipuladorMedico(IRepositorioMedico repositorio)
    {
        _repositorio = repositorio;
    }
    
    public ICommandResult Handle(ComandoCriaMedico command)
    {
        //Fast Fail Validate
        command.Validate();
        if (command.Invalid)
            return new ComandoResultadoGenerico(
                false, 
                "Ops, parece que alguns dos dados passados estão inválidos",
                command.Notifications
            );
        
        //Gerar o Medico
        var medico = new Medico(command.Nome, command.Crm,command.Telefone);
        
        //Salva no banco
        _repositorio.Criar(medico);
        
        //Retorna o resultado
        return new ComandoResultadoGenerico(true, "Medico cadastrado com sucesso", medico);
        
    }

    public ICommandResult Handle(ComandoAlteraMedico command)
    {
        //Fast Fail Validate
        command.Validate();
        if (command.Invalid)
            return new ComandoResultadoGenerico(
                false,
                "Ops, parece que alguns dos dados passados estão inválidos",
                command.Notifications
            );
        
        //busca medico do banco
        var medico = _repositorio.BuscarPorCodigo(command.Codigo);
        
        //Atualiza o medico
        medico.AlteraTelefone(command.Telefone);
        
        //Salva no banco
        _repositorio.Alterar(medico);
        
        //Retorna o resultado
        return new ComandoResultadoGenerico(true, "Propriedades do medico alterada com sucesso", medico);
    }
}