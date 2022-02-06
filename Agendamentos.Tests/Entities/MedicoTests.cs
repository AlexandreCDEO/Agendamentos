using System;
using System.Linq;
using Agendamentos.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.Entities;

[TestClass]
public class MedicoTests
{
    private readonly Paciente _paciente = new Paciente("Alexandre","15997314012", "40558477852", DateTime.Now.AddYears(-30));
    private readonly Medico _medico = new Medico("Jorge", "123456", "1234");

    
    [TestMethod]
    public void Dado_um_agendamento_com_horario_invalido_o_metodo_AgendaLivre_deve_retornar_falso()
    {
        var primeiroAgendamento = new Agendamento(new DateTime(2022,02,05,10,10,10), new DateTime(2022,02,05,10,20,10), _paciente, _medico);
        _medico.AdicionaAgendamento(primeiroAgendamento);
        
        Assert.AreEqual(_medico.AdicionaAgendamento(primeiroAgendamento), false);
        
    }
    
    [TestMethod]
    public void Dado_um_agendamento_valido_o_metodo_AgendaLivre_deve_retornar_true()
    {
        
        var primeiroAgendamento = new Agendamento(new DateTime(2022,02,05,10,10,10), new DateTime(2022,02,05,10,20,10), _paciente, _medico);
        var segundoAgendamento = new Agendamento(new DateTime(2022,02,05,10,30,10), new DateTime(2022,02,05,10,40,10),_paciente, _medico);
        _medico.AdicionaAgendamento(primeiroAgendamento);
        
        Assert.AreEqual(_medico.AdicionaAgendamento(segundoAgendamento), true); 
    }
}