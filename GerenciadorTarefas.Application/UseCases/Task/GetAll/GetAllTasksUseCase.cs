using GerenciadorTarefas.Communication.Repositories;
using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Application.UseCases.Task.GetAll;

public class GetAllTasksUseCase
{
    private readonly ITaskRepository _repository;

    public GetAllTasksUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public List<ResponseTaskJson> Execute()
    {
        return _repository.GetAll();
    }
}