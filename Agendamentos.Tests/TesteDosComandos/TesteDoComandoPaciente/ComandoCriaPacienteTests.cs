using System;
using Agendamentos.Domain.Commands.ComandosDePaciente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDosComandos.TesteDoComandoPaciente;

[TestClass]
public class ComandoCriaPacienteTests
{
    private readonly ComandoCriaPaciente _comandoValido = new ComandoCriaPaciente(
        "Nome do Paciente", 
        "11111111111",
        "12345678911",
        DateTime.Now
    );
    
    private readonly ComandoCriaPaciente _comandoInvalido = new ComandoCriaPaciente(
        "Nome do Paciente", 
        "",
        "",
        DateTime.Now
    );
    
    
    [TestMethod]
    public void Dada_propriedades_validas_o_comando_deve_ser_valido()
    {
        
        _comandoValido.Validate();
        Assert.AreEqual(_comandoValido.Valid, true);
        
    }
    
    [TestMethod]
    public void Dada_propriedades_invalidas_o_comando_deve_ser_invalido()
    {
        
        _comandoInvalido.Validate();
        Assert.AreEqual(_comandoInvalido.Valid, false);

    }
}