using GerenciadorTarefas.Communication.Enums;

namespace GerenciadorTarefas.Communication.Responses;

public class ResponseTaskJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public TaskState Status { get; set; }
}