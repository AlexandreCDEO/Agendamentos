using System;
using System.Collections.Generic;
using System.Linq;
using Agendamentos.Domain.Entities;
using Agendamentos.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDasQueries;

[TestClass]
public class AgendamentoQuerieTestes
{
    private List<Agendamento> _agendamentos;
    private  Paciente _paciente = new("Nome do paciente", "15997314012", "12345678911", DateTime.Now);
    private  Medico _medico = new("Nome do Medico", "123456", "15997314012");
    private  DateTime _inicio = DateTime.Now;
    private  DateTime _fim = DateTime.Now.AddMinutes(30);

    public AgendamentoQuerieTestes()
    {
        _agendamentos = new List<Agendamento>();
        _agendamentos.Add(new Agendamento(_inicio, _fim, _paciente, _medico));
        _agendamentos.Add(new Agendamento(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-2), _paciente, _medico));
        _agendamentos.Add(new Agendamento(
            _inicio,
            _fim,
            new Paciente("nome aqui", "15997424040", "11111111111", DateTime.Now),
            new Medico("Nome aqui", "654321", "15997324111"))
        );
    }

    [TestMethod]
    public void Dado_a_consulta_deve_retornar_apenas_as_consultas_com_o_paciente_setado()
    {
        var resultado = _agendamentos
            .AsQueryable()
            .Where(AgendamentoQueries.BuscaTodasConsultasPorPaciente(_paciente.Cpf));
        
        Assert.AreEqual(2, resultado.Count());
    }
    
    [TestMethod]
    public void Dado_a_consulta_deve_retornar_apenas_as_consultas_com_o_medico_setado()
    {
        var resultado = _agendamentos.AsQueryable().Where(AgendamentoQueries.BuscaTodasConsultasPorMedico(_medico.Crm));
        
        Assert.AreEqual(resultado.Count(), 2);
    }

    [TestMethod]
    public void Dado_a_consulta_deve_retornar_apenas_as_consultas_do_dia()
    {
        var resultado = 
            _agendamentos.
            AsQueryable()
            .Where(AgendamentoQueries.BuscaTodasConsultasDoDia());
        
        Assert.AreEqual(2, resultado.Count());
    }

    [TestMethod]
    public void Dado_a_consulta_deve_retornar_apenas_as_consultas_do_dia_de_um_determinado_medico()
    {
        var resultado = _agendamentos.AsQueryable()
            .Where(AgendamentoQueries.BuscaTodasConsultasDoDiaDeUmMedico(_medico.Crm));
        Assert.AreEqual(1, resultado.Count());
        
    }
}