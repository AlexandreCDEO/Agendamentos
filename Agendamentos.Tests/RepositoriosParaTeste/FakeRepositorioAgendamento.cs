using System;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Repositorios;

namespace Agendamentos.Tests.RepositoriosParaTeste;

public class FakeRepositorioAgendamento : IRepositorioAgendamento
{
    public void Criar(Agendamento agendamento)
    {
        
    }

    public void Alterar(Agendamento agendamento)
    {
        
    }

    public Agendamento BuscarPorCodigo(Guid codigo)
    {
        return new Agendamento(
            DateTime.Now,
            DateTime.Now,
            new Paciente("Nome do Paciente", "15997314012", "12345678911", DateTime.Now),
            new Medico("Nome do Medico", "123456", "15997314012")
        );
    }
}