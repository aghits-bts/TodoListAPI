using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoListAPI.Controllers;
using TodoListAPI.Interfaces;
using TodoListAPI.Models;

namespace TodoListAPI.Tests.Controllers
{
    public class TodoControllerTests
    {
        /*
        private readonly Mock<ITodoRepository> _repositoryMock;
        private readonly TodoController _controller;

        public TodoControllerTests()
        {
            _repositoryMock = new Mock<ITodoRepository>();
            _controller = new TodoController(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllTodos_ReturnsOkResult()
        {
            // Arrange
            var todos = new List<Todo>()
                {
                    new Todo { Id = 1, Title = "Task 1", Description = "description" },
                    new Todo { Id = 2, Title = "Task 2", Description = "description" }
                };
            _repositoryMock.Setup(repo => repo.GetAllTodos()).ReturnsAsync(todos);

            // Act
            var result = await _controller.GetAllTodos();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllTodos_ReturnsAllTodos()
        {
            // Arrange
            var todos = new List<Todo>()
                {
                    new Todo { Id = 1, Title = "Task 1", Description = "description" },
                    new Todo { Id = 2, Title = "Task 2", Description = "description" }
                };
            _repositoryMock.Setup(repo => repo.GetAllTodos()).ReturnsAsync(todos);

            // Act
            var result = await _controller.GetAllTodos() as OkObjectResult;
            var items = result.Value as List<Todo>;

            // Assert
            Assert.Equal(todos.Count, items.Count);
            Assert.Equal(todos, items);
        }

        [Fact]
        public async Task GetTodoById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Task 1", Description = "description" };
            _repositoryMock.Setup(repo => repo.GetTodoById(1)).ReturnsAsync(todo);

            // Act
            var result = await _controller.GetTodoById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTodoById_WithValidId_ReturnsTodo()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Task 1", Description = "description" };
            _repositoryMock.Setup(repo => repo.GetTodoById(1)).ReturnsAsync(todo);

            // Act
            var result = await _controller.GetTodoById(1) as OkObjectResult;
            var item = result.Value as Todo;

            // Assert
            Assert.Equal(todo.Id, item.Id);
            Assert.Equal(todo.Title, item.Title);
            Assert.Equal(todo.Description, item.Description);
        }

        [Fact]
        public async Task GetTodoById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetTodoById(1)).ReturnsAsync((Todo)null);

            // Act
            var result = await _controller.GetTodoById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddTodo_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            var result = await _controller.AddTodo(todo);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task AddTodo_ReturnsTodo()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            var result = await _controller.AddTodo(todo) as CreatedAtActionResult;
            var item = result.Value as Todo;

            // Assert
            Assert.Equal(todo.Id, item.Id);
            Assert.Equal(todo.Title, item.Title);
            Assert.Equal(todo.Description, item.Description);
        }

        [Fact]
        public async Task UpdateTodo_ReturnsNoContentResult()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            var result = await _controller.UpdateTodo(1, todo);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTodo_WithValidId_ReturnsNoContentResult()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Task 1", Description = "description" };
            _repositoryMock.Setup(repo => repo.GetTodoById(1)).ReturnsAsync(todo);

            // Act
            var result = await _controller.DeleteTodo(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTodo_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetTodoById(1)).ReturnsAsync((Todo)null);

            // Act
            var result = await _controller.DeleteTodo(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        */
    }
}
