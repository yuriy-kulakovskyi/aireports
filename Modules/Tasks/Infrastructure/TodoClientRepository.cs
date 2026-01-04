using System.Globalization;
using aireports.Modules.Tasks.Domain;
using System.Text.Json;
using aireports.Modules.Tasks.Domain.Entities;

namespace aireports.Modules.Tasks.Infrastructure;

public class TodoClientRepository : TodoRepository 
{
    private List<TodoEntity> _todos;
    string jsonFilePath = "todos.json";

    public TodoClientRepository()
    {
        if (File.Exists(jsonFilePath))
        {
            var content = File.ReadAllText(jsonFilePath);
            _todos = JsonSerializer.Deserialize<List<TodoEntity>>(content) ?? new List<TodoEntity>();
        }
        else
        {
            _todos = new List<TodoEntity>();
        }
    }
    
    public async Task<TodoEntity[]> GetAll()
    {
        try
        {
            return _todos.Where(x => x.isDeleted == false).ToArray();
        }
        catch
        {
            throw new Exception("Error occured while retrieving todos");
        }
    }
    
    public async Task<TodoEntity> Get(int id)
    {
        try
        {
            return _todos.Find(x => x.id == id && x.isDeleted == false);
        }
        catch
        {
            throw new CultureNotFoundException("Couldn't find a todo with id " + id);
        }
    }

    public async Task<TodoEntity> Create(string name)
    {
        if (name.Length == 0)
            throw new BadHttpRequestException("Name cannot be null");
        
        try
        {
            int newId = _todos.Count + 1;

            TodoEntity newPart = new TodoEntity()
            {
                id = newId,
                name = name,
                isDeleted = false
            };

            _todos.Add(newPart);
            SaveTodosToFile();
            return newPart;
        }
        catch
        {
            throw new Exception("Error while creating a todo");
        }
    }

    public async Task<TodoEntity> Update(int id, string name)
    {
        if (name.Length == 0)
            throw new BadHttpRequestException("Name cannot be null");
        
        try
        {
            TodoEntity todo = _todos.Find(x => x.id == id && x.isDeleted == false);
            todo.name = name;
            SaveTodosToFile();
            return todo;
        } catch
        {
            throw new Exception("Error occured while updating a todo " + id);
        }
    }

    public async Task<DeleteTodoResponse> Delete(int id)
    {
        TodoEntity todo = _todos.Find(x => x.id == id && x.isDeleted == false);
        if (todo == null)
        {
            return new DeleteTodoResponse()
            {
                Message = $"Todo with id {id} not found or already deleted",
                DeletedAt = DateTime.Today
            };
        }

        todo.isDeleted = true;
        SaveTodosToFile();

        return new DeleteTodoResponse()
        {
            Message = "Todo deleted successfully",
            DeletedAt = DateTime.Today
        };
    }
    
    private void SaveTodosToFile()
    {
        var content = JsonSerializer.Serialize(_todos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonFilePath, content);
    }
}