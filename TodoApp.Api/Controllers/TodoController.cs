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

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return db.Todo;
        }

        [HttpGet]
        public Todo Get(int id)
        {
            return db.Todo.FirstOrDefault(r => r.Id == id);
        }
    }
}
