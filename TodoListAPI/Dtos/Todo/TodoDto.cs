﻿namespace TodoListAPI.Dtos.Todo
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public string? UserId { get; set; }
    }
}
