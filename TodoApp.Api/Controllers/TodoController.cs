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
            return service.Get();
        }

        [HttpGet("/todo/{id}")]
        public Todo Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost("/todo/create")]
        public void Create(Todo todo)
        {
            service.Create(todo);
        }

        [HttpPost("/todo/{id}/check")]
        public void Check(int id)
        {
            service.Check(id);
        }

        [HttpPost("/todo/{id}/delete")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
