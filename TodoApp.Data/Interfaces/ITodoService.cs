using System.Collections.Generic;

namespace TodoApp.Data.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<Todo> Get();

        Todo Get(int id);

        void Create(Todo todo);

        void Check(int id);

        void Delete(int id);
    }
}