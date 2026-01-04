using aireports.Modules.Tasks.Domain;
using aireports.Modules.Tasks.Domain.Entities;

namespace aireports.Modules.Tasks.Infrastructure;

public interface TodoRepository
{
    Task<TodoEntity[]> GetAll();
    Task<TodoEntity> Get(int id);
    Task<TodoEntity> Create(string name);
    Task<TodoEntity> Update(int id, string name);
    Task<DeleteTodoResponse> Delete(int id);
}