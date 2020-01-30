using System.Collections.Generic;
using react.net.Models;

namespace react.net.Repositories.Task
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAll();
        void Create(TaskModel obj);
        void Remove(int id);
    }
}