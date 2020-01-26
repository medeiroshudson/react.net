using System.Collections.Generic;
using react.net.Models;

namespace react.net.Repositories.Todo
{
    public interface ITodoRepository
    {
        IEnumerable<TodoModel> GetAll();
        void Create(TodoModel obj);
        void Remove(int id);
    }
}