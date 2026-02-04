using GerenciadorTarefas.Communication.Repositories;

namespace GerenciadorTarefas.Application.UseCases.Task.Delete;

public class DeleteTaskUseCase
{
    private readonly ITaskRepository _repository;

    public DeleteTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public bool Execute(Guid id)
    {
        return _repository.Delete(id);
    }
}