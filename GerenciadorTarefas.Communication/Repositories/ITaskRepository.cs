using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Communication.Repositories;

public interface ITaskRepository
{
    void Add(ResponseTaskJson task);
    List<ResponseTaskJson> GetAll();
    ResponseTaskJson? GetById(Guid id);
    void Update(ResponseTaskJson task);
    bool Delete(Guid id);
}