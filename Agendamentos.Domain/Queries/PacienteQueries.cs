using System.Linq.Expressions;
using Agendamentos.Domain.Entities;

namespace Agendamentos.Domain.Queries;

public static class PacienteQueries
{
    public static Expression<Func<Paciente, bool>> BuscaTodos()
    {
        return x=>x.
    }
}