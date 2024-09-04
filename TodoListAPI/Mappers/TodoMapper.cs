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
                
            };
        }

        public static Todo ToTodoFromCreateDTO(this CreateTodoRequestDto todoDto)
        {
            return new Todo
            {
                
            };
        }
    }
}
