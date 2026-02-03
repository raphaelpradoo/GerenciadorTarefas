using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseTaskJson Execute (RequestRegisterTaskJson request)
    {
        return new ResponseTaskJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority,
            Status = request.Status
        };
    }
}