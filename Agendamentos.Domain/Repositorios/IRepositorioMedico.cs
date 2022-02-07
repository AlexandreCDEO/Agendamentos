using Agendamentos.Domain.Entities;

namespace Agendamentos.Domain.Repositorios;

public interface IRepositorioMedico
{
    public void Criar(Medico medico);
    public void Alterar(Medico medico);
    public Medico BuscarPorCodigo(Guid codigo);
}