using System.Collections.Generic;
using react.net.Models;

namespace react.net.Repositories.Task
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAll();
        TaskModel Create(TaskModel obj);
        TaskModel Remove(int id);
    }
}