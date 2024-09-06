using TodoListAPI.Dtos.Todo;
using TodoListAPI.Helpers;
using TodoListAPI.Models;

namespace TodoListAPI.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> CreateAsync(Todo todoModel);
        Task<List<Todo>> GetAllAsync(User user, TodoQueryObject queryObject);
        Task<Todo?> GetByIdAsync(User user, int id);
        Task<Todo?> UpdateAsync(User user, int id, Todo todoModel);
        Task<Todo?> DeleteAsync(User user, int id);
    }
}
