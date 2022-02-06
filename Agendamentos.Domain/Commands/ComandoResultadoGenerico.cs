using Agendamentos.Domain.Commands.Contracts;

namespace Agendamentos.Domain.Commands;

public class ComandoResultadoGenerico : ICommandResult
{
    public ComandoResultadoGenerico()
    {
        
    }
    public ComandoResultadoGenerico(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}