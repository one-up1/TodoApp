using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TodoApp.Data;
using TodoApp.Data.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService service;

        public TodoController(ILogger<TodoController> logger, ITodoService service)
        {
            _logger = logger;

            this.service = service;
        }

        [HttpGet("/todos")]
        public IEnumerable<Todo> Get()
        {
            return service.GetTodos();
        }

        [HttpGet("/todo/{id}")]
        public Todo Get(int id)
        {
            return service.GetTodo(id);
        }

        [HttpPost("/todo/create")]
        public void Create(Todo todo)
        {
            service.AddTodo(todo);
        }

        [HttpPost("/todo/{id}/check")]
        public void Check(int id)
        {
            service.CheckTodo(id);
        }

        [HttpPost("/todo/{id}/delete")]
        public void Delete(int id)
        {
            service.DeleteTodo(id);
        }
    }
}
