using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Data.Interfaces;

namespace TodoApp.Data
{
    public class TodoRepository : DbContext, ITodoRepository
    {
        public TodoRepository(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }

        public IEnumerable<Todo> GetTodos()
        {
            return Todo;
        }

        public Todo GetTodo(int id)
        {
            return Todo.FirstOrDefault(r => r.Id == id);
        }

        public void AddTodo(Todo todo)
        {
            Todo.Add(todo);
            SaveChanges();
        }

        public void CheckTodo(int id)
        {
            Todo todo = GetTodo(id);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
                SaveChanges();
            }
        }

        public void DeleteTodo(int id)
        {
            Todo todo = GetTodo(id);
            if (todo != null)
            {
                Todo.Remove(todo);
                SaveChanges();
            }
        }
    }
}
