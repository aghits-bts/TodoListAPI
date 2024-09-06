using api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TodoListAPI.Dtos.Todo;
using TodoListAPI.Helpers;
using TodoListAPI.Interfaces;   
using TodoListAPI.Mappers;
using TodoListAPI.Models;

namespace TodoListAPI.Controllers
{
    [Route("api/todos")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepo;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<TodoController> _logger;
        public TodoController(ITodoRepository todoRepo, UserManager<User> userManager, ILogger<TodoController> logger)
        {
            _todoRepo = todoRepo;
            _userManager = userManager;
            _logger = logger;
        }

        //GET: api/todos
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TodoQueryObject queryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var userTodos = await _todoRepo.GetAllAsync(user, queryObject);
            var userTodoDto = userTodos.Select(t => t.ToTodoDto());

            Log.Information("TodoList => {@userTodoDto}", userTodoDto);
            return Ok(userTodoDto);
        }

        //POST: api/todos
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            var todoModel = createDto.ToTodoFromCreateDTO(user.Id);
            await _todoRepo.CreateAsync(todoModel);
            return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, todoModel.ToTodoDto());
        }

        //GET: api/todos/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var todo = await _todoRepo.GetByIdAsync(user, id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo.ToTodoDto());
        }

        //PUT: api/todos/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var todo = await _todoRepo.UpdateAsync(user, id, updateDto.ToTodoFromUpdateDTO(user.Id));
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo.ToTodoDto());
        }

        //DELETE: api/todos/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var todo = await _todoRepo.DeleteAsync(user, id);

            if (todo == null)
            {
                return NotFound("Todo does not exist");
            }

            return NoContent();
        }
    }
}
