using GerenciadorTarefas.Communication.Repositories;
using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    private readonly ITaskRepository _repository;
    public RegisterTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public ResponseTaskJson Execute (RequestTaskJson request)
    {
        var task = new ResponseTaskJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority,
            Status = request.Status
        };

        _repository.Add(task);

        return task;
    }
}