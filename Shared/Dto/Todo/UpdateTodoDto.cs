using System.ComponentModel.DataAnnotations;

namespace aireports.Shared.Dto.Todo;

public class UpdateTodoDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}