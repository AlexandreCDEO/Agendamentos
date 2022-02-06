using Flunt.Notifications;

namespace Agendamentos.Domain.Entities;

public abstract class Base
{
    public Base()
    {
        Codigo = Guid.NewGuid();
    }
    public Guid Codigo { get; private set; }
}