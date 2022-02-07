using Agendamentos.Domain.Commands.Medico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.Commands.Medico;

[TestClass]
public class ComandoCriaMedicoTests
{
    private readonly ComandoCriaMedico _comandoValido = new ComandoCriaMedico("Nome do medico", "123456", "11111111111");
    private readonly ComandoCriaMedico _comandoInvalido = new ComandoCriaMedico();

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