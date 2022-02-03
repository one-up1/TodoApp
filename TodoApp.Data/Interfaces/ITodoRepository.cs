using System.Collections.Generic;

namespace TodoApp.Data.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();

        Todo GetTodo(int id);

        void AddTodo(Todo todo);

        void CheckTodo(int id);

        void DeleteTodo(int id);
    }
}
