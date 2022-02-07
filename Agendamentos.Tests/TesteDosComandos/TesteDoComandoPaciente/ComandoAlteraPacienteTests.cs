using System;
using Agendamentos.Domain.Commands.ComandosDePaciente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDosComandos.TesteDoComandoPaciente;

[TestClass]
public class ComandoAlteraPacienteTests
{
    private readonly ComandoAlteraPaciente _comandoValido = new ComandoAlteraPaciente(Guid.NewGuid(), "15912341234");
    private readonly ComandoAlteraPaciente _comandoInvalido = new ComandoAlteraPaciente();

    [TestMethod]
    public void Dada_propriedades_validas_o_comando_deve_retornar_valido_como_true()
    {
        _comandoValido.Validate();
        Assert.AreEqual(_comandoValido.Valid, true);
    }
    
    [TestMethod]
    public void Dada_propriedades_invalidas_o_comando_deve_retornar_valido_como_false()
    {
        _comandoInvalido.Validate();
        Assert.AreEqual(_comandoInvalido.Valid, false);
    }
}