using System;
using Agendamentos.Domain.Commands.Medico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.Commands.Medico;

[TestClass]
public class ComandoAlteraMedicoTests
{
    [TestMethod]
    public void Dada_propriedades_validas_o_comando_deve_retornar_valido_como_true()
    {
        var command = new ComandoAlteraMedico();
        command.Codigo = Guid.NewGuid();
        command.Nome = "Alexandre";
        command.Crm = "123456";
        command.Telefone = "15997314012";
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
    
    [TestMethod]
    public void Dada_propriedades_invalidas_o_comando_deve_retornar_valido_como_false()
    {
        var command = new ComandoAlteraMedico();
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }
}