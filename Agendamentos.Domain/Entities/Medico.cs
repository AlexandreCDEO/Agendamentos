namespace Agendamentos.Domain.Entities;
using Flunt.Validations;


public class Medico : Base
{
    private IList<Agendamento> _agendamentos;
    public Medico(string nome, string crm, string telefone)
    {
        Nome = nome;
        Crm = crm;
        Telefone = telefone;
        _agendamentos = new List<Agendamento>();
    }

    public string Nome { get; private set; }
    public string Crm { get; private set; }
    public string Telefone { get; private set; }
    public IReadOnlyCollection<Agendamento> Agendamentos
    {
        get { return _agendamentos.ToArray(); }
    }
    

    bool AgendaLivre(DateTime inicio)
    {
        foreach (var agendamento in Agendamentos)
        {
            if (inicio >= agendamento.InicioAtendimento && inicio <= agendamento.FimAtendimento)
            {
                return false;
            }
        }

        return true;
    }

    public bool AdicionaAgendamento(Agendamento agendamento)
    {
        if (AgendaLivre(agendamento.InicioAtendimento))
        {
            _agendamentos.Add(agendamento);
            return true;
        }

        return false;
    }

}