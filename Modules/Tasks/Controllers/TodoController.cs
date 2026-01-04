using aireports.Modules.Tasks.Application.Services;
using aireports.Modules.Tasks.Domain;
using aireports.Modules.Tasks.Domain.Entities;
using aireports.Shared.Dto.Todo;
using Microsoft.AspNetCore.Mvc;

namespace aireports.Modules.Tasks.Controllers;

[ApiController]
[Route("todo")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;
    
    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("all")]
    public Task<TodoEntity[]> GetAll()
    {
        return _todoService.GetTodos();
    }

    [HttpGet("{id}")]
    public Task<TodoEntity> GetById([FromRoute] int id)
    {
        return _todoService.GetTodo(id);
    }

    [HttpPost("")]
    public Task<TodoEntity> Create([FromBody] CreateTodoDto dto)
    {
        return _todoService.Create(dto.Name);
    }

    [HttpPatch("{id}")]
    public Task<TodoEntity> Update([FromRoute] int id, [FromBody] UpdateTodoDto dto)
    {
        return _todoService.Update(id, dto.Name);
    }
    
    [HttpDelete("{id}")]
    public async Task<DeleteTodoResponse> Delete([FromRoute] int id)
    {
        var res = await _todoService.Delete(id);
        return res;
    }
}