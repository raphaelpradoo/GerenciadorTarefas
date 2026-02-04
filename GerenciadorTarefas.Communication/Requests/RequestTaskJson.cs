using GerenciadorTarefas.Communication.Enums;
using GerenciadorTarefas.Communication.Validator;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Communication.Requests;

public class RequestTaskJson
{
    [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "A prioridade é obrigatória.")]
    [EnumDataType(typeof(TaskPriority), ErrorMessage = "Prioridade inválida.")]
    public TaskPriority Priority { get; set; }

    [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
    [FutureOrTodayDate]
    public DateTime DueDate { get; set; } = new DateTime();

    [Required(ErrorMessage = "O status é obrigatório.")]
    [EnumDataType(typeof(TaskState), ErrorMessage = "Status inválido.")]
    public TaskState Status { get; set; }
}