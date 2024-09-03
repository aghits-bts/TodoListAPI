using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListAPI.Data;
using TodoListAPI.Data.Repositories;
using TodoListAPI.Models;

namespace TodoListAPI.Tests.Repositories
{
    public class TodoRepositoryTests
    {
        private readonly Mock<TodoDbContext> _contextMock;
        private readonly TodoRepository _repository;
        private readonly Mock<DbSet<Todo>> _mockSet;

        public TodoRepositoryTests()
        {
            _contextMock = new Mock<TodoDbContext>();
            _mockSet = new Mock<DbSet<Todo>>();
            _repository = new TodoRepository(_contextMock.Object);
            _contextMock.Setup(m => m.Todos).Returns(_mockSet.Object);
        }

        [Fact]
        public async Task AddTodo_ShouldAddTodoToContext() 
        { 
            //Arrange
            var todo = new Todo {
                Id = 1,
                Title = "test",
                Description = "test",
                //IsCompleted = false,
                //CreatedDate = new DateTime(),
                DueDate = new DateTime(2024, 9, 10, 15, 0, 0)
            };

            //Act
            await _repository.AddTodo(todo);

            //Assert
            _contextMock.Verify(c => c.Todos.Add(todo), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        //[Fact]
        //public async Task GetAllTodos_ShouldReturnAllTodos()
        //{
        //    //Arrange
        //    var todos = new List<Todo>()
        //    {
        //        new Todo
        //        {
        //            Id = 1,
        //            Title = "test1",
        //            Description = "test1",
        //            //IsCompleted = false,
        //            //CreatedDate = new DateTime(),
        //            DueDate = new DateTime(2024, 9, 10, 15, 0, 0)
        //        },
        //        new Todo
        //        {
        //            Id = 2,
        //            Title = "test2",
        //            Description = "test2",
        //            //IsCompleted = false,
        //            //CreatedDate = new DateTime(),
        //            DueDate = new DateTime(2024, 9, 11, 15, 0, 0)
        //        }
        //    };
        //    _mockSet.Setup(m => m.ToListAsync()).ReturnsAsync(todos);

        //    //Act
        //    var result = await _repository.GetAllTodos();

        //    //Assert
        //    Assert.Equal(todos, result);
        //}

        [Fact]
        public async Task GetTodoById_WithExistingId_ShouldReturnTodo()
        {
            //Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "test",
                Description = "test",
                //IsCompleted = false,
                //CreatedDate = new DateTime(),
                DueDate = new DateTime(2024, 9, 10, 15, 0, 0)
            };
            _mockSet.Setup(m => m.FindAsync(1)).ReturnsAsync(todo);

            //Act
            var result = await _repository.GetTodoById(1);

            //Assert
            Assert.Equal(todo, result);
        }

        [Fact]
        public async Task GetTodoById_WithNonExistingId_ShouldReturnNull()
        {
            // Arrange
            _contextMock.Setup(c => c.Todos.FindAsync(1)).ReturnsAsync((Todo)null);

            // Act
            var result = await _repository.GetTodoById(1);

            // Assert
            Assert.Null(result);
        }

        //[Fact]
        //public async Task UpdateTodo_WithExistingId_ShouldUpdateTodoFromContext()
        //{
        //    // Arrange
        //    var todo = new Todo
        //    {
        //        Id = 1,
        //        Title = "test",
        //        Description = "test",
        //        //IsCompleted = false,
        //        //CreatedDate = new DateTime(),
        //        DueDate = new DateTime(2024, 9, 10, 15, 0, 0)
        //    };
        //    _contextMock.Setup(c => c.Todos.FindAsync(1)).ReturnsAsync(todo);

        //    // Act
        //    await _repository.UpdateTodo(1);

        //    // Assert
        //    _contextMock.Verify(c => c.Todos.Update(todo), Times.Once);
        //    _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        //}

        //[Fact]
        //public async Task UpdateTodo_WithNonExistingId_ShouldNotUpdateTodoFromContext()
        //{
        //    // Arrange
        //    _contextMock.Setup(c => c.Todos.FindAsync(1)).ReturnsAsync((Todo)null);

        //    // Act
        //    await _repository.UpdateTodo(1);

        //    // Assert
        //    _contextMock.Verify(c => c.Todos.Update(It.IsAny<Todo>()), Times.Never);
        //    _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Never);
        //}

        [Fact]
        public async Task DeleteTodo_WithExistingId_ShouldRemoveTodoFromContext()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "test",
                Description = "test",
                //IsCompleted = false,
                //CreatedDate = new DateTime(),
                DueDate = new DateTime(2024, 9, 10, 15, 0, 0)
            };
            _contextMock.Setup(c => c.Todos.FindAsync(1)).ReturnsAsync(todo);

            // Act
            await _repository.DeleteTodo(1);

            // Assert
            _contextMock.Verify(c => c.Todos.Remove(todo), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task DeleteTodo_WithNonExistingId_ShouldNotRemoveTodoFromContext()
        {
            // Arrange
            _contextMock.Setup(c => c.Todos.FindAsync(1)).ReturnsAsync((Todo)null);

            // Act
            await _repository.DeleteTodo(1);

            // Assert
            _contextMock.Verify(c => c.Todos.Remove(It.IsAny<Todo>()), Times.Never);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Never);
        }
    }
}
