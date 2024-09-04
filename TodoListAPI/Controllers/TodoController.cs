﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Interfaces;
using TodoListAPI.Models;

namespace TodoListAPI.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        //GET: api/todos
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _repository.GetAllTodos();
            return Ok(todos);
        }

        //POST: api/todos
        [HttpPost]
        public async Task<IActionResult> AddTodo(Todo todo)
        {
            await _repository.AddTodo(todo);
            return CreatedAtAction(nameof(AddTodo), new { id = todo.Id }, todo);
        }

        //GET: api/todos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await _repository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        //PUT: api/todos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo todo)
        {
            await _repository.UpdateTodo(todo);
            return NoContent();
        }

        //DELETE: api/todos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _repository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            await _repository.DeleteTodo(id);
            return NoContent();
        }
    }
}
