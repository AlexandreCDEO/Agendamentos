namespace Agendamentos.Domain.Entities;

public class Paciente : Base
{
    private IList<Agendamento> _agendamentos;
    public Paciente()
    {
        
    }
    public Paciente(string nome, string telefone, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        _agendamentos = new List<Agendamento>();
    }

    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Cpf { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public IReadOnlyCollection<Agendamento> Agendamentos 
    {
        get { return _agendamentos.ToArray(); }
    }
    
    public bool AgendaLivre(DateTime inicio)
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
    
    public void AlteraTelefone(string telefone)
    {
        Telefone = telefone;
    }

    
}