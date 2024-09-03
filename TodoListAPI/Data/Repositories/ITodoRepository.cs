using TodoListAPI.Models;

namespace TodoListAPI.Data.Repositories
{
    public interface ITodoRepository
    {
        Task AddTodo(Todo todo);
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo?> GetTodoById(int id);
        Task UpdateTodo(Todo todo);
        Task DeleteTodo(int id);
    }
}
