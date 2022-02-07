using System;
using Agendamentos.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agendamentos.Tests.TesteDasEntidades;

[TestClass]
public class AgendamentoTests
{
    [TestMethod]
    public void
        Dado_um_agendamento_com_horario_antes_das_6_ou_depois_das_18_o_metodo_HorarioValido_deve_retornar_false()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,06,05,00,00),
            new DateTime(2022, 02,06,05,30,00),
            null,
            null
        );
        Assert.AreEqual(agendamento.HorarioValido(), false);
        
    }
    
    [TestMethod]
    public void
        Dado_um_agendamento_com_horario_depois_das_8_ou_antes_das_18_o_metodo_HorarioValido_deve_retornar_true()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,06,08,30,00),
            new DateTime(2022, 02,06,09,00,00),
            null,
            null
        );
        Assert.AreEqual(agendamento.HorarioValido(), true);
        
    }

    [TestMethod]
    public void
        Dado_um_agendamento_com_dia_da_semana_sendo_sabado_ou_domingo_o_metodo_DiaDaSemanaValido_deve_retornar_false()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,06,08,30,00),
            new DateTime(2022, 02,06,09,00,00),
            null,
            null
        );
        Assert.AreEqual(agendamento.DiaDaSemanaValido(), false);
    }
    
    [TestMethod]
    public void
        Dado_um_agendamento_com_dia_da_semana_nao_sendo_sabado_ou_domingo_o_metodo_DiaDaSemanaValido_deve_retornar_true()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,07,08,30,00),
            new DateTime(2022, 02,07,09,00,00),
            null,
            null
        );
        Assert.AreEqual(agendamento.DiaDaSemanaValido(), true);
    }

    [TestMethod]
    public void
        Dado_um_agendamento_com_tempo_maior_ou_menor_que_trinta_minutos_o_metodo_TempoDeConsulta_deve_retornar_false()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,07,08,30,00),
            new DateTime(2022, 02,07,09,40,00),
            null,
            null
        );
        Assert.AreEqual(agendamento.TempoDeConsulta(),false);
    }
    
    [TestMethod]
    public void
        Dado_um_agendamento_com_tempo_igual_a_trinta_minutos_o_metodo_TempoDeConsulta_deve_retornar_true()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,07,08,30,00),
            new DateTime(2022, 02,07,09,00,00),
            null,
            null
        );
        Assert.AreEqual(agendamento.TempoDeConsulta(),true);
    }

    [TestMethod]
    public void
        Dado_um_agendamento_feito_com_menos_de_24_horas_de_antecedencia_o_metodo_Antecedencia_deve_retornar_false()
    {
        var agendamento = new Agendamento(
            new DateTime(2022,02,06,08,30,00),
            new DateTime(2022, 02,06,09,00,00),
            null,
            null
        );
        
        Assert.AreEqual(agendamento.Antecedencia(), false);
    }
    
    [TestMethod]
    public void
        Dado_um_agendamento_feito_com_pelo_menos_24_horas_de_antecedencia_o_metodo_Antecedencia_deve_retornar_true()
    {
        var agendamento = new Agendamento(
            DateTime.Now.AddDays(2), 
            DateTime.Now.AddDays(2), 
            null,
            null
        );
        
        Assert.AreEqual(agendamento.Antecedencia(), true);
    }
}