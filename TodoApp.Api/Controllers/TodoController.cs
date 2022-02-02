using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Data;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoDbContext db;

        public TodoController(ILogger<TodoController> logger,
            TodoDbContext todoDbContext)
        {
            _logger = logger;
            db = todoDbContext;
        }

        [HttpGet("/todos")]
        public IEnumerable<Todo> Get()
        {
            return db.Todo;
        }

        [HttpGet("/todo/{id}")]
        public Todo Get(int id)
        {
            return db.Todo.FirstOrDefault(r => r.Id == id);
        }

        [HttpPost("/todo/create")]
        public void Create(Todo todo)
        {
            db.Todo.Add(todo);
            db.SaveChanges();
        }

        [HttpPost("/todo/{id}/check")]
        public void Check(int id)
        {
            Todo todo = Get(id);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
                db.SaveChanges();
            }
        }

        [HttpPost("/todo/{id}/delete")]
        public void Delete(int id)
        {
            Todo todo = Get(id);
            if (todo != null)
            {
                db.Todo.Remove(todo);
                db.SaveChanges();
            }
        }
    }
}
