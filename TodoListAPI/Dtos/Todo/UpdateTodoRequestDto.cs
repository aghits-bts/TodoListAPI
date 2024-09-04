using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Dtos.Todo
{
    public class UpdateTodoRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsCompleted { get; set; } = false;
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
    }
}
