using System;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Repositorios;

namespace Agendamentos.Tests.RepositoriosParaTeste;

public class FakeRepositorioMedico : IRepositorioMedico
{
    public void Criar(Medico medico)
    {
    }

    public void Alterar(Medico medico)
    {
    }

    public Medico BuscarPorCodigo(Guid codigo)
    {
        var medico = new Medico("nome aqui", "123456", "15111111111");
        return medico;
    }
}