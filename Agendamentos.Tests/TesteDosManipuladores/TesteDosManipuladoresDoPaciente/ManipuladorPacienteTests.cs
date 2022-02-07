using System;
using Agendamentos.Domain.Commands;
using Agendamentos.Domain.Commands.ComandosDePaciente;
using Agendamentos.Domain.Handlers;
using Agendamentos.Tests.RepositoriosParaTeste;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDosManipuladores.TesteDosManipuladoresDoPaciente;

[TestClass]
public class ManipuladorPacienteTests
{
   [TestMethod]
   public void Dado_um_comando_valido_o_paciente_deve_ser_criado()
   {
      var comando = new ComandoCriaPaciente("Nome do Paciente", "15111111111", "11111111111", DateTime.Now);
      var handler = new ManipuladorPaciente(new FakeRepositorioPaciente());
      var resultado = (ComandoResultadoGenerico) handler.Handle(comando);
      Assert.AreEqual(resultado.Success, true);

   }
   
   [TestMethod]
   public void Dado_um_comando_invalido_o_paciente_nao_deve_ser_criado()
   {
      var comando = new ComandoCriaPaciente();
      var handler = new ManipuladorPaciente(new FakeRepositorioPaciente());
      var resultado = (ComandoResultadoGenerico) handler.Handle(comando);
      Assert.AreEqual(resultado.Success, false);
      
   }
   
   [TestMethod]
   public void O_ComandoAlteraPaciente_deve_alterar_o_telefone_do_paciente()
   {
      var comando = new ComandoAlteraPaciente(Guid.NewGuid(), "11111111111");
      var handler = new ManipuladorPaciente(new FakeRepositorioPaciente());
      var resultado = (ComandoResultadoGenerico)handler.Handle(comando);
      Assert.AreEqual(resultado.Success, true);

   }
   
}