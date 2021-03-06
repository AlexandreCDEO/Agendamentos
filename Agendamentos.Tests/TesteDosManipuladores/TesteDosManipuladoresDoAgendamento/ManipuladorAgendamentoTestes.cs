using System;
using Agendamentos.Domain.Commands;
using Agendamentos.Domain.Commands.ComandosdeAgendamento;
using Agendamentos.Domain.Handlers;
using Agendamentos.Tests.RepositoriosParaTeste;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDosManipuladores.TesteDosManipuladoresDoAgendamento;

[TestClass]
public class ManipuladorAgendamentoTestes
{
    [TestMethod]
    public void Dado_um_comando_invalido_nao_deve_criar_um_agendamento()
    {
        var comando = new ComandoCriaAgendamento();
        comando.InicioAtendimento = DateTime.Now;

        var handler = new ManipuladorAgendamento(
            new FakeRepositorioAgendamento(),
            new FakeRepositorioMedico(),
            new FakeRepositorioPaciente()
        );

        var resultado = (ComandoResultadoGenerico) handler.Handle(comando);
        Assert.AreEqual(resultado.Success, false);
    }
    
    /*Todo dia tem que acertar o Horario, senao da erro no teste , pois o agendanmento nao fica com 24 horas de antecedencia
    e tem que colocar um agendamento que nao seja sabado nem domingo.*/
    
    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_um_agendamento()
    {
        var comando = new ComandoCriaAgendamento();
        comando.InicioAtendimento = new DateTime(2022, 02, 10, 09, 00, 00);
        comando.FimAtendimento = new DateTime(2022, 02, 10, 09, 30, 00);
        comando.CodigoMedico = Guid.NewGuid();
        comando.CodigoPaciente = Guid.NewGuid();

        var handler = new ManipuladorAgendamento(
            new FakeRepositorioAgendamento(),
            new FakeRepositorioMedico(),
            new FakeRepositorioPaciente()
        );

        var resultado = (ComandoResultadoGenerico) handler.Handle(comando);
        Assert.AreEqual(resultado.Success, true);
    }
}