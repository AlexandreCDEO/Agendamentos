using System;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Repositorios;

namespace Agendamentos.Tests.RepositoriosParaTeste;

public class FakeRepositorioPaciente : IRepositorioPaciente
{
    public void Criar(Paciente paciente)
    {
    }

    public void Alterar(Paciente paciente)
    {
    }

    public Paciente BuscarPorCodigo(Guid codigo)
    {
        return new Paciente("Nome do Paciente","15111111111", "11111111111", DateTime.Now);
    }
}