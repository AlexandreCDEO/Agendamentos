using Agendamentos.Domain.Entities;

namespace Agendamentos.Domain.Repositorios;

public interface IRepositorioPaciente
{
    public void Criar(Paciente paciente);
    public void Alterar(Paciente paciente);
    public Paciente BuscarPorCodigo(Guid codigo);
}