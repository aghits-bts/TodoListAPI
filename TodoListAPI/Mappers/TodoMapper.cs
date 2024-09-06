using TodoListAPI.Dtos.Todo;
using TodoListAPI.Models;

namespace TodoListAPI.Mappers
{
    public static class TodoMapper
    {
        public static TodoDto ToTodoDto(this Todo todoModel)
        {
            return new TodoDto
            {
                Id = todoModel.Id,
                Title = todoModel.Title,
                Description = todoModel.Description,
                IsCompleted = todoModel.IsCompleted,
                CreatedDate = todoModel.CreatedDate,
                DueDate = todoModel.DueDate,
                UserId = todoModel.UserId
            };
        }

        public static Todo ToTodoFromCreateDTO(this CreateTodoRequestDto createTodoDto, string userId)
        {
            return new Todo
            {
                Title = createTodoDto.Title,
                Description = createTodoDto.Description,
                IsCompleted = createTodoDto.IsCompleted,
                CreatedDate = createTodoDto.CreatedDate,
                DueDate = createTodoDto.DueDate,
                UserId = userId
            };
        }

        public static Todo ToTodoFromUpdateDTO(this UpdateTodoRequestDto updateTodoDto, string userId)
        {
            return new Todo
            {
                Title = updateTodoDto.Title,
                Description = updateTodoDto.Description,
                IsCompleted = updateTodoDto.IsCompleted,
                DueDate = updateTodoDto.DueDate,
                UserId = userId
            };
        }
    }
}
