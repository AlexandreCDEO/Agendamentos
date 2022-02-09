using Agendamentos.Domain.Entities;

namespace Agendamentos.Domain.Repositorios;

public interface IRepositorioAgendamento
{
    public void Criar(Agendamento agendamento);
    public void Alterar(Agendamento agendamento);
    public Agendamento BuscarPorCodigo(Guid codigo);
    public IEnumerable<Agendamento> BuscarTodasConsultasPorPaciente(string pacienteCpf);
    public IEnumerable<Agendamento> BuscaTodasConsultasPorMedico(string medicoCrm);
    public IEnumerable<Agendamento> BuscaTodasConsultasDoDia();
    public IEnumerable<Agendamento> BuscaTodasConsultasDoDiaDeUmMedico(string medicoCrm);
}