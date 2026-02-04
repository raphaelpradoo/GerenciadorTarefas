using GerenciadorTarefas.Application.UseCases.Task.Delete;
using GerenciadorTarefas.Application.UseCases.Task.GetAll;
using GerenciadorTarefas.Application.UseCases.Task.GetById;
using GerenciadorTarefas.Application.UseCases.Task.Register;
using GerenciadorTarefas.Application.UseCases.Task.Update;
using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly RegisterTaskUseCase _registerUseCase;
    private readonly GetAllTasksUseCase _getAllUseCase;
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase;
    private readonly UpdateTaskUseCase _updateTaskUseCase;
    private readonly DeleteTaskUseCase _deleteTaskUseCase;

    public TaskController(
        RegisterTaskUseCase registerUseCase, 
        GetAllTasksUseCase getAllUseCase,
        GetTaskByIdUseCase getTaskByIdUseCase,
        UpdateTaskUseCase updateTaskUseCase,
        DeleteTaskUseCase deleteTaskUseCase)
    {
        _registerUseCase = registerUseCase;
        _getAllUseCase = getAllUseCase;
        _getTaskByIdUseCase = getTaskByIdUseCase;
        _updateTaskUseCase = updateTaskUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTaskJson request)
    {
        var response = _registerUseCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var tasks = _getAllUseCase.Execute();

        if (!tasks.Any())
            return NoContent();

        return Ok(tasks);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var response = _getTaskByIdUseCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        var task = _updateTaskUseCase.Execute(id, request);

        if (task is null)
            return NotFound($"Task com id {id} não encontrada.");

        return Ok(task);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var deleted = _deleteTaskUseCase.Execute(id);

        if (!deleted)
            return NotFound($"Task com id {id} não encontrada.");

        return NoContent();
    }
}
