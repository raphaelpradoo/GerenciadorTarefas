using GerenciadorTarefas.Communication.Responses;

namespace GerenciadorTarefas.Communication.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    public static readonly List<ResponseTaskJson> _tasks = new();
    public void Add(ResponseTaskJson task)
    {
        _tasks.Add(task);
    }

    public List<ResponseTaskJson> GetAll()
    {
        return _tasks;
    }

    public ResponseTaskJson? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Update(ResponseTaskJson task)
    {
        var index = _tasks.FindIndex(t => t.Id == task.Id);

        if (index < 0)
            return;

        _tasks[index] = task;
    }

    public bool Delete(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task is null)
            return false;

        _tasks.Remove(task);
        return true;
    }

}