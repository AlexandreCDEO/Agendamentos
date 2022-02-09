using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Queries;
using Agendamentos.Domain.Repositorios;
using Agendamentos.Infra.ContextoDeDados;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Infra.Repositorios;

public class RepositorioAgendamento : IRepositorioAgendamento
{
    private readonly ContextoDeAgendamentos _contexto;

    public RepositorioAgendamento(ContextoDeAgendamentos contexto)
    {
        _contexto = contexto;
    }
    public void Criar(Agendamento agendamento)
    {
        _contexto.Agendamentos.Add(agendamento);
        _contexto.SaveChanges();
    }

    public void Alterar(Agendamento agendamento)
    {
        _contexto.Agendamentos.Update(agendamento);
        _contexto.SaveChanges();
    }

    public Agendamento BuscarPorCodigo(Guid codigo)
    {
        return _contexto.Agendamentos.AsNoTracking().FirstOrDefault(x => x.Codigo == codigo);
    }

    public IEnumerable<Agendamento> BuscarTodasConsultasPorPaciente(string pacienteCpf)
    {
        return _contexto.Agendamentos.
            AsNoTracking()
            .Where(AgendamentoQueries.BuscaTodasConsultasPorPaciente(pacienteCpf));
    }

    public IEnumerable<Agendamento> BuscaTodasConsultasPorMedico(string medicoCrm)
    {
        return _contexto.Agendamentos.AsNoTracking().Where(AgendamentoQueries.BuscaTodasConsultasPorMedico(medicoCrm));
    }

    public IEnumerable<Agendamento> BuscaTodasConsultasDoDia()
    {
        return _contexto.Agendamentos.AsNoTracking().Where(AgendamentoQueries.BuscaTodasConsultasDoDia());
    }

    public IEnumerable<Agendamento> BuscaTodasConsultasDoDiaDeUmMedico(string medicoCrm)
    {
        return _contexto.Agendamentos.AsNoTracking()
            .Where(AgendamentoQueries.BuscaTodasConsultasDoDiaDeUmMedico(medicoCrm));
    }
}