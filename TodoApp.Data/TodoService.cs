using System.Collections.Generic;
using TodoApp.Data.Interfaces;

namespace TodoApp.Data
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository db;

        public TodoService(ITodoRepository db)
        {
            this.db = db;
        }

        public IEnumerable<Todo> Get()
        {
            return db.GetTodos();
        }

        public Todo Get(int id)
        {
            return db.GetTodo(id);
        }

        public void Create(Todo todo)
        {
            db.AddTodo(todo);
        }

        public void Check(int id)
        {
            db.CheckTodo(id);
        }

        public void Delete(int id)
        {
            db.DeleteTodo(id);
        }
    }
}
