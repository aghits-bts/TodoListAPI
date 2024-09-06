using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Dtos.Todo;
using TodoListAPI.Helpers;
using TodoListAPI.Interfaces;
using TodoListAPI.Models;

namespace TodoListAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;
        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Todo> CreateAsync(Todo todoModel)
        {
            await _dbContext.Todos.AddAsync(todoModel);
            await _dbContext.SaveChangesAsync();
            return todoModel;
        }

        public async Task<List<Todo>> GetAllAsync(User user, TodoQueryObject queryObject)
        {
            var todos = _dbContext.Todos.Where(u => u.UserId == user.Id).AsQueryable();

            if (queryObject.IsCompleted.HasValue)
            {
                todos = todos.Where(t => t.IsCompleted.Equals(queryObject.IsCompleted));
            }
            if (queryObject.IsDescending == true)
            {
                todos = todos.OrderByDescending(t => t.DueDate);
            }

            var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return await todos.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(User user, int id)
        {
            return await _dbContext.Todos.FirstOrDefaultAsync(t => t.UserId == user.Id && t.Id == id);
        }

        public async Task<Todo?> UpdateAsync(User user, int id, Todo todoModel)
        {
            var existingTodo = await _dbContext.Todos.FirstOrDefaultAsync(t => t.UserId == user.Id && t.Id == id);

            if (existingTodo == null)
            {
                return null;
            }

            existingTodo.Title = todoModel.Title;
            existingTodo.Description = todoModel.Description;
            existingTodo.IsCompleted = todoModel.IsCompleted;
            existingTodo.DueDate = todoModel.DueDate;

            await _dbContext.SaveChangesAsync();

            return existingTodo;
        }

        public async Task<Todo?> DeleteAsync(User user, int id)
        {
            var todo = await _dbContext.Todos.FirstOrDefaultAsync(t => t.UserId == user.Id && t.Id == id);

            if (todo == null)
            {
                return null;
            }

            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();
            return todo;
        }
    }
}
