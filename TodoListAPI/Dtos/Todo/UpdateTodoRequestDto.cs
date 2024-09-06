using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Dtos.Todo
{
    public class UpdateTodoRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
