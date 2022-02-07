using System;
using Agendamentos.Domain.Commands.ComandosDeMedico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDosComandos.TesteDoComandoMedico;

[TestClass]
public class ComandoAlteraMedicoTests
{
    private readonly ComandoAlteraMedico _comandoValido = new ComandoAlteraMedico(Guid.NewGuid(), "11111111111");
    private readonly ComandoAlteraMedico _comandoInvalido = new ComandoAlteraMedico();

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