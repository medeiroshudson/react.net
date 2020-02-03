using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using react.net.Helpers;
using react.net.Models;

namespace react.net.Repositories.Task
{
    public class TaskRepository : RepositoryConnector, ITaskRepository
    {
        public TaskRepository(IConfiguration configuration) : base(configuration) { }

        public TaskModel Create(TaskModel obj)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                int taskID;
                TaskModel task;

                // registering task
                string queryRegister = $@"INSERT INTO [dbo].[Task]
                                        ([Name]
                                        ,[Disabled])
                                        VALUES
                                        ('{obj.Name}'
                                        ,'0')
                                        
                                        SELECT CAST(SCOPE_IDENTITY() as int)";

                taskID = con.Query<int>(queryRegister).Single();

                // returning registered task
                string querySelect = $@"SELECT * FROM Task WHERE ID = {taskID}";
                task = con.Query<TaskModel>(querySelect).Single();

                return task;
            }
        }

        public IEnumerable<TaskModel> GetAll()
        {
            IEnumerable<TaskModel> result;
            string query = "SELECT * FROM Task WHERE Disabled = 0";

            using (var con = new SqlConnection(GetConnection()))
            {
                result = con.Query<TaskModel>(query);
            }

            return result;
        }

        public TaskModel Remove(int id)
        {
            string querySelect = $@"SELECT * FROM Task WHERE ID = {id}";
            string queryDisable = $@"UPDATE Task SET Disabled = 1 WHERE ID = {id}";

            using (var con = new SqlConnection(GetConnection()))
            {
                var task = con.Query<TaskModel>(querySelect).FirstOrDefault();

                if (task == null)
                    throw new AppException("Task not found.");

                // disabling task
                con.Execute(queryDisable);

                // returning disabled task
                task = con.Query<TaskModel>(querySelect).FirstOrDefault();

                return task;
            }
        }
    }
}