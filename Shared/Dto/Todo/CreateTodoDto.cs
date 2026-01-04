using System.ComponentModel.DataAnnotations;

public class CreateTodoDto
{
    [Required]
    public string Name { get; set; }
}