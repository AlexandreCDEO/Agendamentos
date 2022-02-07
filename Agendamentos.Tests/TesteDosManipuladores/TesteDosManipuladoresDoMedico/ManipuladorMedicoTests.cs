using System;
using Agendamentos.Domain.Commands;
using Agendamentos.Domain.Commands.ComandosDeMedico;
using Agendamentos.Domain.Handlers;
using Agendamentos.Tests.RepositoriosParaTeste;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDosManipuladores.TesteDosManipuladoresDoMedico;

[TestClass]
public class ManipuladorMedicoTests
{
    [TestMethod]
    public void Dado_um_comando_valido_o_medico_deve_ser_criado()
    {
        var command = new ComandoCriaMedico("Nome do medico", "123456", "15111111111");
        var handler = new ManipuladorMedico(new FakeRepositorioMedico());
        var result = (ComandoResultadoGenerico)handler.Handle(command);
        Assert.AreEqual(result.Success, true);
    }
    
    [TestMethod]
    public void Dado_um_comando_invalido_o_medico_nao_deve_ser_criado()
    {
        var command = new ComandoCriaMedico("Nome do medico", "123", "15111111111");
        var handler = new ManipuladorMedico(new FakeRepositorioMedico());
        var result = (ComandoResultadoGenerico)handler.Handle(command);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void O_ComandoAlteraMedico_deve_alterar_o_telefone_do_medico()
    {
        var command = new ComandoAlteraMedico(Guid.NewGuid(), "11111111111");
        var handler = new ManipuladorMedico(new FakeRepositorioMedico());
        var result = (ComandoResultadoGenerico)handler.Handle(command);
        Assert.AreEqual(result.Success, true);

    }
}