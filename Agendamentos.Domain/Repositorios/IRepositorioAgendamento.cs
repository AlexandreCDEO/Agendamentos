using Agendamentos.Domain.Entities;

namespace Agendamentos.Domain.Repositorios;

public interface IRepositorioAgendamento
{
    public void Criar(Agendamento agendamento);
    public void Alterar(Agendamento agendamento);
    public Agendamento BuscarPorCodigo(Guid codigo);
}