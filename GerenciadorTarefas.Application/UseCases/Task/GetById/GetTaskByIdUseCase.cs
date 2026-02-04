using GerenciadorTarefas.Communication.Repositories;
using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Application.UseCases.Task.GetById;

public class GetTaskByIdUseCase
{
    private readonly ITaskRepository _repository;

    public GetTaskByIdUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public ResponseTaskJson Execute(Guid id)
    {
        return _repository.GetById(id);
    }
}