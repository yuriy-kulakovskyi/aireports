using aireports.Modules.Tasks.Domain;
using aireports.Modules.Tasks.Domain.Entities;
using aireports.Modules.Tasks.Infrastructure;

namespace aireports.Modules.Tasks.Application.Services;

public class TodoService
{
    private readonly TodoRepository _todoRepository;

    public TodoService(TodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task<TodoEntity[]> GetTodos()
    {
        return _todoRepository.GetAll();
    }

    public Task<TodoEntity> GetTodo(int todoId)
    {
        Console.WriteLine(todoId);
        return _todoRepository.Get(todoId);
    }

    public Task<TodoEntity> Create(string name)
    {
        return _todoRepository.Create(name);
    }

    public Task<TodoEntity> Update(int id, string name)
    {
        return _todoRepository.Update(id, name);
    }

    public Task<DeleteTodoResponse> Delete(int todoId)
    {
        return _todoRepository.Delete(todoId);
    }
}