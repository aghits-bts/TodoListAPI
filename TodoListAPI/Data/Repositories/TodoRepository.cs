using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

namespace TodoListAPI.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;
        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTodo(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _dbContext.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodoById(int id)
        {
            return await _dbContext.Todos.FindAsync(id);
        }

        public async Task UpdateTodo(Todo todo)
        {
            _dbContext.Entry(todo).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExist(todo.Id))
                {
                    throw new InvalidOperationException("Todo not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if (todo != null) 
            {
                _dbContext.Todos.Remove(todo);
                await _dbContext.SaveChangesAsync();
            }
        }

        private bool TodoExist(int id)
        {
            return _dbContext.Todos.Any(todo => todo.Id == id);
        }
    }
}
