namespace Agendamentos.Domain.Entities;

public class Agendamento : Base
{
    public Agendamento()
    {
        
    }
    
    public Agendamento(DateTime inicioAtendimento, DateTime fimAtendimento,Paciente paciente, Medico medico)
    {
        InicioAtendimento = inicioAtendimento;
        FimAtendimento = fimAtendimento;
        Paciente = paciente;
        Medico = medico;
        DataCadastro = DateTime.Now;
    }

    
    public DateTime InicioAtendimento { get; private set; }
    public DateTime FimAtendimento { get; private set; }
    
    public DateTime DataCadastro { get; private set; }
    public Paciente Paciente { get; private set; }
    public Medico Medico { get; private set; }
    

    //Verifica se o agendamento esta entre 8 e 18 horqs
    public bool HorarioValido()
    {
        if (InicioAtendimento.Hour < 8 || FimAtendimento.Hour > 18)
            return false;

        return true;
    }

    //Verifica se o agendamento é em dia de semana
    public bool DiaDaSemanaValido()
    {
        if (InicioAtendimento.DayOfWeek == DayOfWeek.Saturday || InicioAtendimento.DayOfWeek == DayOfWeek.Sunday)
            return false;

        return true;
    }
    
    //Verica se o tempo de consulta e exatamente 30 minutos;
    public bool TempoDeConsulta()
    {
        var tempoConsulta = FimAtendimento - InicioAtendimento;
        if (tempoConsulta.TotalMinutes < 30 || tempoConsulta.TotalMinutes > 30)
        {
            return false;
        }

        return true;
    }
    
    //verifica se o agendamento esta sendo feito com 24 horas de antecedencia
    public bool Antecedencia()
    {
        if (InicioAtendimento < DateTime.Now.AddDays(1))
            return false;

        return true;
    }
}