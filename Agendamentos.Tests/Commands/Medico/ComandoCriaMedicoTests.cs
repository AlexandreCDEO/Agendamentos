using Agendamentos.Domain.Commands.Medico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.Commands.Medico;

[TestClass]
public class ComandoCriaMedicoTests
{
    [TestMethod]
    public void Dada_propriedades_validas_o_comando_deve_ser_valido()
    {
        var command = new ComandoCriaMedico();
        command.Nome = "Alexandre";
        command.Crm = "123456";
        command.Telefone = "15997314012";
        command.Validate();
        
        Assert.AreEqual(command.Valid, true);
    }
    
    [TestMethod]
    public void Dada_propriedades_invalidas_o_comando_deve_ser_invalido()
    {
        var command = new ComandoCriaMedico();
        command.Validate();
        Assert.AreEqual(command.Valid, false);
        
    }
}