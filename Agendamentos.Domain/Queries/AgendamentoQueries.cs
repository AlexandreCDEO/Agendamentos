using System.Linq.Expressions;
using Agendamentos.Domain.Entities;

namespace Agendamentos.Domain.Queries;

public static class AgendamentoQueries
{
    public static Expression<Func<Agendamento, bool>> BuscaTodasConsultasPorPaciente(string pacienteCpf)
    {
        return x => x.Paciente.Cpf == pacienteCpf;
    }
    
    public static Expression<Func<Agendamento, bool>> BuscaTodasConsultasPorMedico(string medicoCrm)
    {
        return x => x.Medico.Crm == medicoCrm;
    }

    public static Expression<Func<Agendamento, bool>> BuscaTodasConsultasDoDia()
    {
        return x => x.InicioAtendimento.Date == DateTime.Now.Date;
    }

    public static Expression<Func<Agendamento, bool>> BuscaTodasConsultasDoDiaDeUmMedico(string medicoCrm)
    {
        return x => x.Medico.Crm == medicoCrm && x.InicioAtendimento.Date == DateTime.Now.Date;
    }
}