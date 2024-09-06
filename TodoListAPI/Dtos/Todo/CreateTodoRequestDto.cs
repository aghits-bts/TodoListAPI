using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Dtos.Todo
{
    public class CreateTodoRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]  
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime DueDate { get; set; }
    }
}