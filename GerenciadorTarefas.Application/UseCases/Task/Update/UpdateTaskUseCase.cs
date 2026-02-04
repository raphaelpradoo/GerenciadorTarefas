using GerenciadorTarefas.Communication.Repositories;
using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Application.UseCases.Task.Update;

public class UpdateTaskUseCase
{
    private readonly ITaskRepository _repository;

    public UpdateTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public ResponseTaskJson? Execute(Guid id, RequestTaskJson request)
    {
        var task = _repository.GetById(id);

        if (task is null)
            return null;

        task.Name = request.Name;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.Priority = request.Priority;
        task.Status = request.Status;
        
        _repository.Update(task);

        return task;
    }
}